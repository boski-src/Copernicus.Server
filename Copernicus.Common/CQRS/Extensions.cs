using System;
using System.Collections.Generic;
using Copernicus.Common.CQRS.Commands;
using Copernicus.Common.CQRS.Events;
using Copernicus.Common.CQRS.Notifications;
using Copernicus.Common.CQRS.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Copernicus.Common.CQRS
{
    public static class Extensions
    {
        public static IServiceCollection AddCQRS(this IServiceCollection services)
        {
            services.AddTransient<ICommandDispatcher, CommandDispatcher>();
            services.AddTransient<IQueryDispatcher, QueryDispatcher>();
            services.AddTransient<IEventBus, EventBus>();
            services.AddTransient<INotificationBus, NotificationBus>();
            services.AddTransient<IDispatcher, Dispatcher>();

            return services;
        }

        public static IServiceCollection RegisterHandlers(this IServiceCollection services)
        {
            services.Scan(
                scan => {
                    scan.FromCallingAssembly()
                        .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                        .AsImplementedInterfaces()
                        .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                        .AsImplementedInterfaces()
                        .AddClasses(c => c.AssignableTo(typeof(IEventHandler<>)))
                        .AsImplementedInterfaces()
                        .AddClasses(c => c.AssignableTo(typeof(INotificationHandler<>)))
                        .AsImplementedInterfaces();
                }
            );

            return services;
        }
    }
}