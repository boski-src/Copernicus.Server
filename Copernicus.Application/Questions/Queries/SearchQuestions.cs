using System.Collections.Generic;
using Copernicus.Common.CQRS.Queries;
using Copernicus.Core.Domain.Questions;

namespace Copernicus.Application.Questions.Queries
{
    public class SearchQuestions : IQuery<List<Question>>
    {
        public string Q { get; set; }
    }
}