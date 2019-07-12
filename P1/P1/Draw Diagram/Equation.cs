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
        public Func<double, double> Function { get; private set; }
        public Equation(string data)
        {
            EquationData = data;
            Function = EquationParser.GetDelegate(EquationData); ;
        }
        public bool Draw()
        {
            return true;
        }
    }
}
