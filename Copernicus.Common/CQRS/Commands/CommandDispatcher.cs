using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Copernicus.Common.CQRS.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Dispatch<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = _serviceProvider.GetService<ICommandHandler<TCommand>>();

            await handler.Handle(command);
        }
    }
}