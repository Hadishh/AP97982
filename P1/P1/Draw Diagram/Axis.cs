using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace P1
{
    public abstract class Axis
    {
        protected Canvas ParentCanvas { get; set; }
        protected int Min { get; set; }
        protected int Max { get; set; }
        protected Line Line { get; set; } 
        public List<int> Numbers { get; set; }
        public Label Label { get; set; }
        protected List<Label> NumberLabel { get; set; }
        public Axis(Canvas parentCanvas, int min, int max)
        {
            Max = max;
            Min = min;
            ParentCanvas = parentCanvas;
            NumberLabel = new List<Label>();
            
            Numbers = Enumerable.Range(min, max  - min).ToList();
        }
        protected List<int> SetNewNumbers(List<int> numbers, int v)
        {
            int multiple = numbers.Count / v;
            return numbers.Select(d => d * multiple).ToList();
        }
        public abstract void DrawGrids();
    }
}
