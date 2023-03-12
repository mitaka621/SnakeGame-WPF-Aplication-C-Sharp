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
        DirectionState lastDirection = DirectionState.Right;
        GenerateSnake snake;
        GenerateFood food;

        bool gameRunning = true;
        bool shouldExtend;
        public GameState(int row, int col)
        {
            arr = new GridState[row, col];
            snake = new GenerateSnake(row, col);

            food = new GenerateFood(row, col);
            Row = row;
            Col = col;
            Score = 0;
        }
        public int Row { get; }
        public int Col { get; }
        public int Score { get; private set; }
        public GridState[,] GetState()
        {
            arr = new GridState[Row, Col];
            DrawSnakeInInternalArr();
            DrawFoodInInternalArr();
            return arr;
        }
        public LinkedList<Position> GetSnake()
        {
            return snake.GetSnake();
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

            if (!snake.Move(direction, shouldExtend))
                gameRunning = false;
            Position head = snake.GetSnake().First();
            switch (arr[head.Row, head.Col])
            {
                case GridState.Food:
                    EatFood(snake.GetSnake().First());
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
        private void EatFood(Position headPos)
        {

            arr[headPos.Row, headPos.Col] = GridState.Snake;
            GenerateNewFood();
            Score += 10;
        }
        private void DrawSnakeInInternalArr()
        {

            foreach (var item in snake.GetSnake())
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
