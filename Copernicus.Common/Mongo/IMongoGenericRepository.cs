using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Copernicus.Common.Types;
using MongoDB.Driver;

namespace Copernicus.Common.Mongo
{
    public interface IMongoGenericRepository<TEntity> where TEntity : IEntity
    {
        IMongoCollection<TEntity> Collection { get; set; }

        Task Create(TEntity entity);
        Task<TEntity> FindOne(Guid id);
        Task<TEntity> FindOne(Expression<Func<TEntity, bool>> criteria);
        Task<TEntity> FindOne(FilterDefinition<TEntity> filter);
        Task<List<TEntity>> Browse(Expression<Func<TEntity, bool>> criteria);
        Task<List<TEntity>> Browse(FilterDefinition<TEntity> filter);
        Task Update(TEntity entity);
        Task Delete(Guid id);
    }
}