using Snake_Game.GameLogic.Enums;
using Snake_Game.GameLogic.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game.Logic
{
    public class Snake:GridSize
    {
        private protected LinkedList<Head> snake;

        public Snake(int gridRows, int gridCols) : base(gridRows, gridCols)
        {
            snake = new LinkedList<Head>(new List<Head>()
            {
                new Head(gridRows/2,3),
                new Head(gridRows/2,2),
                new Head(gridRows/2,1)
            });
        }
       
        public LinkedList<Head> GetSnake() => snake;
        
        protected bool Move(DirectionState state,bool extend=false)
        {
            Head nextHead = snake.First().Return().MoveNext(state);
            
            if (IsHeadValid(nextHead))
            {
                if (!extend)
                    snake.RemoveLast();
                snake.AddFirst(nextHead);
               
                return true;
            }
            
            return false;
        }
        
        private bool IsHeadValid(Head pos)=>
            pos.Row>=0&&
            pos.Col>=0&&
            pos.Row< GridRows&&
            pos.Col<GridCols;
    }
}
