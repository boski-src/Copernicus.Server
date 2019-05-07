using System.Threading.Tasks;
using Copernicus.Application.Identity.Auth;
using Copernicus.Application.Identity.Commands;
using Copernicus.Common.CQRS.Commands;

namespace Copernicus.Application.Identity.Handlers
{
    public class DestroySessionHandler : ICommandHandler<DestroySession>
    {
        private readonly ISessionService _sessionService;

        public DestroySessionHandler(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        public async Task Handle(DestroySession command)
        {
            await _sessionService.Destroy(command.BearerToken);
        }
    }
}