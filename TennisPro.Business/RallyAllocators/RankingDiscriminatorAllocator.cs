using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisPro.Domain;

namespace TennisPro.Business.RallyAllocators
{
    /// <summary>
    /// Allocates the winner of the rally based on the players WorldRanking
    /// </summary>
    internal class RankingDiscriminatorAllocator : IRallyAllocator
    {
        public Player AllocateRally(Player firstPlayer, Player secondPlayer)
        {
            if (firstPlayer.WorldRanking < secondPlayer.WorldRanking)
                return firstPlayer;
            else
                return secondPlayer;
        }
    }
}
