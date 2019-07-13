using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace P1
{
    public class Y_Axis : Axis
    {
        public Y_Axis(Canvas parentCanvas, int min, int max) :
            base(parentCanvas, min, max)
        {
            this.Line = new Line();
            this.Label = new Label() { Content = "Y" };
        }
        public override void DrawGrids()
        {
            double Y1 = 0;
            double Y2 = ParentCanvas.Height;
            double X = ParentCanvas.Width / 2;
            Line.X1 = Line.X2 = X;
            Line.Y2 = Y2;
            Line.Y1 = Y1;
            Line.Stroke = Brushes.Black;
            Line.StrokeThickness = 2;
            Canvas.SetTop(Label, ParentCanvas.Height / 50);
            Canvas.SetLeft(Label, X);
            ParentCanvas.Children.Add(Line);
            double lengthofEachPart = 10;
            if (Numbers.Count > 100)
                Numbers = SetNewNumbers(Numbers, 100);
            double dynamicY = 0;
            for (int i = 0; i < 100; i++, dynamicY += lengthofEachPart)
            {
                Label label = new Label() { Content = Numbers[i], FontSize = 7 };
                Line tmpLine = new Line();
                tmpLine.Y1 = tmpLine.Y2 = dynamicY;
                tmpLine.X1 = 0;
                tmpLine.X2 = ParentCanvas.Width;
                tmpLine.Stroke = Brushes.Gray;
                tmpLine.StrokeThickness = 1;
                NumberLabel.Add(Label);
                Canvas.SetTop(label, dynamicY);
                Canvas.SetLeft(label, X);
                ParentCanvas.Children.Add(tmpLine);
                ParentCanvas.Children.Add(label);
            }
        }
    }
}
