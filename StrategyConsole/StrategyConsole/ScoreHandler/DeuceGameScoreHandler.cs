using StrategyConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace StrategyConsole.ScoreHandler
{
    class DeuceGameScoreHandler : IScoreHandler
    {
        private List<string> _gameScoreOptions = new List<string>{ "0", "15", "30", "40", "DEUCE", "ADVANTAGE" };
      

        public NewScore GetNextScore(Player scorer, Player other)
        {
            Console.WriteLine($"{scorer.Name} has scored");
            var scoreIndex = _gameScoreOptions.FindIndex(s => s == scorer.Score);
            if (scoreIndex >= 3)
            {
                // depends on other player
                var otherScoreIndex = _gameScoreOptions.FindIndex(s => s == other.Score);
                if ((otherScoreIndex == 3 || otherScoreIndex == 4) && scoreIndex !=5)
                {
                    // ADVANTAGE 40
                    return new NewScore { ScorerScore = _gameScoreOptions[5], OtherScore = _gameScoreOptions[3] };
                }
                if (otherScoreIndex == 5)
                         {
                    // DEUCE DEUCE
                    return new NewScore { ScorerScore= _gameScoreOptions[4],  OtherScore = _gameScoreOptions[4] };
                }
                // WIN
              
                return new NewScore { ScorerScore = string.Empty, OtherScore = string.Empty };
            }
            return new NewScore { ScorerScore = _gameScoreOptions[++scoreIndex], OtherScore = other.Score };
        }


        public void GameOver(string playerName)
        {
            Console.WriteLine($"Player {playerName} has won");
            throw new Exception("Game Over");
        }
    }
}



