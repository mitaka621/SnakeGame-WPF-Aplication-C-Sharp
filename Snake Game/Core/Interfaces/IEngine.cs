using Snake_Game.GameLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game.Core.Interfaces
{
    public interface IEngine
    {
        public void StartGame();
        public void StopGame();
        public void Move(DirectionState state);
    }
}
