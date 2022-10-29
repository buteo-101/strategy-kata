using StrategyConsole.Match;
using StrategyConsole.ScoreHandler;
using System;

namespace StrategyConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Starting Game");

            try
            {
                var firstGameHandler = new SimpleGameScoreHandler();
                var secondGameHandler = new DeuceGameScoreHandler();
                var setHandler = new SimpleSetScoreHandler();

                var match = new TennisMatch(firstGameHandler, setHandler);
                // first game 
                match.PlayerScore("Player A");
                match.PlayerScore("Player A");
                Console.WriteLine("Changing rule");
                match.ChangeRule(secondGameHandler, setHandler);
                match.PlayerScore("Player B");
                match.PlayerScore("Player B");
                match.PlayerScore("Player A");
                match.PlayerScore("Player B");
                match.PlayerScore("Player A");
                match.PlayerScore("Player B");
                match.PlayerScore("Player A");
                match.PlayerScore("Player A");

                for (int i = 0; i < 6; i++)
                {
                    match.PlayerScore("Player A");
                    match.PlayerScore("Player A");
                    match.PlayerScore("Player A");
                    match.PlayerScore("Player A");
                }
                for (int i = 0; i < 6; i++)
                {

                    match.PlayerScore("Player B");
                    match.PlayerScore("Player B");
                    match.PlayerScore("Player B");
                    match.PlayerScore("Player B");

                }
            }
            catch (Exception e)
            {

                Console.WriteLine($"{e.Message}");
                Console.ReadLine();
                Environment.Exit(0);
            }


        }
    }
}
