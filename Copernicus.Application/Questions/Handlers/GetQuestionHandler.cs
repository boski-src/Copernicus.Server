using System.Threading.Tasks;
using Copernicus.Application.Questions.Queries;
using Copernicus.Common.CQRS.Queries;
using Copernicus.Core.Domain.Questions;
using Copernicus.Core.Repositories;

namespace Copernicus.Application.Questions.Handlers
{
    public class GetQuestionHandler : IQueryHandler<GetQuestion, Question>
    {
        private readonly IQuestionRepository _questionRepository;

        public GetQuestionHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<Question> Handle(GetQuestion query)
        {
            return await _questionRepository.FindOne(query.Id);
        }
    }
}