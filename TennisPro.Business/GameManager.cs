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
    internal class GameManager
    {
        #region Private fields
        private Set _set;
        #endregion

        #region Properties
        public Game Game { get; private set; }
        internal RallyManager RallyManager { get; private set; }
        #endregion

        #region Constructors
        public GameManager(Set set)
        {
            _set = set;
        }
        #endregion

        #region Internal methods
        internal void PlayGame()
        {
            GameFactory(_set);

            while (!Game.IsFinished())
            {
                //TODO: Use dependancy injection container to inject IRallyAllocator to RallyManager
                IRallyAllocator rallyAllocator = new RandomAllocator();
                RallyManager = new RallyManager(rallyAllocator, Game);
                RallyManager.PlayRally();
            }

            _set.Games.Add(Game);
            Game.Winner = Game.Rallies.Last().Winner;
            Game.Score = Game.Set.GetCurrentGameScore();
        } 
        #endregion

        #region Private Methods
        private void GameFactory(Set set)
        {
            if (set.Games.Count == 12)
                Game = new TiebreakGame { Set = set };
            else
                Game = new RegularGame { Set = set };
        }
        #endregion
    }
}
