using System.Threading.Tasks;

namespace Copernicus.Common.CQRS.Commands
{
    public interface ICommandDispatcher
    {
        Task Dispatch<TCommand>(TCommand command) where TCommand : ICommand;
    }
}