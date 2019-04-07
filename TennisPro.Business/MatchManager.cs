using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisPro.Business.Exceptions;
using TennisPro.Domain;

namespace TennisPro.Business
{
    public class MatchManager
    {
        #region Proprties
        public Match Match { get; private set; }
        internal SetManager SetManager { get; private set; }
        #endregion

        #region Constructors
        public MatchManager(string firstPlayer, string secondPlayer, int maxSetsToPlay)
        {
            MatchValidator.Validate(firstPlayer, secondPlayer, maxSetsToPlay);
            Match = new Match(firstPlayer, secondPlayer, maxSetsToPlay);
            SetManager = new SetManager(Match);
        } 
        #endregion

        #region Public Methods
        public void PlayMatch()
        {
            try
            {
                while (!Match.IsFinished()) 
                {
                    SetManager.PlaySet();
                    Match.Sets.Add(SetManager.Set);                    
                } 

                Match.Winner = Match.Sets.Last().Winner;
        }
            catch (Exception ex)
            {
                //TODO : Log exception
                throw ex;
            }            
        }
        #endregion
    }
}
