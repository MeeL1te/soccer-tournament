using System;
using System.Collections.Generic;
using Models;

namespace SoccerTournamentApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var matchResults = new List<Models.SoccerTournament>();
            String reply     = "";

            do
            {
                var soccerTournament = new Models.SoccerTournament();

                soccerTournament.RegisterGameResults();
                matchResults.Add(soccerTournament);
                soccerTournament.ShowGame();

                do
                {
                    Console.Write("\nType a reply: ");
                    reply = Console.ReadLine();
                    reply = reply.ToLower();

                    if (
                        reply != "s" &&
                        reply != "si" &&
                        reply != "n" &&
                        reply != "no"
                    )
                    {
                        Console.WriteLine("\nError! The reply is incorrect");
                    }

                } while (
                    reply != "s" &&
                    reply != "si" &&
                    reply != "n" &&
                    reply != "no"
                );

                Console.Clear();

            } while (reply == "s" || reply == "si");

            Console.WriteLine(
                "Tied games: {0}\n",
                SoccerTournament.GetTiedGames(matchResults) +
                "\n\nThe game with the most goals was:"
            );

            SoccerTournament.ShowGameWithMoreGoals(matchResults);

            String finalRes = (SoccerTournament.IsBarcelonaFC(matchResults))
                    ? "participated "
                    : "did not participate ";

            Console.WriteLine(
                "\nBarcelona FC " + finalRes + "in the tournament"
            );

            Console.Write("\nPress any key to exit...");
            Console.ReadKey(true);
        }
    }
}
