using Snake_Game.GameLogic.Enums;
using Snake_Game.SaveLoad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game.Save_Load
{
    [Serializable]
    public class GameModesScore
    {
        public readonly List<GameScore> allGamemodeScores;
        public GameModesScore()
        {
            allGamemodeScores=new List<GameScore>();
        }

        public GameScore GetHighestScore(int gridSize,GameDifficulty difficulty)
        {
            if (!allGamemodeScores.Any(x=>x.GridSize==gridSize&&x.Difficulty==difficulty))            
                allGamemodeScores.Add(new GameScore(0, "00:00:000", gridSize,difficulty));

            return allGamemodeScores[allGamemodeScores.FindIndex(x => x.GridSize == gridSize&&x.Difficulty==difficulty)];
        }
        public void UpdateHighScore(GameScore score)
            => allGamemodeScores[allGamemodeScores.FindIndex(x => x.GridSize == score.GridSize&& x.Difficulty == score.Difficulty)]=score;
        
    }
}
