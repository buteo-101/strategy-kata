using StrategyConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace StrategyConsole.ScoreHandler
{
    class SimpleGameScoreHandler : IScoreHandler
    {
        private List<string> _gameScoreOptions = new List<string>{ "0", "15", "30", "40" };
     
        public NewScore GetNextScore(Player scorer, Player other)
        {
            Console.WriteLine($"{scorer.Name} has scored");
            var scoreIndex = _gameScoreOptions.FindIndex(s => s == scorer.Score.GameScore);
            if (scoreIndex == 3)
            {             
                return new NewScore { ScorerScore = string.Empty,  OtherScore = string.Empty };
            }
            return new NewScore { ScorerScore=   _gameScoreOptions[++scoreIndex], OtherScore = other.Score.GameScore };
        }
 

        public void GameOver(string  playerName)
        {
            Console.WriteLine($"Player {playerName} has won a game");
            // throw new Exception("Game Over");
        }
    }
}


