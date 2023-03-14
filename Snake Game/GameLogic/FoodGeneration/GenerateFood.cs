using Snake_Game.GameLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game.GameLogic.FoodGeneration
{
    public class GenerateFood: GridSize
    {
        Random r;

        public GenerateFood(int gridRows, int gridCols) : base(gridRows, gridCols)
        {
            r = new Random();
            GenerateNewFood();
        }
        
       
        public int FoodRow { get; private set; }
        public int FoodCol { get; private set; }

        public void GenerateNewFood()
        {
            FoodRow = r.Next(0, GridRows);
            r= new Random();
            FoodCol = r.Next(0, GridCols);
        }
    }
}
