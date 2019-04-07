using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisPro.Domain;

namespace TennisPro.Business
{
    internal class SetManager
    {
        #region Private fields
        private Match _match; 
        #endregion

        #region Properties
        public Set Set { get; private set; }
        internal GameManager GameManager { get; private set; } 
        #endregion

        #region Constructors
        public SetManager(Match match)
        {
            _match = match;
        } 
        #endregion

        #region Internal methods
        internal void PlaySet()
        {
            Set = new Set { Match = _match };

            while (!Set.IsFinished())
            {
                GameManager = new GameManager(Set);
                GameManager.PlayGame();
                Set.Score = Set.Match.GetCurrentSetScore();
            }

            Set.Winner = Set.Games.Last().Winner;
        } 
        #endregion
    }
}
