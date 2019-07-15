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
    public class Y_Axis : Axis
    {
        public double CenterX => (ParentCanvas.ActualWidth + Margin) / 2 - Delta;
        public Y_Axis(Canvas parentCanvas, int delta, double lengthofEachPart, int scale, double margin = 0) :
            base(parentCanvas, delta, lengthofEachPart, scale, margin)
        {
            base.MainLine = new Line();
            this.Label = new Label() { Content = "Y" };
        }
        public override void DrawGrid()
        {
            DrawMainLine();
            DrawTemplateLines();
        }
        private Line DrawMainLine()
        {
            double Y1 = 0;
            double Y2 = ParentCanvas.ActualHeight;
            double X = (ParentCanvas.ActualWidth + Margin) / 2  - Delta;
            base.MainLine.X1 = base.MainLine.X2 = X;
            base.MainLine.Y2 = Y2;
            base.MainLine.Y1 = Y1;
            base.MainLine.Stroke = Brushes.Black;
            base.MainLine.StrokeThickness = 2;
            ParentCanvas.Children.Add(MainLine);
            return base.MainLine;
        }
        private void DrawTemplateLines()
        {
            Application.Current.Dispatcher.BeginInvoke(
                (Action)(() =>
                {
                    List<Line> lines = new List<Line>();
                    double Y1 = 0;
                    double Y2 = ParentCanvas.ActualHeight;
                    double X = (ParentCanvas.ActualWidth + Margin ) / 2  - Delta;
                    double dynamicX = X + LengthOfEachPart;
                    for(int i = Scale; dynamicX <= ParentCanvas.ActualWidth + Margin; i += Scale, dynamicX += LengthOfEachPart)
                    {
                        Label label = new Label() { Content = i, FontSize = 7 };
                        Canvas.SetTop(label, Y2 / 2);
                        Canvas.SetLeft(label, dynamicX);
                        Line tmpLine = new Line();
                        tmpLine.X1 = tmpLine.X2 = dynamicX;
                        tmpLine.Y1 = Y1;
                        tmpLine.Y2 = Y2;
                        tmpLine.StrokeThickness = 1;
                        tmpLine.Stroke = Brushes.Gray;
                        lines.Add(tmpLine);
                        ParentCanvas.Children.Add(tmpLine);
                        ParentCanvas.Children.Add(label);
                    }
                    dynamicX = X - LengthOfEachPart;
                    for (int i = -Scale; dynamicX >= -Margin; i -= Scale, dynamicX -= LengthOfEachPart)
                    {
                        Label label = new Label() { Content = i, FontSize = 7 };
                        Canvas.SetTop(label, Y2 / 2);
                        Canvas.SetLeft(label, dynamicX);
                        Line tmpLine = new Line();
                        tmpLine.X1 = tmpLine.X2 = dynamicX;
                        tmpLine.Y1 = Y1;
                        tmpLine.Y2 = Y2;
                        tmpLine.StrokeThickness = 1;
                        tmpLine.Stroke = Brushes.Gray;
                        lines.Add(tmpLine);
                        ParentCanvas.Children.Add(tmpLine);
                        ParentCanvas.Children.Add(label);
                    }
                }));
        }
    }
}
