using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Copernicus.Core.Domain.Questions;

namespace Copernicus.Application.Questions
{
    public interface IQuestionService
    {
        Task Create(Question newQuestion);
        Task Create(Guid id, string query, string image, long time, ISet<Choice> choices, Translations translations);
        Task Create(Guid id, string query, long time, ISet<Choice> choices, Translations translations);
        Task Update(Guid id, string query, string image, long time, ISet<Choice> choices, Translations translations);
        Task Delete(Guid id);
    }
}