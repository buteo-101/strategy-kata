﻿using StrategyConsole.Model;
using StrategyConsole.ScoreHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace StrategyConsole.Match
{
    public class TennisMatch
    {

        private IScoreHandler _gameScoreHandler;
        private IScoreHandler _setScoreHandler;

        public List<Player> Players { get; set; } = new List<Player>
            {
                new Player { Name = "Player A", Score = new Score { GameScore = "0", SetScores = new List<int>{0} } },
                new Player { Name = "Player B", Score = new Score { GameScore = "0", SetScores = new List<int>{0} } },
            };


        public TennisMatch(IScoreHandler gameScoreHandler, IScoreHandler setScoreHandler)
        {
            _gameScoreHandler = gameScoreHandler;
            _setScoreHandler = setScoreHandler;
        }
        public void ChangeRule(IScoreHandler gameScoreHandler, IScoreHandler setScoreHandler)
        {
            _gameScoreHandler = gameScoreHandler;
            _setScoreHandler = setScoreHandler;
        }

        public void PlayerScore(string name)
        {
            if (!Players.Any(p => p.Name == name))
            {
                throw new Exception("Invalid Player to score");
            }
            var scorer = Players.First(p => p.Name == name);
            var other = Players.First(p => p.Name != name);

            var newScore = _gameScoreHandler.GetNextScore(scorer, other);

            if (!string.IsNullOrEmpty(newScore.ScorerScore))
            {

                scorer.Score.GameScore = newScore.ScorerScore;
                other.Score.GameScore = newScore.OtherScore;
                Console.WriteLine($"{JsonSerializer.Serialize(Players)}");
            }
            else
            {
                // a game has been won
                _gameScoreHandler.GameOver(scorer.Name);
                // reset Both players Game Score to 0
                scorer.Score.GameScore = "0";
                other.Score.GameScore = "0";

                var newSetScore = _setScoreHandler.GetNextScore(scorer, other);
                if (!string.IsNullOrEmpty(newSetScore.ScorerScore))
                {
                    var activeSetIndex = scorer.Score.SetScores.Count - 1;
                    Console.WriteLine($"Active set {activeSetIndex}");
                    scorer.Score.SetScores[activeSetIndex] = int.Parse(newSetScore.ScorerScore);
                    other.Score.SetScores[activeSetIndex] = int.Parse(newSetScore.OtherScore);
                    Console.WriteLine($"{JsonSerializer.Serialize(Players)}");
                } 
                else
                {
                    Console.WriteLine($"{scorer.Name} has won the Set");
                    // creates a new set 
                    scorer.Score.SetScores.Add(0);
                    other.Score.SetScores.Add(0);
                    Console.WriteLine($"{JsonSerializer.Serialize(Players)}");
                }
            }
        }


    }
}
