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
            :base(position, thickness)
        {
            Teta = teta;
            Length = length;
            Label = label;
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
            Label label = new Label() { Content = "1", FontSize = 10,
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center
                
            };
            Canvas.SetTop(label, Position.Y -5);
            Canvas.SetLeft(label, Position.X - 5);
            return label;
        }
    }
}
