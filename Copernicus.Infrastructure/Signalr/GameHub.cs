using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace Copernicus.Infrastructure.Signalr
{
    public class GameHub : Hub
    {
        private readonly ILogger<GameHub> _logger;

        public GameHub(ILogger<GameHub> logger)
        {
            _logger = logger;
        }

        public override Task OnConnectedAsync()
        {
            _logger.LogDebug($"[+] {Context.ConnectionId}");
            return Task.CompletedTask;
        }

        public async Task JoinToGame(Guid gameId)
            => await Groups.AddToGroupAsync(Context.ConnectionId, gameId.ToGameGroup());

        public async Task LeaveFromGame(Guid gameId)
            => await Groups.RemoveFromGroupAsync(Context.ConnectionId, gameId.ToGameGroup());
    }
}