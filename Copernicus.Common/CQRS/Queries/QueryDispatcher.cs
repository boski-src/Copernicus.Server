using System;
using System.Threading.Tasks;

namespace Copernicus.Common.CQRS.Queries
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResult> Dispatch<TResult>(IQuery<TResult> query)
        {
            var type = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
            dynamic handler = _serviceProvider.GetService(type);

            return await handler.Handle((dynamic) query);
        }
    }
}