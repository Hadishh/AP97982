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
        double DeltaX { get; set; }
        double DeltaY { get; set; }
        public double Accuracy { get; set; }

         Dictionary<Equation, Chart> Charts { get; set; }
         public PlottingSpace((double Min, double Max) xBounds, (double Min, double Max) yBounds, Canvas parentCanvas, int scale, double margin = 0)
         {
            Margin = margin;
            Center = new Point(0, 0);
            XBounds = xBounds;
            YBounds = yBounds;
            ParentCanvas = parentCanvas;
            LengthOfEachPart = 10;
            Application.Current.MainWindow.PreviewMouseMove += EquationCanvas_MouseMove;
            Application.Current.MainWindow.PreviewMouseWheel += EquationCanvas_MouseWheel;
            Scale = scale;
            DeltaX = 0;
            DeltaY = 0;
            Accuracy = 0.1;
            Charts = new Dictionary<Equation, Chart>();
        }

        /// <summary>
        /// Last Position of Mouse 
        /// </summary>
        Point LastPosition;
        /// <summary>
        /// Moving event and moving plot and equations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EquationCanvas_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                if (LastPosition.X == 0 & LastPosition.Y == 0)
                    LastPosition = e.GetPosition(null);
                else
                {
                    Point currentPosition = e.GetPosition(null);
                    MoveY((currentPosition.Y - LastPosition.Y));
                    MoveX((currentPosition.X - LastPosition.X));
                    LastPosition = currentPosition;
                    DrawGrid();
                    DrawAddedEquations();
                }
            }
            else
                LastPosition = new Point(0, 0);
        }


        /// <summary>
        /// Zoom in and out event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EquationCanvas_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            if (e.Delta < 0)
            {
                ZoomOut(5);
                DrawGrid();
                if (Accuracy < 0.1)
                    Accuracy *= 2;
                DrawAddedEquations();
            }
            if (e.Delta > 0)
            {
                ZoomIn(5);
                DrawGrid();
                if (Accuracy > 0.01)
                    Accuracy /= 2;
                DrawAddedEquations();
            }
        }

        /// <summary>
        /// Draws grid lines.
        /// </summary>
        public void DrawGrid()
        {
            XAxis = new X_Axis(ParentCanvas, (DeltaX, DeltaY), LengthOfEachPart, Scale, Margin);
            YAxis = new Y_Axis(ParentCanvas, (DeltaX, DeltaY), LengthOfEachPart, Scale, Margin);
            Center = new Point(YAxis.CenterX, XAxis.CenterY);
            ParentCanvas.Children.Clear();
            XAxis.DrawGrid();
            YAxis.DrawGrid();
        }
        /// <summary>
        /// Draw equations in Charts
        /// </summary>
        public void DrawAddedEquations()
        {
            foreach (var equation in Charts.Keys.ToList())
                DrawEquation(equation);
        }
        /// <summary>
        /// Zoming in by increasing length of each part or decreasing scale
        /// </summary>
        /// <param name="size"></param>
        public void ZoomIn(int size)
        {
            if (Scale > 1)
                Scale -= 1;
            else
            {
                LengthOfEachPart += size;
                DrawGrid();
            }
        }
        /// <summary>
        /// Zoom out by decreasing length of each part or incresing scale
        /// </summary>
        /// <param name="size"></param>
        public void ZoomOut(int size)
        {
            if(LengthOfEachPart  - size <= 10)
            {
                Scale += 1;
            }
            else
            {
                LengthOfEachPart -= size;
            }
        }
        /// <summary>
        /// Increasing causes Moving to left and decreasing causes moving to right
        /// </summary>
        /// <param name="size"></param>
        public void MoveX(double size)
        {
            DeltaX += size;
        }
        /// <summary>
        /// Decreasing causes moving to up and decreasing causes moving down
        /// </summary>
        /// <param name="size"></param>
        public void MoveY(double size)
        {
            DeltaY -= size;
        }
        /// <summary>
        /// Draws Equation add it to canvas. Add equation with polyline in Charts property.
        /// </summary>
        public void DrawEquation(Equation equation)
        {
            Application.Current.Dispatcher.BeginInvoke((Action)(() =>
            {
                if(equation.Function == null)
                {
                    if(Charts.ContainsKey(equation))
                    {
                        Charts[equation].Delete(ParentCanvas);
                        Charts.Remove(equation);
                    }
                    return;
                }
                Chart chart = new Chart(2, equation.Color);
                double y = 0;
                for(double x = XBounds.Min; x <= XBounds.Max; x += Accuracy)
                {
                    y = equation.Function(x);
                    if(y > YBounds.Min &&  y < YBounds.Max)
                    {
                        //by growing y the canvas coordinates goes down so multiple by -1
                        Point project = ProjectOnPlot(new Point(x, -y));
                        if (project.Y > 0 && project.Y < ParentCanvas.ActualHeight)
                        {
                            if ( (x < Accuracy / 2 && x > -Accuracy / 2) || (y < Accuracy / 2 && y > -Accuracy / 2))
                            {
                                Ellipse meetingEllipse = new Ellipse() { Width = 6, Height = 6, Fill = Brushes.Gray, StrokeThickness = 5,Stroke = Brushes.Gray };
                                Canvas.SetTop(meetingEllipse, project.Y - meetingEllipse.Height / 2);
                                Canvas.SetLeft(meetingEllipse, project.X - meetingEllipse.Width / 2);
                                chart.Ellipses.Add(meetingEllipse);
                            }
                            chart.Polyline.Points.Add(project);
                        }
                    }
                }
                if (Charts.ContainsKey(equation))
                {
                    Charts[equation].Delete(ParentCanvas);
                    Charts[equation] = chart;
                }
                else
                    Charts.Add(equation, chart);
                chart.Draw(ParentCanvas);
            }));
            
        }

        /// <summary>
        /// Deletes specific equation.
        /// </summary>
        /// <param name="equation"></param>
        public void DeleteEquation(Equation equation)
        {
            Charts[equation].Delete(ParentCanvas);
            Charts.Remove(equation);
        }

        /// <summary>
        /// Projection of any point on canvas coordinates
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private Point ProjectOnPlot(Point p) 
            => new Point(Center.X + p.X * LengthOfEachPart / Scale, Center.Y + p.Y * LengthOfEachPart / Scale);

        public void Destroy()
        {
            Charts.Clear();
            XAxis.Destroy();
            YAxis.Destroy();
            Application.Current.MainWindow.PreviewMouseMove -= EquationCanvas_MouseMove;
            Application.Current.MainWindow.PreviewMouseWheel -= EquationCanvas_MouseWheel;
            ParentCanvas.Children.Clear();
            XAxis = null;
            YAxis = null;
            ParentCanvas = null;
            Charts = null;
        }
    }
}
