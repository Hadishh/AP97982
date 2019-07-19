using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows;

namespace P1
{
    public class Hand : IUserInterface
    {
        public Line HandLine { get; set; }
        public Hand(Point firstPoint, Point secondPoint)
        {
            HandLine = new Line();
            HandLine.X1 = firstPoint.X;
            HandLine.X2 = secondPoint.X;
            HandLine.Y1 = firstPoint.Y;
            HandLine.Y2 = secondPoint.Y ;
            HandLine.Stroke = Brushes.Black;
            HandLine.StrokeThickness = 3;
        }
        /// <summary>
        /// Retruns the hand of the clock
        /// </summary>
        /// <returns></returns>
        public UIElement GetUI()
          => HandLine;
    }
}
