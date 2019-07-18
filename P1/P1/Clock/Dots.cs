using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace P1
{
    public class Dots : AroundPoint
    {
        public double Teta { get; set; }
        public Dots(Point position, double thickness, double teta, string label = "")
            : base(position, thickness, label)
        {
            Teta = teta;
        }
        public override UIElement GetUI()
        {
            Ellipse ellipse = new Ellipse() { Width = Thikness, Height = Thikness };
            ellipse.Stroke = Color;
            ellipse.StrokeThickness = Thikness;
            ellipse.Fill = Color;
            Canvas.SetTop(ellipse, Position.Y - Thikness / 2);
            Canvas.SetLeft(ellipse, Position.X - Thikness / 2);
            return ellipse;
        }

        public override UIElement GetLabel()
        {
            Label label = new Label() { Content = Label, FontSize = 10 };
            Canvas.SetTop(label, Position.Y + 15 * Math.Cos(Teta) - 15);
            Canvas.SetLeft(label, Position.X - 15 * Math.Sin(Teta) - 8);
            return label;
        }
    }
}
