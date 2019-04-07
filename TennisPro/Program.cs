using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisPro.Business;
using TennisPro.Domain;

namespace TennisPro
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string exit;
                do
                {
                    PlayMatch();

                    do
                    {
                        Console.WriteLine();
                        Console.Write("¿Quiera jugar otra vez? (s/n)");
                        exit = Console.ReadLine();
                    } while (exit.ToLower() != "s" && exit.ToLower() != "n");
                } while (exit.ToLower() == "s");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.StackTrace);
                Console.ReadLine();
            }
        }

        private static void PlayMatch()
        {
            string firstPlayer = GetFirstPlayer();
            string secondPlayer = GetSecondPlayer(firstPlayer);
            int maxNumberOfSetsToPlay = GetMaxNumberOfSets();

            var matchManager = new MatchManager(firstPlayer, secondPlayer, maxNumberOfSetsToPlay);
            matchManager.PlayMatch();

            DisplayMatch(matchManager.Match);
        }

        private static string GetFirstPlayer()
        {
            Console.Write("Seleccione el nombre de jugador 1 por favor: ");
            string firstPlayer = Console.ReadLine();
            while (!InputValidator.ValidateFirstPlayer(firstPlayer, out string message))
            {
                Console.Write("{0}. Selecione un nombre válido por favor: ", message);
                firstPlayer = Console.ReadLine();
            }

            return firstPlayer;
        }

        private static string GetSecondPlayer(string firstPlayer)
        {
            Console.Write("Seleccione el nombre de jugador 2 por favor: ");
            string secondPlayer = Console.ReadLine();
            while (!InputValidator.ValidateSecondPlayer(firstPlayer, secondPlayer, out string message))
            {
                Console.Write("{0}. Selecione un nombre válido por favor: ", message);
                secondPlayer = Console.ReadLine();
            }

            return secondPlayer;
        }

        private static int GetMaxNumberOfSets()
        {
            Console.Write("Seleccione si se trata de un partido de 3 ó 5 sets: ");
            string numberOfSets = Console.ReadLine();
            while (!InputValidator.ValidateSetsToPlay(numberOfSets, out string message))
            {
                Console.Write("{0}: ", message);
                numberOfSets = Console.ReadLine();
            }

            return int.Parse(numberOfSets);
        }

        private static void DisplayMatch(Match tennisMatch)
        {
            Console.WriteLine();
            Console.WriteLine("**********************************");
            Console.WriteLine("Nombre jugador 1: {0}", tennisMatch.FirstPlayer.Name);
            Console.WriteLine("Nombre jugador 2: {0}", tennisMatch.SecondPlayer.Name);
            Console.WriteLine("Partido a 3 ó 5 sets ?: {0}", tennisMatch.MaxSetsToPlay);
            Console.WriteLine();
            Console.WriteLine("{0} iniciara el partido sacando", tennisMatch.FirstPlayer.Name);
            Console.WriteLine();

            int setCount = 1;
            foreach (var set in tennisMatch.Sets)
            {
                int gameCount = 1;
                foreach (var game in set.Games)
                {
                    Console.WriteLine("** Juego {0} - Set {1}", gameCount, setCount);
                    int rallyCount = 1;
                    foreach (var rally in game.Rallies)
                    {
                        if (rallyCount != game.Rallies.Count)
                            Console.WriteLine("Punto de {0}: {1}", rally.Winner.Name, rally.Score);
                        else
                            Console.WriteLine("Punto de {0}", rally.Winner.Name);
                        rallyCount++;
                    }

                    if (gameCount == set.Games.Count())
                        Console.WriteLine("{0} gana el juego y el set ({1})", game.Winner.Name, game.Score);
                    else
                        Console.WriteLine("{0} gana el juego ({1})", game.Winner.Name, game.Score);

                    Console.WriteLine();
                    gameCount++;
                }
                setCount++;
            }

            Console.WriteLine("!!{0} GANA EL PARTIDO¡¡ ({1})", tennisMatch.Winner.Name, DisplaySetScores(tennisMatch));
        }

        private static string DisplaySetScores(Match match)
        {
            return string.Join(", ", match.Sets.Select(x => x.GetCurrentGameScore()));
        }
    }
}
