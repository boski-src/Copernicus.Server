using System;

namespace Copernicus.Common.Types
{
    public interface IEntity
    {
        Guid Id { get; }
        DateTime CreatedAt { get; }
    }
}