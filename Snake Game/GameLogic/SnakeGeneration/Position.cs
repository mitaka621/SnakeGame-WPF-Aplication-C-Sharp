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
        public void MoveUp()
        {
            Row--;
        }
        public void MoveDown()
        {
            Row++;
        }
        public void MoveRight()
        {
            Col++;  
        }
        public void MoveLeft()
        {
            Col--;
        }

    }
}
