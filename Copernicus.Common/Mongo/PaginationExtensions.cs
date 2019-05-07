using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Copernicus.Common.Types;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Copernicus.Common.Mongo
{
    public static class PaginationExtension
    {
        public static async Task<PagedList<TEntity>> PaginationAsync<TEntity>(this IMongoQueryable<TEntity> collection,
            Expression<Func<TEntity, bool>> criteria,
            int page,
            int limit)
            where TEntity : IEntity
        {
            var documentsCount = await collection.Where(criteria).CountAsync();
            if (documentsCount <= 0)
            {
                return new PagedList<TEntity>();
            }

            if (page <= 0) page = 1;
            if (limit <= 0) limit = 20;

            var pages = (int) Math.Ceiling((double) documentsCount / limit);
            var items = await collection.Where(criteria)
                                        .OrderByDescending(x => x.CreatedAt)
                                        .Skip((page - 1) * limit)
                                        .Take(limit)
                                        .ToListAsync();

            return new PagedList<TEntity>(items, page, limit, pages, documentsCount);
        }

        public static async Task<PagedList<TEntity>> PaginationAsync<TEntity>(this IMongoQueryable<TEntity> collection,
            Expression<Func<TEntity, bool>> criteria,
            PagedListQuery query) where TEntity : IEntity
        {
            return await PaginationAsync(collection, criteria, query.Page, query.Limit);
        }
    }
}