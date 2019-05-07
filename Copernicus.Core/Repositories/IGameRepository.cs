using System;
using System.Threading.Tasks;
using Copernicus.Common.Types;
using Copernicus.Core.Domain.Games;

namespace Copernicus.Core.Repositories
{
    public interface IGameRepository
    {
        Task Create(Game game);
        Task<Game> FindOne(Guid id);
        Task<Game> FindOneByCode(string code);
        Task<PagedList<Game>> FindManyWaiting(PagedListQuery query);
        Task Update(Game game);
        Task Delete(Guid id);
    }
}