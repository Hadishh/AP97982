using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1
{
    public class TaylorSeries
    {
        /// <summary>
        /// Derivations List.
        /// Note : Please Set Your Original Function At The First Element of List;
        /// </summary>
        private List<Func<double, double>> Derivations = new List<Func<double, double>>()
        {
            {Math.Sin },
            {Math.Cos},
            {(x) => -Math.Sin(x)},
            {(x)=>-Math.Cos(x)}
        };
        public double CurrentValue { get; private set; }
        private int Indexer;
        public TaylorSeries(Func<double, double> function)
        {
            CurrentValue = 1;
            Indexer = 1;
        }
        /// <summary>
        /// calculates taylor series with n sentences around x0 with value x.
        /// </summary>
        /// <param name="n"></param>
        /// <param name="x0"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public double Calculate(int n, double x0,double x)
        {
            var func = Derivations[0];
            double result = func(x0) * CurrentValue / Indexer;
            if (func(x0) != 0)
                n--;
            func = Derivations[Indexer];
            while(n > 0)
            {
                double value = func(x0) * CurrentValue * (x - x0) / Indexer;
                if (func(x0) != 0)
                    n--;
                result += value;
                CurrentValue = CurrentValue * (x - x0) / Indexer++;
                func = Derivations[(Indexer) % 4];
            }
            CurrentValue = 1;
            Indexer = 1;
            return result;
        }
    }
}
