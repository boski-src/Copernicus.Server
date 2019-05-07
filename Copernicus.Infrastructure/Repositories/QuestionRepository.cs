using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Copernicus.Common.Mongo;
using Copernicus.Common.Types;
using Copernicus.Core.Domain.Questions;
using Copernicus.Core.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Copernicus.Infrastructure.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly IMongoGenericRepository<Question> _repository;

        public QuestionRepository(IMongoGenericRepository<Question> repository)
        {
            _repository = repository;
        }

        public async Task Create(Question question)
        {
            await _repository.Create(question);
        }

        public async Task<Question> FindOne(Guid id)
        {
            return await _repository.FindOne(id);
        }

        public async Task<List<Question>> FindManyRandom(int maxLength)
        {
            return await _repository.Collection.AsQueryable().RandomAsync(x => true, maxLength);
        }

        public async Task<PagedList<Question>> FindManyPaginate(PagedListQuery query)
        {
            return await _repository.Collection.AsQueryable().PaginationAsync(x => true, query);
        }

        public async Task<List<Question>> FindManyByKeyword(string query)
        {
            var filter = Builders<Question>.Filter.Regex("query", $"({query})");

            return await _repository.Collection.Find(filter).ToListAsync();
        }

        public async Task Update(Question question)
        {
            await _repository.Update(question);
        }

        public async Task Delete(Guid id)
        {
            await _repository.Delete(id);
        }
    }
}