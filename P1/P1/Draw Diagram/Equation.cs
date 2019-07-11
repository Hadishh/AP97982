using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1m
{
    public class Equation
    {
        public Func<double, double> Function { get; }
        List<string> EquationParts { get; }
        
        public Equation(params string[] parts)
        {
            EquationParts = parts.ToList();

        }
        
    }
}
