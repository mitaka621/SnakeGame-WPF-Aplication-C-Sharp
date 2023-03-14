using Snake_Game.GameLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game.GameLogic.Models
{
    public class Head
    {
        public Head(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public int Row { get; private set; }
        public int Col { get; set; }
        public Head Return()
        {
            return new Head(Row, Col);
        }
        public Head MoveNext(DirectionState direction)
        {

            switch (direction)
            {
                case DirectionState.Up:
                    MoveUp();
                    break;
                case DirectionState.Down:
                    MoveDown();
                    break;
                case DirectionState.Left:
                    MoveLeft();
                    break;
                case DirectionState.Right:
                    MoveRight();
                    break;
            }
            return new Head(Row, Col);
        }

        private void MoveUp()
        {
            Row--;
        }
        private void MoveDown()
        {
            Row++;
        }
        private void MoveRight()
        {
            Col++;
        }
        private void MoveLeft()
        {
            Col--;
        }

    }
}
