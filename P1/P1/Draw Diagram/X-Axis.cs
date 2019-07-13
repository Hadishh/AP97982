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
    public class X_Axis : Axis
    {
        public X_Axis(Canvas parentCanvas, int min, int max) :
            base(parentCanvas, min, max)
        {
            this.Line = new Line();
            this.Label = new Label() { Content = "X" };
        }
        public override void DrawGrids()
        {
            double X1 = 0;
            double X2 = ParentCanvas.Width;
            double Y = ParentCanvas.Height / 2;
            Line.X1 = X1;
            Line.X2 = X2;
            Line.Y1 = Line.Y2 = Y;
            Line.Stroke = Brushes.Black;
            Line.StrokeThickness = 2;
            Canvas.SetTop(Label, Y * 99 / 100);
            Canvas.SetLeft(Label, 540);
            ParentCanvas.Children.Add(Line);
            double lengthofEachPart = 10;
            if (Numbers.Count > 100)
                Numbers = SetNewNumbers(Numbers, 100);
            double dynamicX = 0;
            for (int i = 0; i < 100; i++, dynamicX += lengthofEachPart)
            {
                Label label = new Label() { Content =  Numbers[i], FontSize = 7};
                Line tmpLine = new Line();
                tmpLine.X1 = tmpLine.X2 = dynamicX;
                tmpLine.Y1 = 0;
                tmpLine.Y2 = ParentCanvas.Height;
                tmpLine.Stroke = Brushes.Gray;
                tmpLine.StrokeThickness = 1;
                NumberLabel.Add(Label);
                Canvas.SetTop(label, Y);
                Canvas.SetLeft(label, dynamicX);
                ParentCanvas.Children.Add(tmpLine);
                ParentCanvas.Children.Add(label);
            }
        }
    }
}
