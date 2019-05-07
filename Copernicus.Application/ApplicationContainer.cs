using Copernicus.Application.Games.Handlers;
using Copernicus.Common.CQRS;
using Copernicus.Common.CQRS.Events;
using Copernicus.Common.CQRS.Notifications;
using Copernicus.Common.FacebookClient;
using Copernicus.Common.TaskExecutor;
using Microsoft.Extensions.DependencyInjection;

namespace Copernicus.Application
{
    public static class ApplicationContainer
    {
        public static IServiceCollection AddApplicationContainer(this IServiceCollection services)
        {
            services.Scan(
                scan => scan
                        .FromAssemblies(typeof(ApplicationContainer).Assembly)
                        .AddClasses()
                        .AsImplementedInterfaces()
                        .WithTransientLifetime()
            );

            services.Scan(
                scan => {
                    scan.FromCallingAssembly()
                        .AddClasses(c => c.AssignableTo(typeof(INotificationHandler<>)))
                        .As(typeof(GenericGameNotificationHandler<>))
                        .WithTransientLifetime();
                }
            );

            services.RegisterHandlers();
            services.AddTaskExecutor();
            services.AddFacebookClient();

            return services;
        }
    }
}