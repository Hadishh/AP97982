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

        Canvas ParentCanvas { get; set; }
        Point Center { get; set; }
        public Square(double ratio, Canvas parentCanvas, List<AroundPoint> aroundPoints) : base (ratio, aroundPoints)
        {
            ParentCanvas = parentCanvas;
            Center = new Point(ParentCanvas.ActualWidth / 2, ParentCanvas.ActualHeight / 2);
        }
        public override void Draw()
        {
            foreach (var item in AroundPoints)
                ParentCanvas.Children.Add(item.GetUI());
            Rectangle r = new Rectangle { Width = 2*Ratio + 10, Height = 2*Ratio + 10 };
            r.Stroke = Brushes.Black;
            r.StrokeThickness = 2;
            Canvas.SetTop(r, Center.Y - Ratio - 5);
            Canvas.SetLeft(r, Center.X - Ratio - 5);
            ParentCanvas.Children.Add(r);
        }
    }
}
