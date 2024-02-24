using DistributedSystem.Application.Abstractions;
using DistributedSystem.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace DistributedSystem.Infrastructure.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<IJwtTokenService, JwtTokenService>();
        }
    }
}