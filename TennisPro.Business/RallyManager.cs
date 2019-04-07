using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisPro.Business.RallyAllocators;
using TennisPro.Domain;
using TennisPro.Domain.Abstracts;

namespace TennisPro.Business
{
    internal class RallyManager
    {
        #region Private fields
        private Game _game;
        private IRallyAllocator _rallyAllocator;
        #endregion

        #region Properties
        public Rally Rally { get; internal set; }
        #endregion

        #region Constructors
        public RallyManager(IRallyAllocator rallyAllocator, Game game)
        {
            _game = game;
            _rallyAllocator = rallyAllocator;
        }
        #endregion

        #region Internal methods
        internal void PlayRally()
        {
            Rally = new Rally { Game = _game };
            var match = Rally.Game.Set.Match;
            Rally.Winner = _rallyAllocator.AllocateRally(match.FirstPlayer, match.SecondPlayer);
            _game.Rallies.Add(Rally);
            Rally.Score = Rally.Game.GetCurrentRallyScore();
        } 
        #endregion
    }
}
