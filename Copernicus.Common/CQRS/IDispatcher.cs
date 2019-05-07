using System.Threading.Tasks;
using Copernicus.Common.CQRS.Commands;
using Copernicus.Common.CQRS.Queries;

namespace Copernicus.Common.CQRS
{
    public interface IDispatcher
    {
        Task DispatchCommand<TCommand>(TCommand command) where TCommand : ICommand;
        Task<TResult> DispatchQuery<TResult>(IQuery<TResult> query);
    }
}