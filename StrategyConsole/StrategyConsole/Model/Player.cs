using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyConsole.Model
{
    public class Player
    {
   
        public string Name { get; set; }
        public Score Score { get; set; }
    }

    public class Score
    {
        public string GameScore { get; set; }
        public List<int> SetScores { get; set; }
    }
}
