using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game.GameLogic.Models
{
    public abstract class GridSize
    {
        public GridSize(int gridRows, int gridCols)
        {
            GridRows = gridRows;
            GridCols = gridCols;
        }

        public int GridRows { get;}
        public int GridCols { get; }
    }
}
