using System;

namespace Copernicus.Core.Domain.Games
{
    public class Winner
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public int Score { get; set; }

        public Winner()
        {
        }

        public Winner(Guid userId, string userName, int score)
        {
            UserId = userId;
            UserName = userName;
            Score = score;
        }
    }
}