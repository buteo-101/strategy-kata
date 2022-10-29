using StrategyConsole.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyConsole.ScoreHandler
{
    class SimpleSetScoreHandler : IScoreHandler
    {
        public void GameOver(string playerName)
        {
            Console.WriteLine($"Player {playerName} has won a set");
            // throw new Exception("Game Over");
        }

        public NewScore GetNextScore(Player scorer, Player other)
        {
            // Scorer wins a game and increases its score whithin the current set
       
            // find active set 
            // every played set has to be initialized
            var activeSetIndex = scorer.Score.SetScores.Count - 1;
            var currentScore = scorer.Score.SetScores[activeSetIndex];
            var otherScore = other.Score.SetScores[activeSetIndex];


            if ( currentScore > 5 && currentScore > otherScore)
            {
                Console.WriteLine($"Returning End Set Score");
                // return empty /empty if point wins the set as in a single game 
                return new NewScore { ScorerScore = string.Empty, OtherScore = string.Empty };
            }
            return new NewScore { ScorerScore = (currentScore + 1).ToString(), OtherScore = otherScore.ToString() };         
        }
    }
}
