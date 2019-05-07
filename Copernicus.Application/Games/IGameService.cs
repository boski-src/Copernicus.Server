using System;
using System.Threading.Tasks;
using Copernicus.Core.Domain.Games;

namespace Copernicus.Application.Games
{
    public interface IGameService
    {
        Task Create(Guid id, Guid userId, string name, string primaryLanguage, int maxQuestions);
        Task Start(Guid id, Guid userId);
        Task End(Guid id, Guid userId);
        Task LeaderboardCalculate(Guid id);
        Task Join(Guid id, Guid userId);
        Task Leave(Guid id, Guid userId);
        Task<Answer> CreateAnswer(Guid id, Guid questionId, Guid userId, string answerValue);
        Task<Guid> NextQuestion(Guid id, Guid userId);
    }
}