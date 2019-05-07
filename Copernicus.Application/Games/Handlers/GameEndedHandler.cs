using System.Threading.Tasks;
using Copernicus.Application.Games.Events;
using Copernicus.Common.CQRS.Events;
using Copernicus.Common.CQRS.Notifications;
using Copernicus.Common.TaskExecutor;

namespace Copernicus.Application.Games.Handlers
{
    public class GameEndedHandler : IEventHandler<GameEnded>
    {
        private readonly IGameService _gameService;
        private readonly IEventBus _bus;
        private readonly INotificationBus _notificationBus;

        public GameEndedHandler(IGameService gameService, IEventBus bus, INotificationBus notificationBus)
        {
            _gameService = gameService;
            _bus = bus;
            _notificationBus = notificationBus;
        }

        public async Task Handle(GameEnded @event)
        {
            await _gameService.LeaderboardCalculate(@event.GameId);
            
            await _notificationBus.Publish(new LeaderboardCalculated(@event.GameId));
            await _bus.Publish(new LeaderboardCalculated(@event.GameId));
        }
    }
}