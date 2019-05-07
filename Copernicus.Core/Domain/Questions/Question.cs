using System;
using System.Collections.Generic;
using Copernicus.Common.Types;

namespace Copernicus.Core.Domain.Questions
{
    public class Question : IEntity
    {
        private ISet<Choice> _choices = new HashSet<Choice>();

        public Guid Id { get; protected set; }
        public string Query { get; protected set; }
        public string Image { get; protected set; }
        public long Time { get; protected set; }
        public Translations Translations { get; protected set; }

        public ISet<Choice> Choices { get => _choices; protected set => SetChoices(value); }

        public DateTime CreatedAt { get; protected set; }

        protected Question()
        {
        }

        protected Question(Guid id, string query, string image, long time, Translations translations)
        {
            SetId(id);
            SetQuery(query);
            Image = image;
            SetTime(time);
            CreatedAt = DateTime.UtcNow;
            Translations = translations;
        }

        #region Setters

        public void SetId(Guid id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
                throw new DomainException("GUID is required.");

            Id = id;
        }

        public void SetQuery(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                throw new DomainException("Question content is required.");

            Query = query;
        }


        public void SetImage(string image)
        {
            Image = image;
        }

        public void SetTime(long time)
        {
            if (time < 10000)
                throw new DomainException("Time cannot be number under 10 000.");

            Time = time;
        }

        public void SetChoices(ISet<Choice> choices)
        {
            _choices = new HashSet<Choice>(choices);
        }

        public void SetTranslations(Translations translations)
        {
            Translations = translations;
        }

        #endregion

        public void AddChoice(Choice choice)
        {
            _choices.Add(choice);
        }

        public static Question Create(Guid id, string query, long time, Translations translations)
            => new Question(id, query, string.Empty, time, translations);

        public static Question CreateWithImage(
            Guid id,
            string query,
            string image,
            long time,
            Translations translations) => new Question(id, query, image, time, translations);
    }
}
