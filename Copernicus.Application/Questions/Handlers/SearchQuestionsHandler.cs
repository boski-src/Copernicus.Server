using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Copernicus.Application.Questions.Queries;
using Copernicus.Common.CQRS.Queries;
using Copernicus.Core.Domain.Questions;
using Copernicus.Core.Repositories;

namespace Copernicus.Application.Questions.Handlers
{
    public class SearchQuestionsHandler : IQueryHandler<SearchQuestions, List<Question>>
    {
        private readonly IQuestionRepository _questionRepository;

        public SearchQuestionsHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<List<Question>> Handle(SearchQuestions query)
        {
            return await _questionRepository.FindManyByKeyword(query.Q);
        }
    }
}