using System.Threading.Tasks;
using Copernicus.Common.CQRS.Commands;
using Copernicus.Common.CQRS.Queries;

namespace Copernicus.Common.CQRS
{
    public class Dispatcher : IDispatcher
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public Dispatcher(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        public async Task DispatchCommand<TCommand>(TCommand command) where TCommand : ICommand
        {
            await _commandDispatcher.Dispatch(command);
        }

        public async Task<TResult> DispatchQuery<TResult>(IQuery<TResult> query)
        {
            return await _queryDispatcher.Dispatch(query);
        }
    }
}