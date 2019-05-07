using Copernicus.Core.Domain.Questions;

namespace Copernicus.API.Dtos
{
    public class ChoiceDto
    {
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }
        public Translations Translations { get; set; }
    }
}