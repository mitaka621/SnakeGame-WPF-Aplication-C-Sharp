using Snake_Game.GameLogic;
using Snake_Game.Logic;
using Snake_Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        GameState gamestate = new GameState(rows, cols);
        DirectionState direction = DirectionState.Right;
        bool gameRunning;
        Dictionary<GridState, ImageSource> states = new Dictionary<GridState, ImageSource>()
        {
            {GridState.Empty, Images.Empty },
            {GridState.Snake, Images.Body },
            {GridState.Food, Images.Food },
        };
        DispatcherTimer clock = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            gridImages = SetUpGrid();
            DrawEmptyGrid();


            //gridImages[1, 2].Source = Images.Food;

        }
        private void DrawEmptyGrid()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    gridImages[i, j].Source = Images.Empty;
                }
            }
        }
        private void Draw()
        {

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {                   
                    gridImages[i, j].Source = states[gamestate.GetState()[i, j]];                 
                }
            }
            DrawHead();
        }
        private void DrawHead()
        {
         var head= gamestate.GetSnake().First();

            Image image = gridImages[head.Row, head.Col];

            
            switch (direction)
            {
                case DirectionState.Up:
                    break;
                case DirectionState.Down:
                    image.RenderTransform = new RotateTransform(180) { CenterX = image.ActualHeight / 2, CenterY = image.ActualWidth / 2 }; ;
                    break;
                case DirectionState.Left:
                    image.RenderTransform = new RotateTransform(270) { CenterX = image.ActualHeight / 2, CenterY = image.ActualWidth / 2 };
                    break;
                case DirectionState.Right:
                    image.RenderTransform = new RotateTransform(90) { CenterX = image.ActualHeight / 2, CenterY = image.ActualWidth / 2 };
                    break;
                default:
                    break;
            }

            image.Source = Images.Head;
        }
        public async Task DrawDeadSnake()
        {
            Draw();
            foreach (var item in gamestate.GetSnake())
            {
                gridImages[item.Row, item.Col].Source = Images.DeadBody;
                await Task.Delay(10);
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


        private void StartGame()
        {
            clock.Start();
            clock.Interval = new TimeSpan(0, 0, 0, 0, 100);
            clock.Tick += new EventHandler(TickEvent);
        }

        private async Task EndGame()
        {
            clock.Stop();
            clock.Tick -= new EventHandler(TickEvent);
            
            direction = DirectionState.Right;
            ScoreBlock.Text = "SCORE 0";
            await DrawDeadSnake();
            gamestate = new GameState(rows, cols);

            await Task.Delay(2000);
            gameRunning = false;
            DrawEmptyGrid();
            Overlay.Visibility = Visibility.Visible;
        }

        private async void TickEvent(object sender, EventArgs e)
        {

            if (!gamestate.MoveSnake(direction))
            {
               
                await EndGame();
            }
            else
            {
                ScoreBlock.Text = "SCORE " + gamestate.Score.ToString();
                Draw();
            }
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (!gameRunning)
            {
               
                Overlay.Visibility = Visibility.Hidden;

                gameRunning = true;
                StartGame();
            }

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameRunning)
            {
                switch (e.Key)
                {
                    case Key.W:
                    case Key.Up:
                        direction = DirectionState.Up;
                        break;
                    case Key.A:
                    case Key.Left:
                        direction = DirectionState.Left;
                        break;
                    case Key.S:
                    case Key.Down:
                        direction = DirectionState.Down;
                        break;
                    case Key.D:
                    case Key.Right:
                        direction = DirectionState.Right;
                        break;
                }
            }
        }

    }
}
