using System;

namespace Copernicus.API.Dtos
{
    public class AnswerDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Value { get; set; }
        public bool IsCorrect { get; set; }
    }
}