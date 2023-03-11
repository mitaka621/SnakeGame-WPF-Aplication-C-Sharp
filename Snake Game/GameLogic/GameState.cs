using Snake_Game.GameLogic.FoodGeneration;
using Snake_Game.Logic;
using Snake_Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game.GameLogic
{
    public class GameState
    {
        GridState[,] arr;
        GenerateSnake generate;
        GenerateFood food;
        LinkedList<Position> snake;
        public GameState(int row, int col)
        {
            arr = new GridState[row, col];
            generate = new GenerateSnake(row, col);
            snake = generate.snake;
            food=new GenerateFood(row, col);
            Row= row;
            Col= col;
            
        }
        public int Row { get;  }
        public int Col { get; }

        public GridState[,] GetState()
        {
            arr=new GridState[Row, Col];
            DrawSnake();
            DrawFood();
            return arr;
        }
        public void MoveSnake(DirectionState direction)
        {
            snake = generate.Move(direction);
        }
        private void DrawSnake()
        {
            
            foreach (var item in snake)
            {
                arr[item.Row, item.Col] = GridState.Snake;
            }
        }
        private void DrawFood()
        {
            arr[food.FoodRow,food.FoodCol]=GridState.Food;
        }
       
        private void GenerateNewFood()
        {
            food.GenerateNewFood();
        }
    }
}
