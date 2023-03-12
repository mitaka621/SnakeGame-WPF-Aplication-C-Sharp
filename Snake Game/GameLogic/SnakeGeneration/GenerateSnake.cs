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
        private readonly LinkedList<Position> snake;
        
        public GenerateSnake(int row, int col)
        {
            snake = new LinkedList<Position>(new List<Position>()
            {
               
                new Position(row/2,3),                   
                new Position(row/2,2),
                new Position(row/2,1)
            });
            Row = row;
            Col = col;
        }
        private int Row { get;}
        private int Col { get; }

        public LinkedList<Position> GetSnake() => snake;
        
        public bool Move(DirectionState state,bool extend=false)
        {
            Position nextPosition = snake.First().Return().MoveNext(state);
            
            if (IsPositionValid(nextPosition))
            {
                if (!extend)
                    snake.RemoveLast();
                snake.AddFirst(nextPosition);
               
                return true;
            }
            
            return false;
        }
        
        private bool IsPositionValid(Position pos)=>
            pos.Row>=0&&
            pos.Col>=0&&
            pos.Row<Row&&
            pos.Col<Col;
    }
}
