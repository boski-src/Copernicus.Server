using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Copernicus.Common.Types;
using MongoDB.Driver;

namespace Copernicus.Common.Mongo
{
    public class MongoGenericRepository<TEntity> : IMongoGenericRepository<TEntity> where TEntity : IEntity
    {
        public IMongoCollection<TEntity> Collection { get; set; }

        public MongoGenericRepository(IMongoCollection<TEntity> collection)
        {
            Collection = collection;
        }

        public async Task Create(TEntity entity)
        {
            await Collection.InsertOneAsync(entity);
        }

        public async Task<TEntity> FindOne(Guid id)
        {
            return await FindOne(x => x.Id == id);
        }

        public async Task<TEntity> FindOne(Expression<Func<TEntity, bool>> criteria)
        {
            return await Collection.Find(criteria).SingleOrDefaultAsync();
        }

        public async Task<TEntity> FindOne(FilterDefinition<TEntity> filter)
        {
            return await Collection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<List<TEntity>> Browse(Expression<Func<TEntity, bool>> criteria)
        {
            return await Collection.Find(criteria).SortByDescending(x => x.CreatedAt).ToListAsync();
        }

        public async Task<List<TEntity>> Browse(FilterDefinition<TEntity> filter)
        {
            return await Collection.Find(filter).SortByDescending(x => x.CreatedAt).ToListAsync();
        }

        public async Task Update(TEntity entity)
        {
            await Collection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
        }

        public async Task Delete(Guid id)
        {
            await Collection.DeleteOneAsync(x => x.Id == id);
        }
    }
}