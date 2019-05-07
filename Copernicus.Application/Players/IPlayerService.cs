using System;
using System.Threading.Tasks;
using Copernicus.Core.Domain.Games;

namespace Copernicus.Application.Players
{
    public interface IPlayerService
    {
        Task CreatePlayer(Guid userId, string userName);
        Task UpdateStatsByLeaderboard(Leaderboard leaderboard);
    }
}