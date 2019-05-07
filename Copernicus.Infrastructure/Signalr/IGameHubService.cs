using System.Threading.Tasks;
using Copernicus.Common.CQRS.Events;
using Copernicus.Common.CQRS.Notifications;

namespace Copernicus.Infrastructure.Signalr
{
    public interface IGameHubService
    {
        Task Publish<TNotification>(TNotification notification) where TNotification : IGameNotification;
    }
}