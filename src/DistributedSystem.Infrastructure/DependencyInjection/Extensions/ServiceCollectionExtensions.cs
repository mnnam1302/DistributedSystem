﻿using System.Configuration;
using System.Reflection;
using DistributedSystem.Application.Abstractions;
using DistributedSystem.Contract.JsonConverters;
using DistributedSystem.Infrastructure.Authentication;
using DistributedSystem.Infrastructure.BackgroundJobs;
using DistributedSystem.Infrastructure.Caching;
using DistributedSystem.Infrastructure.Consumer.Abstractions.Repositories;
using DistributedSystem.Infrastructure.Consumer.Repositories;
using DistributedSystem.Infrastructure.DependencyInjection.Options;
using DistributedSystem.Infrastructure.PasswordHasher;
using DistributedSystem.Infrastructure.PipelineObservers;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OpenTelemetry.Exporter;
using OpenTelemetry.Instrumentation.AspNetCore;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Quartz;

namespace DistributedSystem.Infrastructure.DependencyInjection.Extensions;

public static class ServiceCollectionExtensions
{
    public static void ConfigureServicesInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Using the options pattern is to bind the Position section and add it to the dependency injection service container
        services.Configure<MongoDbSettings>(configuration.GetSection(nameof(MongoDbSettings)));

        // Using the preceding code, the following code reads the IMongoDbSettings options
        // Mỗi khi IMongoDbSettings được DI thì nó mới gọi đến MongoDbSettings

        // Đặt trong static class
        //public const string DatabaseName = "acbdfvf";
        //public const string ConnectionString = "aBCDXYZ";

        services.AddSingleton<IMongoDbSettings>(serviceProvider =>
            serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);

        services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
    }

    public static void AddServicesInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IJwtTokenService, JwtTokenService>();
        services.AddTransient<ICacheService, CacheService>();
        services.AddTransient<IPasswordHasherService, PasswordHasherService>();
    }

    public static void AddRedisInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Nếu mình không cấu hình AddStackExchangeRedisCache thì sẽ sử dụng MemoryCache
        services.AddStackExchangeRedisCache(redisOptions =>
        {
            var connectionString = configuration.GetConnectionString("Redis");
            redisOptions.Configuration = connectionString;
        });
    }

    // Configure MassTransit with RabbitMQ
    public static IServiceCollection AddMasstransitRabbitMQInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var massTransitConfiguration = new MasstransitConfiguration();
        configuration.GetSection(nameof(MasstransitConfiguration)).Bind(massTransitConfiguration);

        var messageBusOptions = new MesssageBusOptions();
        configuration.GetSection(nameof(MesssageBusOptions)).Bind(messageBusOptions);

        services.AddMassTransit(cfg =>
        {
            // =================== Setup for Consumer ===================
            cfg.AddConsumers(Assembly.GetExecutingAssembly()); // Add all consumer to masstransit instead of above command

            // ?? => Configure endpoint formatter. Not configure for producer Root Exchange
            // Chuyển đổi - set cho class con
            cfg.SetKebabCaseEndpointNameFormatter(); // ?? Ex: Convert CreateProduct to create-user

            cfg.UsingRabbitMq((context, bus) =>
            {
                bus.Host(massTransitConfiguration.Host, massTransitConfiguration.Port, massTransitConfiguration.VHost, h =>
                {
                    h.Username(massTransitConfiguration.Username);
                    h.Password(massTransitConfiguration.Password);
                });

                bus.UseMessageRetry(retry =>
                    retry.Incremental(
                        retryLimit: messageBusOptions.RetryLimit,
                        initialInterval: messageBusOptions.InitialInterval,
                        intervalIncrement: messageBusOptions.IntervalIncrement));

                // I want to serialized when send message to RabbitMQ
                // And deserialized when receive message from RabbitMQ
                bus.UseNewtonsoftJsonSerializer();

                bus.ConfigureNewtonsoftJsonSerializer(settings =>
                {
                    settings.Converters.Add(new TypeNameHandlingConverter(TypeNameHandling.Objects));
                    settings.Converters.Add(new DateOnlyJsonConverter());
                    settings.Converters.Add(new ExpirationDateOnlyJsonConverter());

                    return settings;
                });

                bus.ConfigureNewtonsoftJsonDeserializer(settings =>
                {
                    settings.Converters.Add(new TypeNameHandlingConverter(TypeNameHandling.Objects));
                    settings.Converters.Add(new DateOnlyJsonConverter());
                    settings.Converters.Add(new ExpirationDateOnlyJsonConverter());

                    return settings;
                });

                /*
                 * Tracing and loggin
                 * Những class để mình quản lý
                 * Ai đang lắng nghe - lắng nghe cái gì trên hệ thống của mình
                 * Ai đang consume - consumer cái gì
                 * Đã publish thông tin gì chưa?
                 * Đã send command gì chưa?
                 */

                bus.ConnectReceiveObserver(new LoggingReceiveObserver());
                bus.ConnectConsumeObserver(new LoggingConsumeObserver());
                bus.ConnectPublishObserver(new LoggingPublishObserver());
                bus.ConnectSendObserver(new LoggingSendObserver());

                // Rename for Root Exchange and setup Consume also
                // Exchange: MassTransitRabbitMQ.Contract.IntegrationEvents:
                // DomainEvent-SmsNotification ==> Exchange: sms-notification
                /*
                 * Chuyển đổi - set cho class cha => Phải dùng cái này
                 * => Dùng cho Root Exchange - Vì khi dùng Mass Transit nếu không quen thì nó tạo Exchange quá nhiều
                 * => Không quản lý được => Tuy không ảnh hưởng chương trình, nhưng nó tạo nhiều thôi
                 */
                bus.MessageTopology.SetEntityNameFormatter(new KebabCaseEntityNameFormatter());

                // =================== Setup for Consumer ===================

                // Important: Create Exchange and Queue
                bus.ConfigureEndpoints(context);
            });
        });

        return services;
    }

    // Configure Job
    public static void AddQuartzInfrastructure(this IServiceCollection services)
    {
        services.AddQuartz(configure =>
        {
            var jobKey = new JobKey(nameof(ProducerOutboxMessageJob));

            // Add job and trigger for this job
            // Mục đích: mỗi lần mình sẽ Push 20 message lên RabbitMQ
            configure
                .AddJob<ProducerOutboxMessageJob>(jobKey)
                .AddTrigger(trigger =>
                    trigger.ForJob(jobKey)
                    .WithSimpleSchedule(schedule =>
                    {
                        // Check lại Milisecond hay Microsecond - Trandong
                        schedule.WithInterval(TimeSpan.FromMilliseconds(100));
                        schedule.RepeatForever();
                    }));

            configure.UseMicrosoftDependencyInjectionJobFactory();
        });

        services.AddQuartzHostedService();
    }

    public static void AddMediatRInfrastructure(this IServiceCollection services)
    {
        // Tại sao ở đây lại có thêm Validator => MesssageBusOptions có các ràng buộc
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(AssemblyReference.Assembly));
    }

    public static WebApplicationBuilder AddOpenTelemetryInfrastructure(this WebApplicationBuilder builder)
    {
        var resourceBuilder = ResourceBuilder.CreateDefault()
               .AddService(serviceName: builder.Configuration.GetValue<string>("Otlp:ServiceName"));

        var logExporter = builder.Configuration.GetValue<string>("UseLogExporter").ToLowerInvariant();
        // Logging
        builder.Logging.AddOpenTelemetry(logging =>
        {
            // TODO: setup exporter here
            logging.SetResourceBuilder(resourceBuilder);
            switch (logExporter)
            {
                case "console":
                    logging.AddConsoleExporter();
                    break;
                case "otlp":
                    logging.SetResourceBuilder(ResourceBuilder.CreateDefault()
                        .AddService(serviceName: builder.Configuration.GetValue<string>("Otlp:ServiceName")));

                    logging.AddOtlpExporter(opt =>
                        opt.Endpoint = new Uri(builder.Configuration.GetValue<string>("Otlp:Endpoint")));
                    break;
                case "":
                case "none":
                    break;
            }
        });

        // Metrics
        var metricsExporter = builder.Configuration.GetValue<string>("UseMetricsExporter").ToLowerInvariant();

        builder.Services.AddOpenTelemetry()
            .WithMetrics(metrics =>
            {
                metrics.SetResourceBuilder(resourceBuilder)
                    .AddRuntimeInstrumentation()
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation();

                switch (metricsExporter)
                {
                    case "console":
                        metrics.AddConsoleExporter((exporterOptions, metricReaderOptions) =>
                        {
                            exporterOptions.Targets = ConsoleExporterOutputTargets.Console;

                            // The ConsoleMetricExporter defaults to a manual collect cycle.
                            // This configuration causes metrics to be exported to stdout on a 10s interval.
                            // metricReaderOptions.MetricReaderType = MetricReaderType.Periodic;
                            metricReaderOptions.PeriodicExportingMetricReaderOptions.ExportIntervalMilliseconds = 10000;
                        });
                        break;
                    case "otlp":
                        metrics.AddOtlpExporter(opt =>
                            opt.Endpoint = new Uri(builder.Configuration.GetValue<string>("Otlp:Endpoint")));
                        break;
                    case "":
                    case "none":
                        break;
                }
            });

        // Tracing
        var tracingExporter = builder.Configuration.GetValue<string>("UseTracingExporter").ToLowerInvariant();

        builder.Services.AddOpenTelemetry()
            .WithTracing(tracing =>
            {
                tracing
                    .SetResourceBuilder(resourceBuilder)
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation();

                switch (tracingExporter)
                {
                    case "console":
                        tracing.AddConsoleExporter();

                        // For options which can be bound from IConfiguration
                        builder.Services.Configure<AspNetCoreTraceInstrumentationOptions>(builder.Configuration.GetSection("AspNetCoreInstrumentation"));

                        // For options which can be configured from code only
                        builder.Services.Configure<AspNetCoreTraceInstrumentationOptions>(options =>
                            options.Filter = _ => true);

                        break;
                    case "otlp":
                        tracing.AddOtlpExporter(otlpOtions =>
                            otlpOtions.Endpoint = new Uri(builder.Configuration.GetValue<string>("Otlp:Endpoint")));
                        break;
                    case "":
                    case "none":
                        break;
                }
            });

        return builder;
    }
}
