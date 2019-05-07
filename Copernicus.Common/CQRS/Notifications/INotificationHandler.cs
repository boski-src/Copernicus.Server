using System.Threading.Tasks;

namespace Copernicus.Common.CQRS.Notifications
{
    public interface INotificationHandler<in TNotification> where TNotification : INotification
    {
        Task Handle(TNotification notification);
    }
}