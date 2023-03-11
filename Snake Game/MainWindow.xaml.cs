using Snake_Game.GameLogic;
using Snake_Game.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Snake_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int rows = 15, cols = 15;
        private Image[,] gridImages;
        GameState gamestate = new GameState(rows,cols);
        GridState[,] gridstate;
        DirectionState direction= DirectionState.Right;
        Dictionary<GridState, ImageSource> states=new Dictionary<GridState, ImageSource>()
        {
            {GridState.Empty, Images.Empty },
            {GridState.Snake, Images.Body },
            {GridState.Food, Images.Food },
        };
        DispatcherTimer clock =new DispatcherTimer();
        
        public MainWindow()
        {
            InitializeComponent();
            gridImages=SetUpGrid();

            StartClock();
           
            
            
            //gridImages[1, 2].Source = Images.Food;

        }

       private void Draw()
        {
            gridstate = gamestate.GetState();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    ImageSource source = null;
                    switch (gridstate[i,j])
                    {
                        case GridState.Empty:
                            source = states[GridState.Empty];
                            break;
                        case GridState.Snake:
                            source = states[GridState.Snake];
                            break;
                        case GridState.Food:
                            source = states[GridState.Food];
                            break;
                       
                    }
                    gridImages[i, j].Source=source;
                }
            }
            
        }
        
        private Image[,] SetUpGrid()
        {
            Image[,] images = new Image[rows, cols];
            GameGrid.Rows = rows;
            GameGrid.Columns = cols;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    images[i, j] = new Image() { Source = Images.Empty };
                    GameGrid.Children.Add(images[i, j]);
                }
            }
            return images;
        }


        private void StartClock()
        {
            clock.Start();
            clock.Interval = new TimeSpan(0, 0, 0, 0, 500);
            clock.Tick += new EventHandler(TickEvent);
        }

       
        private void TickEvent(object sender, EventArgs e)
        {
            gamestate.MoveSnake(direction);
            Draw();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.W:
                    direction = DirectionState.Up;
                    break;
                case Key.A:
                    direction = DirectionState.Left;
                    break;
                case Key.S:
                    direction = DirectionState.Down;
                    break;
                case Key.D:
                    direction = DirectionState.Right;
                    break;
            }
        }

    }
}
