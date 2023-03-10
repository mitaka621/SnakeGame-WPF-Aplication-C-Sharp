using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Snake_Game.Models
{
    public static class Images
    {
        public static readonly ImageSource Empty = LoadImage("Empty.png");
        public static readonly ImageSource Body = LoadImage("Body.png");
        public static readonly ImageSource Head = LoadImage("Head.png");
        public static readonly ImageSource Food = LoadImage("Food.png");
        public static readonly ImageSource DeadBody = LoadImage("DeadBody.png");
        public static readonly ImageSource DeadHead = LoadImage("DeadHead.png");
        private static ImageSource LoadImage(string filename)
        {
            return new BitmapImage(new Uri($"Assets/{filename}", UriKind.Relative));
        }
    }
}
