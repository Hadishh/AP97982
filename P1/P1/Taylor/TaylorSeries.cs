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
        Func<double, double> OriginalFunction { get; set; }
        public TaylorSeries(Func<double, double> function)
        {
            CurrentValue = 1;
            Indexer = 1;
            OriginalFunction = function;
        }
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
                double k = func(0);
            }
            CurrentValue = 1;
            Indexer = 1;
            return result;
        }
    }
}
