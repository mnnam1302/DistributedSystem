using Carter;
using DistributedSystem.API.DependencyInjection.Extensions;
using DistributedSystem.API.Middleware;
using DistributedSystem.Application.DependencyInjection.Extensions;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add configuration

Log.Logger = new LoggerConfiguration().ReadFrom
    .Configuration(builder.Configuration)
    .CreateLogger();

builder.Logging
    .ClearProviders()
    .AddSerilog();

builder.Host.UseSerilog();

builder.Services.AddConfigureMediatR();
builder.Services.AddConfigureAutoMapper();

// Add Middleware => Remember use middleware
builder.Services.AddTransient<ExceptionHandlingMiddleware>();

// Add Carter module
builder.Services.AddCarter();

// Add Swagger
builder.Services
    .AddSwaggerGenNewtonsoftSupport()
    .AddFluentValidationRulesToSwagger()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

builder.Services
    .AddApiVersioning(options => options.ReportApiVersions = true)
    .AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });

var app = builder.Build();

// Using middleware
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment() || builder.Environment.IsStaging())
    app.ConfigureSwagger();

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapCarter();
//app.MapControllers();

try
{
    await app.RunAsync();
    Log.Information("Stop cleanly");
}
catch (Exception ex)
{
    Log.Fatal(ex, "An unhandled exception occured during bootstrapping");
}
finally
{
    Log.CloseAndFlush();
    await app.DisposeAsync();
}

public partial class Program { }
