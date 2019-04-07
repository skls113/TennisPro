using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisPro.Domain;

namespace TennisPro.Business.RallyAllocators
{
    /// <summary>
    /// Allocates the winner of the rally randomly
    /// </summary>
    internal class RandomAllocator : IRallyAllocator
    {
        private static readonly Random random = new Random();
        public Player AllocateRally(Player firstPlayer, Player secondPlayer)
        {
            if (random.Next(0, 2) == 0)
                return firstPlayer;
            else
                return secondPlayer;
        }
    }
}
