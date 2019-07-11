using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1
{
    class Calculator
    {
       static  Dictionary<string, Func<double, double>> SingleFunctions = new Dictionary<string, Func<double, double>>()
        {
            { "sin(x)", Math.Sin },
            { "sinx", Math.Sin },
            { "cos(x)", Math.Cos },
            { "cosx", Math.Cos},
            { "logx", Math.Log },
            { "log(x)", Math.Log },
            { "|x|", Math.Abs },
            { "x", (x) => x }
        };
        private Dictionary<char, Func<double, double, double>> DoubleFunctions = new Dictionary<char, Func<double, double, double>>()
        {
            {'+', (x, y) => x + y  },
            {'*', (x, y) => x * y  },
            {'/', (x, y) => x / y  },
            {'^', Math.Pow  }
        };

        static Calculator _Instance;
        public static Calculator Instance => _Instance ?? (_Instance = new Calculator());

        /// <summary>
        /// Calculate inputted function with dictionary function in addtion to POWER Function
        /// </summary>
        /// <param name="function"></param>
        /// <returns></returns>
        private double CalculateSingleFunctions(string function)
        {

            return 0;
        }
        private double CalculateDoubleFunctions(string firstPart, char operatorItem, string secondPart)
        {
            return 0;
        }
        public double CalculateAll(string equation)
        {
            Dictionary<string, Func<double, double>> answers = new Dictionary<string, Func<double, double>>();
            foreach(var c in equation)
        }
        //private 
    }
}
