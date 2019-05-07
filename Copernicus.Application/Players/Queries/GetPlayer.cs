using System;
using Copernicus.Common.CQRS.Queries;
using Copernicus.Core.Domain.Players;

namespace Copernicus.Application.Players.Queries
{
    public class GetPlayer : IQuery<Player>
    {
        public Guid UserId { get; set; }
    }
}