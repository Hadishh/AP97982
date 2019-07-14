using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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
        double Margin { get; set; }
        int DeltaX { get; set; }
        int DeltaY { get; set; }

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
        }
        public void DrawGrid()
        {
            XAxis = new X_Axis(ParentCanvas, DeltaX, LengthOfEachPart, Scale, Margin);
            YAxis = new Y_Axis(ParentCanvas, DeltaY, LengthOfEachPart, Scale, Margin);
            ParentCanvas.Children.Clear();
            XAxis.DrawGrid();
            YAxis.DrawGrid();
        }
        public void ZoomIn(int size)
        {
            LengthOfEachPart += size;
            DrawGrid();
        }

        public void DrawEquation()
        {
            
        }
    }
}
