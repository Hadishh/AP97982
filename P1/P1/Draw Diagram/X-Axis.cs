﻿using System;
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
    public class X_Axis : Axis
    {
        
        /// <summary>
        /// retruns Center of The plot for drawing chart
        /// </summary>
        public double CenterY => (ParentCanvas.ActualHeight) / 2 - Delta.Y;
        
        public X_Axis(Canvas parentCanvas, (double X, double Y) delta, double lengthofEachPart, int scale, double margin = 0) :
            base(parentCanvas, delta, lengthofEachPart, scale, margin)
        {
            base.MainLine = new Line();
            this.Label = new Label() { Content = "X" };
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
            double X1 = -Margin;
            double X2 = ParentCanvas.ActualWidth + Margin;
            double Y = (ParentCanvas.ActualHeight) / 2 - Delta.Y;
            if (Y > ParentCanvas.ActualWidth || Y < 0)
                return MainLine;
            base.MainLine.Y1 = base.MainLine.Y2 = Y;
            base.MainLine.X2 = X2;
            base.MainLine.X1 = X1;
            base.MainLine.Stroke = Brushes.Black;
            base.MainLine.StrokeThickness = 2;
            ParentCanvas.Children.Add(MainLine);
            return base.MainLine;
        }
        /// <summary>
        /// Draws template lines that are parallel to X axis with distance LengthofEachPart .
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
                    double X1 = -Margin;
                    double X2 = ParentCanvas.ActualWidth + Margin;
                    double Y = (ParentCanvas.ActualHeight) / 2  - Delta.Y;
                    double dynamicY = Y - LengthOfEachPart;
                    for (int i = Scale; dynamicY >= 0; i += Scale, dynamicY -= LengthOfEachPart)
                    {
                        if (dynamicY > ParentCanvas.ActualHeight)
                        {
                           int deltaScale = (int)((dynamicY - ParentCanvas.ActualHeight) / LengthOfEachPart);
                           i += deltaScale * Scale;
                           dynamicY -= deltaScale * LengthOfEachPart;
                        }
                        Label label = new Label() { Content = i, FontSize = 7 };
                        Canvas.SetTop(label, dynamicY);
                        Canvas.SetLeft(label, X2 / 2 + Delta.X);
                        Line tmpLine = new Line();
                        tmpLine.Y1 = tmpLine.Y2 = dynamicY;
                        tmpLine.X1 = X1;
                        tmpLine.X2 = X2;
                        tmpLine.StrokeThickness = 1;
                        tmpLine.Stroke = Brushes.Gray;
                        lines.Add(tmpLine);
                        ParentCanvas.Children.Add(tmpLine);
                        ParentCanvas.Children.Add(label);
                    }
                    dynamicY = Y + LengthOfEachPart;
                    for (int i = -Scale; dynamicY <= ParentCanvas.ActualHeight; i -= Scale, dynamicY += LengthOfEachPart)
                    {
                        if (dynamicY < 0)
                        {
                            int deltaScale = (int)(-dynamicY / LengthOfEachPart);
                            i -= deltaScale * Scale;
                            dynamicY += deltaScale * LengthOfEachPart;
                        }
                        Label label = new Label() { Content = i, FontSize = 7 };
                        Canvas.SetTop(label, dynamicY);
                        Canvas.SetLeft(label, X2 / 2 - 5 + Delta.X);
                        Line tmpLine = new Line();
                        tmpLine.Y1 = tmpLine.Y2 = dynamicY + 2;
                        tmpLine.X1 = X1;
                        tmpLine.X2 = X2;
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
