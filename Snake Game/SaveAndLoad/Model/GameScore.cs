using Snake_Game.GameLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game.SaveLoad
{
    [Serializable]
    public class GameScore
    {
        public GameScore(int score, string time,int gridSize, GameDifficulty difficulty)
        {
            Score = score;
            Time = time;
            GridSize = gridSize;
            Difficulty=difficulty;
        }

        public int Score { get;  }
        public int GridSize { get; }
        public string Time { get;  }
        public GameDifficulty Difficulty { get;}

    }
}
