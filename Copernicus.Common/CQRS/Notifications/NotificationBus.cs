using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Copernicus.Common.CQRS.Notifications
{
    public class NotificationBus : INotificationBus
    {
        private readonly IServiceProvider _serviceProvider;

        public NotificationBus(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Publish<TNotification>(TNotification notification) where TNotification : INotification
        {
            var handlers = _serviceProvider.GetServices<INotificationHandler<TNotification>>();

            foreach (var handler in handlers)
            {
                await handler.Handle(notification);
            }
        }
    }
}