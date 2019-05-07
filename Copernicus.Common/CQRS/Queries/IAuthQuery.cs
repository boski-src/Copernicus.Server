using System;

namespace Copernicus.Common.CQRS.Queries
{
    public interface IAuthQuery<T> : IQuery<T>
    {
        Guid UserId { get; set; }
    }
}