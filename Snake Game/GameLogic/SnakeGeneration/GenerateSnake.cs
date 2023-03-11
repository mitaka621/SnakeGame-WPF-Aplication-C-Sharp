using Snake_Game.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game.Logic
{
    public class GenerateSnake
    {
        public readonly LinkedList<Position> snake;
        
        public GenerateSnake(int row, int col)
        {
            snake = new LinkedList<Position>(new List<Position>()
            {
                new Position(row/2,6),
                new Position(row/2,5),
                 new Position(row/2,4),
                new Position(row/2,3),                   
                new Position(row/2,2),
                new Position(row/2,1)
            });
            Row = row;
            Col = col;
        }
        private int Row { get;}
        private int Col { get; }

        public LinkedList<Position> Move(DirectionState state)
        {
            //bug location
            Position nextPosition = snake.First().Return();
            
            snake.RemoveLast();
            
            switch (state)
            {
                case DirectionState.Up:                 
                    nextPosition.MoveUp();
                    break;
                case DirectionState.Down:
                    nextPosition.MoveDown();
                    break;
                case DirectionState.Left:
                    nextPosition.MoveLeft();
                    break;
                case DirectionState.Right:
                    nextPosition.MoveRight();
                    break;               
            }
            if (IsPositionValid(nextPosition))
                snake.AddFirst(nextPosition);
            else
                throw new ArgumentException("Game Over");
            return snake;
        }

        private bool IsPositionValid(Position pos)=>
            pos.Row>=0&&
            pos.Col>=0&&
            pos.Row<Row&&
            pos.Col<Col;
    }
}
