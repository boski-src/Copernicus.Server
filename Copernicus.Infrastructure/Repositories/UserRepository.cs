using System;
using System.Threading.Tasks;
using Copernicus.Common.Mongo;
using Copernicus.Core.Domain.Identity;
using Copernicus.Core.Repositories;
using MongoDB.Driver;

namespace Copernicus.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoGenericRepository<User> _repository;

        public UserRepository(IMongoGenericRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task Create(User user)
        {
            await _repository.Create(user);
        }

        public async Task<User> FindOne(Guid id)
        {
            return await _repository.FindOne(id);
        }

        public async Task<User> FindOneByEmail(string email)
        {
            return await _repository.FindOne(x => x.Email == email);
        }

        public async Task<User> FindOneByProvider(string providerName, string providerId)
        {
            var fileter = Builders<User>.Filter.And(
                Builders<User>.Filter.Where(x => x.ProviderName == providerName),
                Builders<User>.Filter.Where(x => x.ProviderId == providerId)
            );

            return await _repository.FindOne(fileter);
        }

        public async Task Update(User user)
        {
            await _repository.Update(user);
        }
    }
}