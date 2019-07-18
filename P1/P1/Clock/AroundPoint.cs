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
    public abstract class AroundPoint : IUserInterface
    {
        public double Thikness { get; set; }
        public Point Position { get; set; }
        public Brush Color = Brushes.Black;
        public string Label { get; set; }
        public AroundPoint(Point position, double thikness, string label)
        {
            Position = position;
            Thikness = thikness;
            Label = label;
        }

        public abstract UIElement GetUI();
        public abstract UIElement GetLabel();
    }
}
