using System;
using System.Windows.Media;

namespace P1
{
    public class Equation
    {
        public Brush Color { get;  set; }
        public Func<double, double> Function { get; set; }

    }
}
