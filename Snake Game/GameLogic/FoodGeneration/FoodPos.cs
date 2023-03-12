using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game.GameLogic.FoodGeneration
{
    public class GenerateFood
    {
        Random r;

        public GenerateFood(int row, int col)
        {
            r = new Random();
            Row = row;
            Col= col;
            GenerateNewFood();
        }
        private int Row { get; }
        private int Col { get; }

        public int FoodRow { get; private set; }
        public int FoodCol { get; private set; }

        public void GenerateNewFood()
        {
            FoodRow = r.Next(0, Row);
            r= new Random();
            FoodCol = r.Next(0, Col);
        }
    }
}
