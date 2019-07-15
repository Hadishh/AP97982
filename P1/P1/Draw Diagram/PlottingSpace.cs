using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace P1
{
    public class PlottingSpace : IGrid
    {
        public (double Min, double Max) XBounds { get; set; } 
        public (double Min, double Max) YBounds { get; set; }
        X_Axis XAxis { get; set; }
        Y_Axis YAxis { get; set; }
        Point Center { get; set; }
        Canvas ParentCanvas { get; set; }
        double LengthOfEachPart { get; set; }
        int Scale { get; set; }
        public double Margin { get; set; }
        int DeltaX { get; set; }
        int DeltaY { get; set; }
        public double Accuracy { get; set; }

         Dictionary<Equation, Polyline> Charts { get; set; }
         public PlottingSpace((double Min, double Max) xBounds, (double Min, double Max) yBounds, Canvas parentCanvas, double lengthOfEachPart, int scale, double margin = 0)
         {
            Margin = margin;
            Center = new Point(0, 0);
            XBounds = xBounds;
            YBounds = yBounds;
            ParentCanvas = parentCanvas;
            LengthOfEachPart = lengthOfEachPart;
            Scale = scale;
            DeltaX = 0;
            DeltaY = 0;
            Charts = new Dictionary<Equation, Polyline>();
        }
        public void DrawGrid()
        {
            XAxis = new X_Axis(ParentCanvas, DeltaX, LengthOfEachPart, Scale, Margin);
            YAxis = new Y_Axis(ParentCanvas, DeltaY, LengthOfEachPart, Scale, Margin);
            Center = new Point(YAxis.CenterX, XAxis.CenterY);
            ParentCanvas.Children.Clear();
            XAxis.DrawGrid();
            YAxis.DrawGrid();
            DrawAddedEquations(Charts.Keys.ToList());
        }

        private void DrawAddedEquations(List<Equation> keys)
        {
            foreach (var equation in keys)
                DrawEquation(equation);
        }

        public void ZoomIn(int size)
        {
            LengthOfEachPart += size;
            DrawGrid();
        }
        /// <summary>
        /// Draws Equation add it to canvas. Add equation with polyline in Charts property.
        /// </summary>
        public void DrawEquation(Equation equation)
        {
            Application.Current.Dispatcher.BeginInvoke((Action)(() =>
            {
                Polyline chart = new Polyline();
                chart.StrokeThickness = 2;
                chart.Points = new PointCollection();
                if(equation.Function == null)
                {
                    if(Charts.ContainsKey(equation))
                    {
                        ParentCanvas.Children.Remove(Charts[equation]);
                        Charts.Remove(equation);
                    }
                    return;
                }
                chart.Stroke = equation.Color;
                double y = 0;
                for(double x = XBounds.Min; x <= XBounds.Max; x += Accuracy)
                {
                    //by adding y the canvas coordinates goes down so multiple by -1
                    y = -1 * equation.Function(x);
                    if(-1 * y > YBounds.Min && -1 * y < YBounds.Max)
                    {
                        Point project = ProjectOnPlot(new Point(x, y));
                        chart.Points.Add(project);
                    }
                }
                if (Charts.ContainsKey(equation))
                {
                    ParentCanvas.Children.Remove(Charts[equation]);
                    Charts[equation] = chart;
                }
                else
                    Charts.Add(equation, chart);
                ParentCanvas.Children.Add(chart);
            }));
            
        }

        private Point ProjectOnPlot(Point p) 
            => new Point(Center.X + p.X * LengthOfEachPart / Scale, Center.Y + p.Y * LengthOfEachPart / Scale);
    }
}
