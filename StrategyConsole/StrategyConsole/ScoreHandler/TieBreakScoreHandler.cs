using StrategyConsole.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyConsole.ScoreHandler
{
    public class TieBreakScoreHandler : IScoreHandler
    {


        public NewScore GetNextScore(Player scorer, Player other)
        {
            var scorerCurrentScore = int.Parse(scorer.Score.GameScore);
            var otherCurrentScore = int.Parse(other.Score.GameScore);

            // This is a special game 
            if (scorerCurrentScore > 6 && scorerCurrentScore > otherCurrentScore)
            {
                // scorer has won the tie break
                return new NewScore { ScorerScore = string.Empty, OtherScore = string.Empty };
            }

            return new NewScore { ScorerScore = (scorerCurrentScore + 1).ToString(), OtherScore = otherCurrentScore.ToString() };

        }
        public void GameOver(string playerName)
        {
            Console.WriteLine($"Player {playerName} has won a tie-break");
        }

    }
}
