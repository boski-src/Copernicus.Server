using System.Threading.Tasks;
using Copernicus.Application.Games.Commands;
using Copernicus.Application.Games.Events;
using Copernicus.Common.CQRS.Commands;
using Copernicus.Common.CQRS.Notifications;
using Copernicus.Core.Domain.Games;
using Copernicus.Core.Repositories;

namespace Copernicus.Application.Games.Handlers
{
    public class LeaveFromGameHandler : ICommandHandler<LeaveFromGame>
    {
        private readonly IGameService _gameService;
        private readonly INotificationBus _notificationBus;
        private readonly IUserRepository _userRepository;
        private readonly IGameRepository _gameRepository;

        public LeaveFromGameHandler(IGameService gameService,
            IUserRepository userRepository,
            INotificationBus notificationBus,
            IGameRepository gameRepository)
        {
            _gameService = gameService;
            _userRepository = userRepository;
            _notificationBus = notificationBus;
            _gameRepository = gameRepository;
        }

        public async Task Handle(LeaveFromGame command)
        {
            await _gameService.Leave(command.GameId, command.UserId);

            var game = await _gameRepository.FindOne(command.GameId);
            var user = await _userRepository.FindOne(command.UserId);

            await _notificationBus.Publish(new MemberLeft(command.GameId, user.Id, user.Name));
            if (game.State == States.Ended)
                await _notificationBus.Publish(new GameEnded(command.GameId));
        }
    }
}