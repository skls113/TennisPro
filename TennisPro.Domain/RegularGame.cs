using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisPro.Domain.Abstracts;

namespace TennisPro.Domain
{
    public class RegularGame : Game
    {
        //Players reach 40-0 on 3 winning rallies. The 4th rally gives the game.
        const int MinRalliesToWinGame = 4;

        public override string GetCurrentRallyScore()
        {
            string score = "0-0";

            if (RalliesWonCount(Set.Match.FirstPlayer) == RalliesWonCount(Set.Match.SecondPlayer)
                && RalliesWonCount(Set.Match.FirstPlayer) >= 3)
                score = "Deuce";
            else if (RalliesWonCount(Set.Match.FirstPlayer) >= 3 && RalliesWonCount(Set.Match.SecondPlayer) >= 3
                        && RalliesWonCount(Set.Match.FirstPlayer) > RalliesWonCount(Set.Match.SecondPlayer))
                score = string.Format("Advantage {0}", Set.Match.FirstPlayer.Name);
            else if (RalliesWonCount(Set.Match.FirstPlayer) >= 3 && RalliesWonCount(Set.Match.SecondPlayer) >= 3
                        && RalliesWonCount(Set.Match.FirstPlayer) < RalliesWonCount(Set.Match.SecondPlayer))
                score = string.Format("Advantage {0}", Set.Match.SecondPlayer.Name);
            else
                score = string.Format("{0}-{1}", GetTennisScore(Set.Match.FirstPlayer), GetTennisScore(Set.Match.SecondPlayer));

            return score;
        }

        public override bool IsFinished()
        {
            var match = Set.Match;
            return Math.Abs(RalliesWonCount(match.FirstPlayer) - RalliesWonCount(match.SecondPlayer)) >= 2
                    && (RalliesWonCount(match.FirstPlayer) >= MinRalliesToWinGame || (RalliesWonCount(match.SecondPlayer) >= MinRalliesToWinGame));
        }

        private string GetTennisScore(Player player)
        {
            string tennisScore;
            int ralliesWonCount = RalliesWonCount(player);

            if (ralliesWonCount == 0)
                tennisScore = "0";
            else if (ralliesWonCount == 1)
                tennisScore = "15";
            else if (ralliesWonCount == 2)
                tennisScore = "30";
            else if (ralliesWonCount == 3)
                tennisScore = "40";
            else
                tennisScore = "AD";

            return tennisScore;
        }
    }
}
