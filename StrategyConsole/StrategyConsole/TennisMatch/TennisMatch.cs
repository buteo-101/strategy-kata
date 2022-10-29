using StrategyConsole.Model;
using StrategyConsole.ScoreHandler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace StrategyConsole.Match
{
    public class TennisMatch
    {

        private IScoreHandler _scoreHandler;
        public List<Player> Players { get; set; } = new List<Player>
            {
                new Player { Name = "Player A", Score = "0" },
                new Player { Name = "Player B", Score = "0" }
            };


        public TennisMatch(IScoreHandler scoreHandler)
        {
            _scoreHandler = scoreHandler;
        }
        public void ChangeRule(IScoreHandler scoreHandler)
        {
            _scoreHandler = scoreHandler;
        }

        public void PlayerAScore()
        {
            var newScore = _scoreHandler.GetNextScore(Players[0], Players[1]);
            if (!string.IsNullOrEmpty(newScore.ScorerScore))
            {

                Players[0].Score = newScore.ScorerScore;
                Players[1].Score = newScore.OtherScore;
                Console.WriteLine($"{JsonSerializer.Serialize(Players)}");
            }
            else
            {
                _scoreHandler.GameOver(Players[0].Name);
            }
        }

        public void PlayerBScore()
        {
            var newScore = _scoreHandler.GetNextScore(Players[1], Players[0]);
            if (!string.IsNullOrEmpty(newScore.ScorerScore))
            {

                Players[0].Score = newScore.OtherScore;
                Players[1].Score = newScore.ScorerScore;
                Console.WriteLine($"{JsonSerializer.Serialize(Players)}");
            }
            else
            {
                _scoreHandler.GameOver(Players[1].Name);
            }
        }



    }
}
