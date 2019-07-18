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
        public double Teta { get; set; }
        public Lines(Point position, double thickness, double teta, double length, string label = "")
            :base(position, thickness, label)
        {
            Teta = teta;
            Length = length;
        }
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

        public override UIElement GetLabel()
        {
            Label label = new Label() { Content =Label, FontSize = 10 };
            Canvas.SetTop(label, Position.Y + 15 * Math.Cos(Teta) - 15 );
            Canvas.SetLeft(label, Position.X - 15* Math.Sin(Teta) - 8);
            return label;
        }
    }
}
