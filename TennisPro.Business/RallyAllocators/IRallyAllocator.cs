using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisPro.Domain;

namespace TennisPro.Business.RallyAllocators
{
    interface IRallyAllocator
    {
        /// <summary>
        /// Defines the winner of the rally
        /// </summary>
        /// <param name="firstPlayer">The first player of the rally</param>
        /// <param name="secondPlayer">The second player of the rally</param>
        /// <returns>The winner of the Rally</returns>
        Player AllocateRally(Player firstPlayer, Player secondPlayer);
    }
}
