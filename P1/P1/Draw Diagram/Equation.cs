using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1
{
    public class Equation : IDrawable
    {
        string EquationData { get; set; }
        Func<double, double> Function { get; set; }
        public Equation(string data)
        {
            EquationData = data;
        }
        public void SetEquationFunction()
        {
            Function = EquationParser.GetDelegate(EquationData);
        }
        public bool Draw()
        {
            return true;
        }
    }
}
