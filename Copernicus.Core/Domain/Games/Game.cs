using System;
using System.Collections.Generic;
using System.Linq;
using Copernicus.Common.Types;
using FluentValidation.Resources;

namespace Copernicus.Core.Domain.Games
{
    public class Game : IEntity
    {
        private ISet<Member> _members = new HashSet<Member>();
        private ISet<GameQuestion> _questions = new HashSet<GameQuestion>();
        private ISet<Answer> _answers = new HashSet<Answer>();

        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Code { get; protected set; }
        public string State { get; protected set; }
        public string PrimaryLanguage { get; protected set; }
        public Guid CurrentQuestionId { get; protected set; }
        public Leaderboard Leaderboard { get; protected set; }

        public ISet<Member> Members { get => _members; protected set => _members = new HashSet<Member>(value); }
        public ISet<GameQuestion> Questions { get => _questions; protected set => _questions = new HashSet<GameQuestion>(value); }
        public ISet<Answer> Answers { get => _answers; protected set => _answers = new HashSet<Answer>(value); }

        public DateTime CreatedAt { get; protected set; }

        public Game()
        {
        }

        public Game(Guid id,
            string name,
            string primaryLanguage,
            string code,
            Guid creatorId,
            string creatorName,
            string creatorAvatarUrl)
        {
            SetId(id);
            SetName(name);
            SetCode(code);
            PrimaryLanguage = primaryLanguage;
            AddMember(Member.CreateFromCreator(creatorId, creatorName, creatorAvatarUrl));
            State = States.Waiting;
            Leaderboard = new Leaderboard();
            CreatedAt = DateTime.UtcNow;
        }

        #region Setters

        public void SetId(Guid id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                throw new DomainException("GUID is required.");
            }

            Id = id;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new DomainException("Name is required.");
            }

            Name = name;
        }

        public void SetCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new DomainException("Code is required.");
            }

            Code = code;
        }

        public void SetCurrentQuestion(Guid currentQuestionId)
        {
            if (State == States.Waiting)
                throw new DomainException("Game has waiting.");

            CurrentQuestionId = currentQuestionId;
        }

        public void SetLeaderboard(Leaderboard leaderboard)
        {
            if (State == States.Waiting)
                throw new DomainException("Game has waiting.");

            Leaderboard = leaderboard;
        }

        #endregion

        public void Start()
        {
            if (State == States.Started)
                throw new DomainException("Game already ended.");

            if (Members.Count <= 1)
                throw new DomainException("Cannot start alone game.");

            State = States.Started;
        }

        public void End()
        {
            if (State == States.Ended)
                throw new DomainException("Game already ended.");

            State = States.Ended;
        }

        public void AddAnswer(Answer answer)
        {
            if (State == States.Waiting)
                throw new DomainException("Game is waiting.");

            if (State == States.Ended)
                throw new DomainException("Game has ended.");

            _answers.Add(answer);
        }

        public void AddQuestion(GameQuestion question)
        {
            _questions.Add(question);
        }

        public void AddMember(Member member)
        {
            if (IsMember(member.UserId))
                return;

            if (State == States.Started)
                throw new DomainException("Cannot join to game when was started.");

            if (State == States.Ended)
                throw new DomainException("Cannot join to game when was ended.");

            _members.Add(member);
        }

        public void RemoveMember(Member member)
        {
            var memberToDelete = _members.FirstOrDefault(x => x.UserId == member.UserId);
            _members.Remove(memberToDelete);
        }

        public bool IsMember(Guid userId)
        {
            return _members.FirstOrDefault(x => x.UserId == userId) != null;
        }
    }
}
