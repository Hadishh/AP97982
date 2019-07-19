using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace P1
{
    public abstract class Shape : IDrawable
    {
        public double Ratio { get; private set; }
        public List<AroundPoint> AroundPoints { get; set; }
        protected bool EnableLabel { get; set; }
        protected Canvas ParentCanvas { get; set; }
        public Shape(double radius, List<AroundPoint> aroundPoints, Canvas parentCanvas, bool enableLabel)
        {
            AroundPoints = aroundPoints;
            Ratio = radius;
            EnableLabel = enableLabel;
            ParentCanvas = parentCanvas;
        }
        public abstract void Draw();
    }
}
