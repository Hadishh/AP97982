using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace P1
{
    public class AroundPoint : IUserInterface
    {
        public double Thikness { get; set; }
        public Point Point { get; set; }
        public Brush Color = Brushes.Black;
        public AroundPoint(Point place, double thikness)
        {
            Point = place;
            Thikness = thikness;
        }

        public UIElement GetUI()
        {
            var dot =  new Ellipse() { Width = Thikness, Height = Thikness, Fill = Color };
            Canvas.SetLeft(dot, Point.X - Thikness / 2);
            Canvas.SetBottom(dot, Point.Y - Thikness / 2);
            return dot;
        }
    }
}
