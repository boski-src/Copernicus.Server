using System.Threading.Tasks;

namespace Copernicus.Common.CQRS.Events
{
    public interface IEventBus
    {
        Task Publish<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}