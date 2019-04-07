using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisPro.Domain;

namespace TennisPro.Business.RallyAllocators
{
    /// <summary>
    /// Allocates the winner of the rally based on the players Age
    /// </summary>
    internal class AgeDiscriminatorAllocator : IRallyAllocator
    {
        public Player AllocateRally(Player firstPlayer, Player secondPlayer)
        {
            if (firstPlayer.BirthDate < secondPlayer.BirthDate)
                return secondPlayer;
            else
                return firstPlayer;
        }
    }
}
