using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace P1
{
    public abstract class Axis : IGrid
    {
        public Label Label { get; set; }
        protected Canvas ParentCanvas { get; set; }
        protected Line MainLine { get; set; } 
        protected Point Center { get; set; }
        protected double LengthOfEachPart { get; set; }
        protected double Delta { get; set; }
        protected int Scale { get; set; }
        protected double Margin { get; set; }
        public Axis(Canvas parentCanvas, double delta, double lengthOfEachPart, int scale, double margin = 0)
        {
            ParentCanvas = parentCanvas;
            Margin = margin;
            Delta = delta;
            Center = new Point();
            LengthOfEachPart = lengthOfEachPart;
            Scale = scale;
        }
        protected List<int> SetNewNumbers(List<int> numbers, int v)
        {
            int multiple = numbers.Count / v;
            return numbers.Select(d => d * multiple).ToList();
        }
        public abstract void DrawGrid();
    }
}
