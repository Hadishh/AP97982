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
        /// <summary>
        /// returns x of the parent canvas center.
        /// </summary>
        public double CenterX => (ParentCanvas.ActualWidth + Margin) / 2 + Delta.X;
        public Y_Axis(Canvas parentCanvas, (double X, double Y) delta, double lengthofEachPart, int scale, double margin = 0) :
            base(parentCanvas, delta, lengthofEachPart, scale, margin)
        {
            base.MainLine = new Line();
            this.Label = new Label() { Content = "Y" };
        }
        /// <summary>
        /// Draws Main Line And the template Lines that are parallel to main line 
        /// </summary>
        public override void DrawGrid()
        {
            DrawMainLine();
            DrawTemplateLines();
        }
        /// <summary>
        /// Drawins main line by finding center of canvas 
        /// </summary>
        /// <returns></returns>
        private Line DrawMainLine()
        {
            double Y1 = 0;
            double Y2 = ParentCanvas.ActualHeight;
            double X = (ParentCanvas.ActualWidth + Margin) / 2  + Delta.X;
            base.MainLine.X1 = base.MainLine.X2 = X;
            if (X < 0 || X > ParentCanvas.ActualWidth)
                return MainLine;
            base.MainLine.Y2 = Y2;
            base.MainLine.Y1 = Y1;
            base.MainLine.Stroke = Brushes.Black;
            base.MainLine.StrokeThickness = 2;
            ParentCanvas.Children.Add(MainLine);
            return base.MainLine;
        }
        /// <summary>
        /// Draws template lines that are parallel to Y axis with distance LengthofEachPart .
        /// Draws Lables of each scale with difference Scale
        /// </summary>
        /// <returns></returns>
        private void DrawTemplateLines()
        {
            Application.Current.Dispatcher.BeginInvoke(
                (Action)(() =>
                {
                    if (IsDestroyed)
                        return;
                    List<Line> lines = new List<Line>();
                    double Y1 = 0;
                    double Y2 = ParentCanvas.ActualHeight;
                    double X = (ParentCanvas.ActualWidth + Margin ) / 2  + Delta.X;
                    double dynamicX = X + LengthOfEachPart;
                    for(int i = Scale; dynamicX <= ParentCanvas.ActualWidth + Margin; i += Scale, dynamicX += LengthOfEachPart)
                    {
                        if (dynamicX < -Margin)
                        {
                            int deltaScale = (int)((-Margin - dynamicX) / LengthOfEachPart);
                            i += deltaScale * Scale;
                            dynamicX += deltaScale * LengthOfEachPart;
                        }
                        Label label = new Label() { Content = i, FontSize = 7 };
                        if (Y2 / 2 - Delta.Y >= 0 && Y2 / 2 - Delta.Y <= ParentCanvas.ActualHeight)
                        {
                            Canvas.SetTop(label, Y2 / 2 - Delta.Y);
                            Canvas.SetLeft(label, dynamicX);
                        }
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
                        if (dynamicX > ParentCanvas.ActualWidth + Margin)
                        {
                            int deltaScale = (int)((dynamicX - (ParentCanvas.ActualWidth + Margin)) / LengthOfEachPart);
                            i -= deltaScale * Scale;
                            dynamicX -= deltaScale * LengthOfEachPart;
                        }
                        Label label = new Label() { Content = i, FontSize = 7 };
                        if (Y2 / 2 - Delta.Y >= 0 && Y2 / 2 - Delta.Y <= ParentCanvas.ActualHeight)
                        {
                            Canvas.SetTop(label, Y2 / 2 - Delta.Y);
                            Canvas.SetLeft(label, dynamicX);
                        }
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
