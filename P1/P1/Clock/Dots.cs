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

        public Dots(Point position, double thickness, double teta, string label = "")
            : base(position, thickness, teta, label)
        { }
        /// <summary>
        /// returns an around point with dot shape.
        /// </summary>
        /// <returns></returns>
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
    }
}
