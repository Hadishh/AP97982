using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace P1
{
    public class Calculator
    {
        static Calculator _Instance;
        public static Calculator Instance => _Instance ?? (_Instance = new Calculator());

        public double CalculateAll(string equation)
        {
            EquationParser.SetData(equation);
            var functionsDic = EquationParser.SingleFunctions;
            EquationParser.CalculatePartsByOperator('^',(x, y) => Math.Pow(x, y));
            EquationParser.CalculatePartsByOperator('*', (x, y) => x * y);
            EquationParser.CalculatePartsByOperator('/', (x, y) => x / y);
            EquationParser.CalculatePartsByOperator('+', (x, y) => x + y);
            EquationParser.CalculatePartsByOperator('-', (x, y) => x - y);
            return 0;
        }
        
    }
}
