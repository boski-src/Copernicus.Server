using System;
using Copernicus.Common.CQRS.Queries;
using Copernicus.Core.Domain.Identity;

namespace Copernicus.Application.Identity.Queries
{
    public class GetAccount : IAuthQuery<User>
    {
        public Guid UserId { get; set; }
    }
}