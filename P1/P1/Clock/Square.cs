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
    class Square : Shape
    {

        Point Center { get; set; }
        public Square(double ratio, Canvas parentCanvas, List<AroundPoint> aroundPoints, bool enableLabel = false) 
            : base (ratio, aroundPoints, parentCanvas, enableLabel)
        {
            Center = new Point(ParentCanvas.ActualWidth / 2, ParentCanvas.ActualHeight / 2);
        }
        /// <summary>
        /// Draws a rectangle with all labels and around points.
        /// </summary>
        public override void Draw()
        {
            foreach (var item in AroundPoints)
            {
                ParentCanvas.Children.Add(item.GetUI());
                if(EnableLabel)
                    ParentCanvas.Children.Add(item.GetLabel());
            }
            Rectangle r = new Rectangle { Width = 2*Ratio + 10, Height = 2*Ratio + 10 };
            r.Stroke = Brushes.Black;
            r.StrokeThickness = 2;
            Canvas.SetTop(r, Center.Y - Ratio - 5);
            Canvas.SetLeft(r, Center.X - Ratio - 5);
            ParentCanvas.Children.Add(r);
        }
    }
}
