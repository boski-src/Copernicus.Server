using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Copernicus.Common.Signalr
{
    public interface IPublishProvider<THub> where THub : Hub
    {
        IHubContext<THub> Context { get; }
        Task PublishToUserAsync<T>(string userName, object data);
        Task PublishToGroupAsync<T>(string groupName, T data);
        Task PublishToAllAsync(string message, object data);
    }
}