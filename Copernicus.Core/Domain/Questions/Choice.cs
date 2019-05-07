namespace Copernicus.Core.Domain.Questions
{
    public class Choice
    {
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }
        public Translations Translations { get; set; }

        public Choice()
        {
        }

        public Choice(string answer, bool isCorrect, Translations translations)
        {
            Answer = answer;
            IsCorrect = isCorrect;
            Translations = translations;
        }
    }
}