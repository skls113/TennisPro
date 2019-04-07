using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisPro.Domain.Abstracts;

namespace TennisPro.Domain
{
    public class Set
    {
        #region Properties
        public Player Winner { get; set; }
        public Match Match { get; set; }
        public List<Game> Games { get; set; }
        public string Score { get; set; } 
        #endregion

        #region Constructors
        public Set()
        {
            Games = new List<Game>();
        }
        #endregion

        public bool IsFinished()
        {
            int wonCountFirstPlayer = GamesWonCount(Match.FirstPlayer);
            int wonCountSecondPlayer = GamesWonCount(Match.SecondPlayer);

            bool isFinished = 
             (Math.Abs(wonCountFirstPlayer - wonCountSecondPlayer) >= 2
                        && (wonCountFirstPlayer == 6 || wonCountSecondPlayer == 6))
                || (wonCountFirstPlayer == 7 || wonCountSecondPlayer == 7);

            return isFinished;
        }

        public string GetCurrentGameScore()
        {
            return string.Format("{0}-{1}", GamesWonCount(Match.FirstPlayer), GamesWonCount(Match.SecondPlayer));
        }

        private int GamesWonCount(Player player)
        {
            return Games.Count(x => x.Winner.Equals(player));
        }

    }
}
