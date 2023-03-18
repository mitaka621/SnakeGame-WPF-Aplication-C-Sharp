using Snake_Game.GameLogic.Enums;
using Snake_Game.GameLogic.FoodGeneration;
using Snake_Game.GameLogic.Models;
using Snake_Game.Logic;
using Snake_Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game.GameLogic
{
    
    public class GameState:Snake
    {
        GridState[,] arr;
        DirectionState lastDirection = DirectionState.Right;
        GenerateFood food;

        bool gameRunning = true;
        bool shouldExtend;

        public GameState(int gridRows, int gridCols) : base(gridRows, gridCols)
        {
            arr = new GridState[GridRows, GridCols];           
            food = new GenerateFood(GridRows, GridCols);
            Score = 0;
        }
        public DirectionState LastDirection { get=>lastDirection; }
        public int Score { get; private set; }
        public GridState[,] GetState()
        {
            arr = new GridState[GridRows, GridCols];
            DrawSnakeInInternalArr();
            DrawFoodInInternalArr();
            return arr;
        }
        

        public bool IsDirectionValid(DirectionState lastDirection, DirectionState newDirection)
        => (lastDirection == DirectionState.Left && newDirection == DirectionState.Right)
         || (lastDirection == DirectionState.Right && newDirection == DirectionState.Left)
         || (lastDirection == DirectionState.Up && newDirection == DirectionState.Down)
         || (lastDirection == DirectionState.Down && newDirection == DirectionState.Up);



        public bool MoveSnake(DirectionState direction)
        {
            if (IsDirectionValid(lastDirection, direction))
                direction = lastDirection;
            else
                lastDirection = direction;

            if (!Move(direction, shouldExtend))
                gameRunning = false;
            Head head = snake.First();
            switch (arr[head.Row, head.Col])
            {
                case GridState.Food:
                    EatFood(snake.First());
                    shouldExtend=true;
                    break;
                case GridState.Snake:
                    gameRunning = false;
                    break;
                case GridState.Empty:
                    shouldExtend = false;
                    break;
            }

            return gameRunning;

        }
        private void EatFood(Head headPos)
        {

            arr[headPos.Row, headPos.Col] = GridState.Snake;
            GenerateNewFood();
            Score += 10;
        }
        private void DrawSnakeInInternalArr()
        {

            foreach (var item in snake)
            {
                arr[item.Row, item.Col] = GridState.Snake;
            }
        }
        private void DrawFoodInInternalArr()
        {
            arr[food.FoodRow, food.FoodCol] = GridState.Food;
        }

        private void GenerateNewFood()
        {
            food.GenerateNewFood();
            if (arr[food.FoodRow, food.FoodCol] != GridState.Empty)
            {
                GenerateNewFood();
            }
        }
    }
}
