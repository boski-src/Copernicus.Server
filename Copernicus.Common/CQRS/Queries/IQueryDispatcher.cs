using System.Threading.Tasks;

namespace Copernicus.Common.CQRS.Queries
{
    public interface IQueryDispatcher
    {
        Task<TResult> Dispatch<TResult>(IQuery<TResult> query);
    }
}