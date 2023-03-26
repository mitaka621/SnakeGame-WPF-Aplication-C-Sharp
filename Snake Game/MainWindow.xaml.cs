using Snake_Game.Core.Engine;
using Snake_Game.Core.Interfaces;
using Snake_Game.GameLogic;
using Snake_Game.GameLogic.Enums;
using Snake_Game.Logic;
using Snake_Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        DirectionState direction = DirectionState.Right;
        IEngine engine;
        TimeSpan gamespeed;
        GameDifficulty gameDifficulty;
        int rows = 0, cols = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (OverlayText.Text == "PRESS ANY KEY TO START" && Overlay.Visibility == Visibility.Visible&& StartMenu.Visibility == Visibility.Hidden)    
                
                engine.StartGame();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Overlay.Visibility == Visibility.Hidden)
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
                engine.Move(direction);
            }
        }

        void StartGame()
        {
            engine = new Engine(rows, cols, gamespeed,gameDifficulty);
            StartMenu.Visibility = Visibility.Hidden;
        }

        private void SmallestGridButton_Click(object sender, RoutedEventArgs e)
        {
            rows = 15;
            cols = 18;
            gamespeed = new TimeSpan(0, 0, 0, 0, 150);
            ChooseGridSize.Visibility = Visibility.Hidden;
            ChooseDificulty.Visibility = Visibility.Visible;
            
        }

        private void MiddleSizeGridButton_Click(object sender, RoutedEventArgs e)
        {
            rows = 30;
            cols = 36;
            gamespeed = new TimeSpan(0, 0, 0, 0, 120);
            ChooseGridSize.Visibility = Visibility.Hidden;
            ChooseDificulty.Visibility = Visibility.Visible;
           
        }
        private void BiggestGridButton_Click(object sender, RoutedEventArgs e)
        {
            rows = 75;
            cols = 90;
            gamespeed = new TimeSpan(0, 0, 0, 0, 50);
            ChooseGridSize.Visibility = Visibility.Hidden;
            ChooseDificulty.Visibility = Visibility.Visible;
            
        }

        private void EasyDifficultyButton_Click(object sender, RoutedEventArgs e)
        {
            gameDifficulty = GameDifficulty.easy;
            StartGame();
        }

        private void MediumDifficultyButton_Click(object sender, RoutedEventArgs e)
        {
            gameDifficulty = GameDifficulty.medium;
            gamespeed *=0.75;
            StartGame();
        }

        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            intro.Position = TimeSpan.FromMilliseconds(1);

        }

        private void HardDifficultyButton_Click(object sender, RoutedEventArgs e)
        {
            gameDifficulty = GameDifficulty.hard;
            gamespeed *=0.60;
            StartGame();
        }

        
    }
}
