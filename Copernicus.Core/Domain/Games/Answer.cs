using System;

namespace Copernicus.Core.Domain.Games
{
    public class Answer
    {
        public Guid QuestionId { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Value { get; set; }
        public bool IsCorrect { get; set; }

        public Answer()
        {
        }

        public Answer(Guid questionId, Guid userId, string userName, string value, bool isCorrect)
        {
            QuestionId = questionId;
            UserId = userId;
            UserName = userName;
            Value = value;
            IsCorrect = isCorrect;
        }
    }
}