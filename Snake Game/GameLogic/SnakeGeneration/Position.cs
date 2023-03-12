using Snake_Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game.Logic
{
    public class Position
    {
        public Position(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public int Row { get; private set; }
        public int Col { get; set; }
        public Position Return()
        {
            return new Position(Row, Col);
        }
        public Position MoveNext(DirectionState direction)
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
            return new Position(Row,Col);
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
