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
        public double Teta { get; set; }
        public AroundPoint(Point position, double thikness, double teta, string label)
        {
            Position = position;
            Thikness = thikness;
            Label = label;
            Teta = teta;
        }

        public abstract UIElement GetUI();
        
        /// <summary>
        /// returns label of this around ponit;
        /// </summary>
        /// <returns></returns>
        public virtual UIElement GetLabel()
        {
            Label label = new Label() { Content = Label, FontSize = 10 };
            Canvas.SetTop(label, Position.Y + 15 * Math.Cos(Teta) - 15);
            Canvas.SetLeft(label, Position.X - 15 * Math.Sin(Teta) - 8);
            return label;
        }
    }
}
