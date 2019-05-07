using System;
using Copernicus.Common.CQRS.Queries;
using Copernicus.Core.Domain.Games;

namespace Copernicus.Application.Games.Queries
{
    public class GetGame : IAuthQuery<Game>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}