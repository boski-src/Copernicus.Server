using Copernicus.Common.CQRS.Queries;
using Copernicus.Common.Types;
using Copernicus.Core.Domain.Questions;

namespace Copernicus.Application.Questions.Queries
{
    public class GetQuestions : PagedListQuery, IQuery<PagedList<Question>>
    {
    }
}