using Copernicus.Common.CQRS.Queries;
using Copernicus.Common.Types;
using Copernicus.Core.Domain.Games;

namespace Copernicus.Application.Games.Queries
{
    public class GetGames : PagedListQuery, IQuery<PagedList<Game>>
    {
    }
}