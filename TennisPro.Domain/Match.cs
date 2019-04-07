using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisPro.Domain
{
    public class Match
    {
        #region Constructors
        public Match(string firstPlayer, string secondPlayer, int maxNumOfSets)
        {
            FirstPlayer = new Player { Name = firstPlayer };
            SecondPlayer = new Player { Name = secondPlayer };
            MaxSetsToPlay = maxNumOfSets;
            Sets = new List<Set>();
        }
        #endregion

        #region Properties
        public Player Winner { get; set; }
        public List<Set> Sets { get; private set; }
        public Player FirstPlayer { get; private set; }
        public Player SecondPlayer { get; private set; }
        public int MaxSetsToPlay { get; private set; }
        #endregion

        public bool IsFinished()
        {
            return SetsWonCount(FirstPlayer) == SetsToWinMatch()
                || SetsWonCount(SecondPlayer) == SetsToWinMatch();
        }
        
        public string GetCurrentSetScore()
        {
            return string.Format("{0}-{1}", SetsWonCount(FirstPlayer), SetsWonCount(SecondPlayer));
        }

        private int SetsToWinMatch()
        {
            return (MaxSetsToPlay / 2) + 1;
        }

        private int SetsWonCount(Player player)
        {
            return Sets.Count(x => x.Winner.Equals(player));
        }
    }
}
