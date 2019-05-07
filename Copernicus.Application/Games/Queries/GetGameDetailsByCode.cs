using Copernicus.Common.CQRS.Queries;
using Copernicus.Core.Domain.Games;

namespace Copernicus.Application.Games.Queries
{
    public class GetGameDetailsByCode : IQuery<Game>
    {
        public string Code { get; set; }
    }
}