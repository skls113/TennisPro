using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisPro.Business.Exceptions;

namespace TennisPro.Business
{
    public static class MatchValidator
    {
        public static void Validate(string firstPlayer, string secondPlayer, int maxSetsToPlay)
        {
            ValidateFirstPlayer(firstPlayer);
            ValidateSecondPlayer(firstPlayer, secondPlayer);
            ValidateSetsToPlay(maxSetsToPlay);
        }

        public static void ValidateFirstPlayer(string firstPlayer)
        {
            if (string.IsNullOrEmpty(firstPlayer))
                throw new InvalidPlayerNameException("El nombre de jugador 1 no puede ser vacío");
        }

        public static void ValidateSecondPlayer(string firstPlayer, string secondPlayer)
        {
            if (string.IsNullOrEmpty(secondPlayer))
                throw new InvalidPlayerNameException("El nombre de jugador 2 no puede ser vacío");

            if (string.Compare(firstPlayer, secondPlayer, true) == 0)
                throw new InvalidPlayerNameException("En nombre de jugador 2 debe ser diferente de nombre de jugador 1");
        }

        public static void ValidateSetsToPlay(int maxSetsToPlay)
        {
            if (maxSetsToPlay != 3 && maxSetsToPlay != 5)
                throw new InvalidMaxSetsToPlayException("El partido debe ser de 3 o 5 sets");
        }
    }
}
