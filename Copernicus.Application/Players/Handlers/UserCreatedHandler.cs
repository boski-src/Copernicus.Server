using System.Threading.Tasks;
using Copernicus.Application.Identity.Events;
using Copernicus.Common.CQRS.Events;

namespace Copernicus.Application.Players.Handlers
{
    public class UserCreatedHandler : IEventHandler<UserCreated>
    {
        private readonly IPlayerService _playerService;

        public UserCreatedHandler(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public async Task Handle(UserCreated @event)
        {
            await _playerService.CreatePlayer(@event.UserId, @event.UserName);
        }
    }
}