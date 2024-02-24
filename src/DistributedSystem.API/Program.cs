using Carter;
using DistributedSystem.API.DependencyInjection.Extensions;
using DistributedSystem.API.Middleware;
using DistributedSystem.Application.DependencyInjection.Extensions;
using DistributedSystem.Persistence.DependencyInjection.Extensions;
using DistributedSystem.Persistence.DependencyInjection.Options;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add configuration

// Add Serilog
Log.Logger = new LoggerConfiguration().ReadFrom
    .Configuration(builder.Configuration)
    .CreateLogger();

builder.Logging
    .ClearProviders()
    .AddSerilog();

builder.Host.UseSerilog();

// Add Jwt Authentication => After, app.UseAuthentication(); app.UseAuthorization();
builder.Services.AddJwtAuthentication(builder.Configuration);

// Read more: use for situation that put Controller API at Presentation intead of API
//builder.
//    Services
//    .AddControllers()
//    .AddApplicationPart(DistributedSystem.Persistence.AssemblyReference.Assembly);

builder.Services.AddConfigureMediatR();
builder.Services.AddConfigureAutoMapper();

// Add Middleware => Remember use middleware
builder.Services.AddTransient<ExceptionHandlingMiddleware>();

// Configure Options and SQL =>  remember mapcarter
builder.Services.AddInterceptorDbContext();

// Pass Configuration good - builder.Configuration.GetSection(nameof(SqlServerRetryOptions))
// Not hard code at ConfigureSqlServerRetryOptions at Persistence ** My ERROR
builder.Services.ConfigureSqlServerRetryOptions(builder.Configuration.GetSection(nameof(SqlServerRetryOptions)));
builder.Services.AddSqlConfiguration();
builder.Services.AddRepositoryBaseConfiguration();

// Add Carter module
builder.Services.AddCarter();

// Add Swagger
builder.Services
    .AddSwaggerGenNewtonsoftSupport()
    .AddFluentValidationRulesToSwagger()
    .AddEndpointsApiExplorer()
    .AddSwagger();

// Add API versioning
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

// Add API endpoint with Carter module
app.MapCarter();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment() || builder.Environment.IsStaging())
    app.ConfigureSwagger(); // => After MapCarter => Show Version

//app.UseHttpsRedirection();

app.UseAuthentication(); // This to need added before UseAuthorization
app.UseAuthorization();

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
