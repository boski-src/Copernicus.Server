namespace Copernicus.Core.Domain.Questions
{
    public class Translations
    {
        public string Pl { get; set; }
        public string En { get; set; }

        public Translations()
        {
        }

        public Translations(string pl, string en)
        {
            Pl = pl;
            En = en;
        }
    }
}