using StrategyConsole.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyConsole.ScoreHandler
{
    public interface IScoreHandler
    {

        NewScore GetNextScore(Player scorer, Player other);

        void GameOver(string playerName);

    }
}
