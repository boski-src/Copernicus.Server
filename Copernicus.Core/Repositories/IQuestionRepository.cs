using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Copernicus.Common.Types;
using Copernicus.Core.Domain.Questions;

namespace Copernicus.Core.Repositories
{
    public interface IQuestionRepository
    {
        Task Create(Question question);
        Task<Question> FindOne(Guid id);
        Task<List<Question>> FindManyRandom(int maxLength);
        Task<PagedList<Question>> FindManyPaginate(PagedListQuery query);
        Task<List<Question>> FindManyByKeyword(string query);
        Task Update(Question question);
        Task Delete(Guid id);
    }
}