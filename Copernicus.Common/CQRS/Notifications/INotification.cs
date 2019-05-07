using System;

namespace Copernicus.Common.CQRS.Notifications
{
    public interface INotification
    {
    }

    public interface IGameNotification : INotification
    {
        Guid GameId { get; set; }
    }
}