using Snake_Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Snake_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int rows = 15, cols = 15;
        private Image[,] gridImages;
        public MainWindow()
        {
            InitializeComponent();
            gridImages = SetUpGrid();
            gridImages[1,2].Source=gridVal
        }
        private Image[,] SetUpGrid()
        {
            Image[,] images=new Image[rows, cols];
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
    }
}
