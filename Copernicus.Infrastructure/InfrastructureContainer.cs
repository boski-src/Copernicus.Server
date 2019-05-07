using Microsoft.Extensions.DependencyInjection;

namespace Copernicus.Infrastructure
{
    public static class InfrastructureContainer
    {
        public static IServiceCollection AddInfrastructureContainer(this IServiceCollection services)
        {
            services.Scan(
                scan => scan
                        .FromAssemblies(typeof(InfrastructureContainer).Assembly)
                        .AddClasses()
                        .AsImplementedInterfaces()
                        .WithTransientLifetime()
            );

            return services;
        }
    }
}