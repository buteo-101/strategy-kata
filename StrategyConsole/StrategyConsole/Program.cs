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
            var deuceGameHandler = new DeuceGameScoreHandler();
            var setHandler = new SetWithTieBreakScoreHandler();
            var tieBreakGameHandler = new TieBreakScoreHandler();
            var match = new TennisMatch(deuceGameHandler, setHandler);

            try
            {

                

                match.RuleChanged += (o, e) =>
                {
                    {
                        switch (e)
                        {
                            case "deuce":
                                Console.WriteLine("Switching to tie deuce rule");
                                match.ChangeRule(deuceGameHandler, setHandler);
                                break;
                            case "tie-break":
                                Console.WriteLine("Switching to tie break rule");
                                match.ChangeRule(tieBreakGameHandler, setHandler);
                                break;
                            default:
                                break;
                        }
                    }
                };
                    
                   
     

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
                match.PlayerScore("Player A");
                match.PlayerScore("Player A");
                match.PlayerScore("Player A");
                match.PlayerScore("Player A");
                match.PlayerScore("Player A");
                match.PlayerScore("Player A");
                match.PlayerScore("Player B");
                match.PlayerScore("Player B");
                match.PlayerScore("Player B");
                match.PlayerScore("Player B");
                match.PlayerScore("Player A");
               
                for (int i = 0; i < 6; i++)
                {
                    match.PlayerScore("Player A");
                    match.PlayerScore("Player A");
                    match.PlayerScore("Player A");
                    match.PlayerScore("Player A");
                }

                match.PlayerScore("Player A");
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
