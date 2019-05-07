using System;
using Copernicus.Common.CQRS.Queries;
using Copernicus.Core.Domain.Games;

namespace Copernicus.Application.Games.Queries
{
    public class GetGameDetails : IQuery<Game>
    {
        public Guid Id { get; set; }
    }
}