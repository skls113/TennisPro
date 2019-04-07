using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisPro.Domain.Abstracts
{
    public abstract class Game
    {
        #region Properties
        public Player Winner { get; set; }
        public List<Rally> Rallies { get; set; }
        public Set Set { get; set; }
        public string Score { get; set; }
        #endregion

        #region Constructors
        public Game()
        {
            Rallies = new List<Rally>();
        }
        #endregion

        public abstract bool IsFinished();

        public abstract string GetCurrentRallyScore();

        protected internal int RalliesWonCount(Player player)
        {
            return Rallies.Count(x => x.Winner.Equals(player));
        }
    }
}
