using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisPro.Domain.Abstracts;

namespace TennisPro.Domain
{
    public class TiebreakGame : Game
    {
        //Tiebreak´s minimum score is 6-0
        const int MinRalliesToWinGame = 6;

        public override bool IsFinished()
        {
            var match = Set.Match;
            return Math.Abs(RalliesWonCount(match.FirstPlayer) - RalliesWonCount(match.SecondPlayer)) >= 2
                    && (RalliesWonCount(match.FirstPlayer) >= MinRalliesToWinGame || (RalliesWonCount(match.SecondPlayer) >= MinRalliesToWinGame));
        }

        public override string GetCurrentRallyScore()
        {
            return string.Format("{0}-{1}", RalliesWonCount(Set.Match.FirstPlayer), RalliesWonCount(Set.Match.SecondPlayer));
        }
    }
}
