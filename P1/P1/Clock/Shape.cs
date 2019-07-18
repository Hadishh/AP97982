using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1
{
    public abstract class Shape : IDrawable
    {
        public double Ratio { get; private set; }
        public List<AroundPoint> AroundPoints { get; set; }
        protected bool EnableLabel { get; set; }
        public Shape(double radius, List<AroundPoint> aroundPoints,bool enableLabel)
        {
            AroundPoints = aroundPoints;
            Ratio = radius;
            EnableLabel = enableLabel;
        }
        public abstract void Draw();
    }
}
