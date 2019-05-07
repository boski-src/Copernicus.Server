using System.Threading.Tasks;

namespace Copernicus.Common.CQRS.Notifications
{
    public interface INotificationBus
    {
        Task Publish<TNotification>(TNotification notification) where TNotification : INotification;
    }
}