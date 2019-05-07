using System;
using Copernicus.Common.CQRS.Queries;
using Copernicus.Core.Domain.Identity;

namespace Copernicus.Application.Identity.Queries
{
    public class GetUser : IQuery<User>
    {
        public Guid UserId { get; set; }
    }
}