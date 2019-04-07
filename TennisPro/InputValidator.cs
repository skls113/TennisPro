using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisPro.Business;

namespace TennisPro
{
    internal class InputValidator
    {
        internal static bool ValidateFirstPlayer(string firstPlayer, out string message)
        {
            try
            {
                MatchValidator.ValidateFirstPlayer(firstPlayer);
                message = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        internal static bool ValidateSecondPlayer(string firstPlayer, string secondPlayer, out string message)
        {
            try
            {
                MatchValidator.ValidateSecondPlayer(firstPlayer, secondPlayer);
                message = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        internal static bool ValidateSetsToPlay(string numberOfSets, out string message)
        {
            try
            {
                if (int.TryParse(numberOfSets, out int maxNumberOfSetsToPlay))
                {
                    MatchValidator.ValidateSetsToPlay(maxNumberOfSetsToPlay);
                    message = string.Empty;
                    return true;
                }
                else
                {
                    message = "El numero de los Sets del partido debe tener un valor numérico";
                    return false;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }
    }
}
