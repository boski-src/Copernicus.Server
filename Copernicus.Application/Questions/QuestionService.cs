using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Copernicus.Core.Domain.Questions;
using Copernicus.Core.Repositories;

namespace Copernicus.Application.Questions
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task Create(Question newQuestion)
        {
            var question = await _questionRepository.FindOne(newQuestion.Id);
            if (question != null)
                throw new QuestionServiceExceptions.AlreadyExists();

            await _questionRepository.Create(newQuestion);
        }

        public async Task Create(Guid id,
            string query,
            string image,
            long time,
            ISet<Choice> choices,
            Translations translations)
        {
            var question = Question.CreateWithImage(id, query, image, time, translations);
            question.SetChoices(choices);

            await Create(question);
        }

        public async Task Create(Guid id, string query, long time, ISet<Choice> choices, Translations translations)
        {
            var question = Question.Create(id, query, time, translations);
            question.SetChoices(choices);

            await Create(question);
        }

        public async Task Update(Guid id,
            string query,
            string image,
            long time,
            ISet<Choice> choices,
            Translations translations)
        {
            var question = await _questionRepository.FindOne(id);
            if (question == null)
                throw new QuestionServiceExceptions.NotFound();

            question.SetQuery(query);
            question.SetImage(image);
            question.SetTime(time);
            question.SetChoices(choices);
            question.SetTranslations(translations);

            await _questionRepository.Update(question);
        }

        public async Task Delete(Guid id)
        {
            var question = await _questionRepository.FindOne(id);
            if (question == null)
                throw new QuestionServiceExceptions.NotFound();

            await _questionRepository.Delete(id);
        }
    }
}