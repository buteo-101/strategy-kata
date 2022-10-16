using StrategyConsole.Match;
using StrategyConsole.ScoreHandler;
using System;

namespace StrategyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting 1st Game");
            try
            {
                var gameHandler = new SimpleGameScoreHandler();
                var match = new TennisMatch(gameHandler);

                match.PlayerAScore();
                match.PlayerAScore();
                match.PlayerBScore();
                match.PlayerBScore();
                match.PlayerAScore();
                match.PlayerAScore();
               
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");           
            }

            Console.WriteLine("Starting 2nd Game");
            try
            {
                var gameHandler = new DeuceGameScoreHandler();
                var match = new TennisMatch(gameHandler);
                match.PlayerAScore();
                match.PlayerAScore();
                match.PlayerBScore();
                match.PlayerBScore();
                match.PlayerAScore();
                match.PlayerBScore();
                match.PlayerAScore();
                match.PlayerBScore();
                match.PlayerAScore();
                match.PlayerAScore();

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
