using System.Threading.Tasks;
using Copernicus.Common.CQRS.Events;
using Copernicus.Common.CQRS.Notifications;
using Copernicus.Infrastructure.Signalr;

namespace Copernicus.Application.Games.Handlers
{
    public class GenericGameNotificationHandler<TNotification> : INotificationHandler<TNotification>
        where TNotification : IGameNotification
    {
        private readonly IGameHubService _gameHubService;

        public GenericGameNotificationHandler(IGameHubService gameHubService)
        {
            _gameHubService = gameHubService;
        }

        public async Task Handle(TNotification @event)
        {
            await _gameHubService.Publish(@event);
        }
    }
}