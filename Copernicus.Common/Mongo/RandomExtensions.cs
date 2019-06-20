using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Copernicus.Common.Types;
using MongoDB.Driver.Linq;

namespace Copernicus.Common.Mongo
{
    public static class RandomExtensions
    {
        public static async Task<List<TEntity>> RandomAsync<TEntity>(this IMongoQueryable<TEntity> collection,
            Expression<Func<TEntity, bool>> criteria,
            int max)
            where TEntity : IEntity
        {
            var added = new HashSet<TEntity>();

            var documentsCount = await collection.Where(criteria).CountAsync();
            if (documentsCount <= 0)
            {
                return added.ToList();
            }
                
            if (documentsCount < max)
            {
                max = documentsCount;
            }

            var random = new Random();

            for (int i = 0; i < max;)
            {
                var randomNumber = random.Next(documentsCount);

                var item = await collection.Where(criteria).Skip(randomNumber).FirstAsync();
                var exisiting = added.FirstOrDefault(x => x.Id == item.Id);

                Console.WriteLine(item.Id);

                if (exisiting == null)
                {
                    added.Add(item);
                    i++;
                }
            }

            return added.Distinct().ToList();
        }
    }
}
