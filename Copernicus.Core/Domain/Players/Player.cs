using System;
using Copernicus.Common.Types;

namespace Copernicus.Core.Domain.Players
{
    public class Player : IEntity
    {
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public string UserName { get; protected set; }
        public long WinGames { get; protected set; }
        public long TotalGames { get; protected set; }
        public long Score { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        public Player(Guid id, Guid userId, string userName)
        {
            Id = id;
            UserId = userId;
            UserName = userName;
            WinGames = 0;
            TotalGames = 0;
            Score = 0;
            CreatedAt = DateTime.UtcNow;
        }

        public void IncrementWinGames()
        {
            WinGames++;
        }

        public void IncrementTotalGames()
        {
            TotalGames++;
        }

        public void AddScore(long score)
        {
            Score += score;
        }
    }
}