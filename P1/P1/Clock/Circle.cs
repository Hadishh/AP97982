using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace P1
{
    public class Circle : Shape
    {
        Canvas ParentCanvas { get; set; }
        Point Center { get; set; }
        public Circle(double ratio, Canvas parentCanvas, List<AroundPoint> aroundPoints, bool enableLabel = false) : base(ratio, aroundPoints, enableLabel)
        {
            ParentCanvas = parentCanvas;
            Center = new Point(ParentCanvas.ActualWidth / 2, ParentCanvas.ActualHeight / 2);
        }
        public override void Draw()
        {
            foreach (var item in AroundPoints)
            {
                ParentCanvas.Children.Add(item.GetUI());
                if (EnableLabel)
                    ParentCanvas.Children.Add(item.GetLabel());
            }
            Ellipse r = new Ellipse { Width = 2 * Ratio + 10, Height = 2 * Ratio + 10 };
            r.Stroke = Brushes.Black;
            r.StrokeThickness = 2;
            Canvas.SetTop(r, Center.Y - Ratio - 5);
            Canvas.SetLeft(r, Center.X - Ratio - 5);
            ParentCanvas.Children.Add(r);
        }
    }
}
