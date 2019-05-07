using System.Collections.Generic;
using Copernicus.Common.CQRS.Queries;
using Copernicus.Core.Domain.Players;

namespace Copernicus.Application.Players.Queries
{
    public class GetTopPlayers : IQuery<List<Player>>
    {
    }
}