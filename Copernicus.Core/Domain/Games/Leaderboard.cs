using System.Collections.Generic;

namespace Copernicus.Core.Domain.Games
{
    public class Leaderboard
    {
        private ISet<Winner> _winners = new HashSet<Winner>();
        public ISet<Winner> Winners { get => _winners; protected set => _winners = new HashSet<Winner>(value); }

        public Leaderboard()
        {
        }


        public void AddWinner(Winner winner)
        {
            if (Winners.Contains(winner))
                return;

            _winners.Add(winner);
        }
    }
}