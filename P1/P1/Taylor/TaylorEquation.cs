using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace P1
{
    class TaylorEquation : Equation
    {
        public int N { get; private set; }
        public double X0 { get; private set; }
        TaylorSeries TaylorSeries { get; set; }
        public TaylorEquation(int n, double x0, Func<double, double> function)
        {
            N = n;
            X0 = x0;
            Color = Brushes.Black;
            TaylorSeries = new TaylorSeries(function);
            Function = TaylorValue;
        }
        /// <summary>
        /// Calculate taylor series with N sentences and returns it.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        double TaylorValue(double x) => TaylorSeries.Calculate(N, X0, x);

    }
}
