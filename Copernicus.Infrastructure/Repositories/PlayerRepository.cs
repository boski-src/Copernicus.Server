using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Copernicus.Common.Mongo;
using Copernicus.Core.Domain.Players;
using Copernicus.Core.Repositories;
using MongoDB.Driver;

namespace Copernicus.Infrastructure.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly IMongoGenericRepository<Player> _repository;

        public PlayerRepository(IMongoGenericRepository<Player> repository)
        {
            _repository = repository;
        }

        public async Task Create(Player player)
        {
            await _repository.Create(player);
        }

        public async Task<Player> FindOne(Guid id)
        {
            return await _repository.FindOne(x => x.UserId == id);
        }

        public async Task<List<Player>> FindManyAndSortByScore(int limit)
        {
            return await _repository.Collection.Find(x => x.Score > 0)
                                    .SortByDescending(x => x.Score)
                                    .Limit(limit)
                                    .ToListAsync();
        }

        public async Task Update(Player player)
        {
            await _repository.Update(player);
        }

        public async Task Delete(Guid id)
        {
            await _repository.Delete(id);
        }
    }
}