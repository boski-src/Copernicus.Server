using System;
using System.Collections.Generic;
using System.Linq;
using Copernicus.Core.Domain.Questions;

namespace Copernicus.Core.Domain.Games
{
    public class GameQuestion
    {
        public Guid Id { get; set; }
        public int OrderIndex { get; set; }
        public string Query { get; set; }
        public string Image { get; set; }
        public long Time { get; set; }
        public Translations Translations { get; set; }
        public ISet<Choice> Choices { get; set; }

        public GameQuestion()
        {
        }

        public GameQuestion(Guid id,
            int orderIndex,
            string query,
            string image,
            long time,
            ISet<Choice> choices,
            Translations translations)
        {
            Id = id;
            OrderIndex = orderIndex;
            Query = query;
            Image = image;
            Time = time;
            Choices = choices;
            Translations = translations;
        }

        public bool ValidateAnswer(string value)
        {
            var correctAnswers = Choices.Where(x => x.IsCorrect).Select(x => x.Answer);
            return correctAnswers.Any(x => x == value);
        }

        public static GameQuestion FromInstance(Question question, int orderIndex) => new GameQuestion(
            question.Id,
            orderIndex,
            question.Query,
            question.Image,
            question.Time,
            question.Choices,
            question.Translations
        );
    }
}