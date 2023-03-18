using Snake_Game.Core.Interfaces;
using Snake_Game.GameLogic;
using Snake_Game.GameLogic.Enums;
using Snake_Game.GameLogic.Models;
using Snake_Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Snake_Game.Core.Engine
{

    public class Engine : GridSize, IEngine
    {
        Image[,] gridImages;
        GameState gamestate;
        TimeOnly gametime;
        TimeSpan timespan;
        DirectionState direction = DirectionState.Right;
        MainWindow main = Application.Current.Windows[0] as MainWindow;
        Dictionary<GridState, ImageSource> states;
        DispatcherTimer clock = new DispatcherTimer();
        int rotateBoarderDegrees;
        public Engine(int gridRows, int gridCols, TimeSpan gameSpeed) : base(gridRows, gridCols)
        {
            gamestate = new GameState(gridRows, gridCols);
            states = new Dictionary<GridState, ImageSource>()
            {
                {GridState.Empty, ImageLoader.Empty },
                {GridState.Snake, ImageLoader.Body },
                {GridState.Food, ImageLoader.Food },
            };
            timespan = gameSpeed;

            gridImages = SetUpGrid();
            rotateBoarderDegrees = 113;
            DrawEmptyGrid();

        }

        private void TickEvent(object sender, EventArgs e)
        {

            if (!gamestate.MoveSnake(direction))
            {
                StopGame();
            }
            else
            {
                main.ScoreBlock.Text = "SCORE " + gamestate.Score.ToString();
                gametime = gametime.Add(timespan);
                main.TimeBlock.Text = String.Format("{0:00}:{1:00}:{2:000}", gametime.Minute, gametime.Second, gametime.Millisecond);
                Draw();
                RotateUIBorder();
                
                //IncreaseGameSpeed(); ->TODO fix
                
               
            }
        }

        public async void StartGame()
        {
            
            await CountDown();
            main.Overlay.Visibility = Visibility.Hidden;
            clock.Start();
            gametime = new TimeOnly();
            
            clock.Interval = timespan;
            clock.Tick += new EventHandler(TickEvent);
        }

        public async void StopGame()
        {
           
            
                
            clock.Stop();
            clock.Tick -= new EventHandler(TickEvent);

            direction = DirectionState.Right;
            await DrawDeadSnake();
            gamestate = new GameState(GridRows, GridCols);
            await Task.Delay(2000);

            DrawEmptyGrid();
            main.Overlay.Visibility = Visibility.Visible;
        }

       
        int angle = 115;
        private void HighestScoreRotateBorder(object sender, EventArgs e)
        {
            main.rotateBorder2.Angle = angle;
            angle++;

            //TODO

        }
        public void Move(DirectionState dir)
        {
            direction = dir;
        }

        private void Draw()
        {

            for (int i = 0; i < GridRows; i++)
            {
                for (int j = 0; j < GridCols; j++)
                {
                    gridImages[i, j].Source = states[gamestate.GetState()[i, j]];
                }
            }
            DrawHead();
        }

        private void DrawHead()
        {
            var head = gamestate.GetSnake().First();
            Image image = gridImages[head.Row, head.Col];

            switch (gamestate.LastDirection)
            {
                case DirectionState.Up:
                    image.RenderTransform = new RotateTransform(0) { CenterX = image.ActualHeight / 2, CenterY = image.ActualWidth / 2 };
                    break;
                case DirectionState.Down:
                    image.RenderTransform = new RotateTransform(180) { CenterX = image.ActualHeight / 2, CenterY = image.ActualWidth / 2 }; 
                    break;
                case DirectionState.Left:
                    image.RenderTransform = new RotateTransform(270) { CenterX = image.ActualHeight / 2, CenterY = image.ActualWidth / 2 };
                    break;
                case DirectionState.Right:
                    image.RenderTransform = new RotateTransform(90) { CenterX = image.ActualHeight / 2, CenterY = image.ActualWidth / 2 };
                    break;

            }

            image.Source = ImageLoader.Head;


        }
        private async Task DrawDeadSnake()
        {
            Draw();
            foreach (var item in gamestate.GetSnake())
            {
                gridImages[item.Row, item.Col].Source = ImageLoader.DeadBody;
                await Task.Delay(20);
            }

        }
        private void DrawEmptyGrid()
        {
            for (int i = 0; i < GridRows; i++)
            {
                for (int j = 0; j < GridCols; j++)
                {
                    gridImages[i, j].Source = ImageLoader.Empty;
                }
            }
        }
        private void IncreaseGameSpeed()
        {
            if (gamestate.Score%10==0)
            {
               TimeSpan increseSpeed = timespan-new TimeSpan(0,0,0,0,10);
                clock.Interval = timespan;
            }
        }
        private void RotateUIBorder()
        {
            main.RotateBoarder.Angle = rotateBoarderDegrees;
            rotateBoarderDegrees +=3;
            if (rotateBoarderDegrees == 360)
            {
                rotateBoarderDegrees = 0;
            }
        }

        private async Task CountDown(int countdown = 3)
        {
            Draw();
            for (int i = countdown; i > 0; i--)
            {
                main.OverlayText.Text = countdown--.ToString();
                await Task.Delay(500);
            }

            main.OverlayText.Text = "PRESS ANY KEY TO START";
        }
        
        private Image[,] SetUpGrid()
        {
            Image[,] images = new Image[GridRows, GridCols];
            main.GameGrid.Rows = GridRows;
            main.GameGrid.Columns = GridCols;
            for (int i = 0; i < GridRows; i++)
            {
                for (int j = 0; j < GridCols; j++)
                {
                    images[i, j] = new Image() { Source = ImageLoader.Empty };
                    main.GameGrid.Children.Add(images[i, j]);
                }
            }
            return images;
        }

    }
}
