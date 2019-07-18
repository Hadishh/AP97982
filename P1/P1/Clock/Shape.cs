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
        public Shape(double radius, List<AroundPoint> aroundPoints)
        {
            AroundPoints = aroundPoints;
            Ratio = radius;
        }
        public abstract void Draw();
    }
}
