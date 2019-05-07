using System;
using System.Threading.Tasks;
using Copernicus.Common.Mongo;
using Copernicus.Common.Types;
using Copernicus.Core.Domain.Games;
using Copernicus.Core.Repositories;
using MongoDB.Driver;

namespace Copernicus.Infrastructure.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly IMongoGenericRepository<Game> _repository;

        public GameRepository(IMongoGenericRepository<Game> repository)
        {
            _repository = repository;
        }

        public async Task Create(Game game)
        {
            await _repository.Create(game);
        }

        public async Task<Game> FindOne(Guid id)
        {
            return await _repository.FindOne(id);
        }

        public async Task<Game> FindOneByCode(string code)
        {
            return await _repository.FindOne(x => x.Code == code);
        }

        public async Task<PagedList<Game>> FindManyWaiting(PagedListQuery query)
        {
            return await _repository
                         .Collection
                         .AsQueryable()
                         .PaginationAsync(x => x.State == States.Waiting, query);
        }

        public async Task Update(Game game)
        {
            await _repository.Update(game);
        }

        public async Task Delete(Guid id)
        {
            await _repository.Delete(id);
        }
    }
}