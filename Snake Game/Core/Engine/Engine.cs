using Snake_Game.Core.Interfaces;
using Snake_Game.GameLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Snake_Game.Core.Engine
{
    public class Engine : GridSize, IEngine
    {
        MainWindow main = Application.Current.Windows[0] as MainWindow;

        public Engine(int gridRows, int gridCols,TimeSpan gameSpeed) : base(gridRows, gridCols)
        {
        }

        public void Run()
        {
            
            throw new NotImplementedException();
        }
    }
}
