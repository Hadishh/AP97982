﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1
{
    class Calculator
    {
       static  Dictionary<string, Func<double, double>> Functions = new Dictionary<string, Func<double, double>>()
        {
            { "sin(x)", Math.Sin },
            { "sinx", Math.Sin },
            {"cos(x)", Math.Cos },
            { "cosx", Math.Cos},
            {"logx", Math.Log },
            {"log(x)", Math.Log },
            {"|x|", Math.Abs },
           { }
        };
        static Calculator _Instance;
        public static Calculator Instance => _Instance ?? (_Instance = new Calculator());

        /// <summary>
        /// Calculate inputted function with dictionary function in addtion to POWER Function
        /// </summary>
        /// <param name="function"></param>
        /// <returns></returns>
        public double Calculate(string function)
        {

            return 0;
        }
        //private 
    }
}
