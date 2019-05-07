using System.Threading.Tasks;
using Copernicus.Application.Identity.Auth;
using Copernicus.Application.Identity.Commands;
using Copernicus.Common.CQRS.Commands;

namespace Copernicus.Application.Identity.Handlers
{
    public class RefreshSessionHandler : ICommandHandler<RefreshSession>
    {
        private readonly ISessionService _sessionService;

        public RefreshSessionHandler(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        public async Task Handle(RefreshSession command)
        {
            await _sessionService.Refresh(command.BearerToken);
        }
    }
}