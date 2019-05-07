using System.Threading.Tasks;
using Copernicus.Common.CQRS.Events;
using Copernicus.Common.CQRS.Notifications;
using Copernicus.Common.Signalr;

namespace Copernicus.Infrastructure.Signalr
{
    public class GameHubService : IGameHubService
    {
        private readonly IPublishProvider<GameHub> _publisher;

        public GameHubService(IPublishProvider<GameHub> publishProvider)
        {
            _publisher = publishProvider;
        }

        public async Task Publish<TNotification>(TNotification notification) where TNotification : IGameNotification
        {
            await _publisher.PublishToGroupAsync(notification.GameId.ToGameGroup(), notification);
        }
    }
}