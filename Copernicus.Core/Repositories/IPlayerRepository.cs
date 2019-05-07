using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Copernicus.Core.Domain.Players;

namespace Copernicus.Core.Repositories
{
    public interface IPlayerRepository
    {
        Task Create(Player player);
        Task<Player> FindOne(Guid userId);
        Task<List<Player>> FindManyAndSortByScore(int limit);
        Task Update(Player player);
        Task Delete(Guid id);
    }
}