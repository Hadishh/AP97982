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
    public class Lines : AroundPoint
    {
        public double Length { get; set; }
        public Lines(Point position, double thickness, double teta, double length, string label = "")
            :base(position, thickness, teta, label)
        {
            Length = length;
        }
        /// <summary>
        /// Returns a line for each around point.
        /// </summary>
        /// <returns></returns>
        public override UIElement GetUI()
        {
            Line line = new Line();
            line.Stroke = Color;
            line.StrokeThickness = Thikness;
            line.X1 = Position.X ;
            line.X2 = Position.X - Length * Math.Sin(Teta);
            line.Y1 = Position.Y;
            line.Y2 = Position.Y + Length* Math.Cos(Teta);
            return line;
        }
        
    }
}
