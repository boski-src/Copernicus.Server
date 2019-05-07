using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Copernicus.Common.Signalr
{
    public class PublishProvider<THub> : IPublishProvider<THub> where THub : Hub
    {
        public IHubContext<THub> Context { get; }

        public PublishProvider(IHubContext<THub> hubContext)
        {
            Context = hubContext;
        }

        public async Task PublishToUserAsync<T>(string userName, object data)
            => await Context.Clients.Group(userName).SendAsync(typeof(T).Name, data);

        public async Task PublishToGroupAsync<T>(string groupName, T data)
            => await Context.Clients.Group(groupName).SendAsync(typeof(T).Name, data);

        public async Task PublishToAllAsync(string message, object data)
            => await Context.Clients.All.SendAsync(message, data);
    }
}