using System.Threading.Tasks;
using Copernicus.Application.Questions.Queries;
using Copernicus.Common.CQRS.Queries;
using Copernicus.Common.Types;
using Copernicus.Core.Domain.Questions;
using Copernicus.Core.Repositories;

namespace Copernicus.Application.Questions.Handlers
{
    public class GetQuestionsHandler : IQueryHandler<GetQuestions, PagedList<Question>>
    {
        private readonly IQuestionRepository _questionRepository;

        public GetQuestionsHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<PagedList<Question>> Handle(GetQuestions query)
        {
            return await _questionRepository.FindManyPaginate(query);
        }
    }
}