﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1
{
    /// <summary>
    /// Parsing equations to
    /// </summary>
    public static partial class EquationParser
    {
        /// <summary>
        /// Contains equation string that you want to parse it.
        /// </summary>
        private static string Data;

        private static int Indexer;
        /// <summary>
        /// Dictionary of functions and last one is your delegate.
        /// Note : At most cases last member needs other elements so becareful!
        /// </summary>
        private static Dictionary<string, Func<double, double>> Functions { get; set; }
        /// <summary>
        /// Initialization for finding appropriate delegate.
        /// </summary>
        /// <param name="data"></param>
        private static void SetData(string data)
        {
            Data = data.Replace(" ", string.Empty).AddMissedCrosses();
            Functions = new Dictionary<string, Func<double, double>>(SingleFunctions);
            Indexer = 0;
        }
        /// <summary>
        /// Functions that can be calculated in equations you can add other functions to it.
        /// </summary>
        private static Dictionary<string, Func<double, double>> SingleFunctions = new Dictionary<string, Func<double, double>>()
        {
            { "|x|", Math.Abs },
            { "x", (x) => x },
            { "sin(x)", Math.Sin },
            { "sinx", Math.Sin },
            { "cos(x)", Math.Cos },
            { "cosx", Math.Cos},
            { "tan(x)", Math.Tan},
            { "tanx", Math.Tan},
            { "cot(x)", (x) => 1 / Math.Tan(x)},
            { "cotx", (x) =>  1 / Math.Tan(x)},
            { "acos(x)", Math.Acos },
            { "acosx", Math.Acos },
            { "asin(x)", Math.Asin },
            { "asinx", Math.Asin },
            { "atan(x)", Math.Atan },
            { "atanx", Math.Atan },
            {"sinhx", Math.Sinh },
            {"sinh(x)", Math.Sinh },
            {"coshx", Math.Cosh },
            {"cosh(x)", Math.Cosh },
            {"tanhx", (x) => Math.Sinh(x) / Math.Cosh(x) },
            {"tanh(x)", (x) => Math.Sinh(x) / Math.Cosh(x) },
            { "acot(x)", (x) => Math.PI / 2 - Math.Atan(x) },
            { "acotx", (x) => Math.PI / 2 - Math.Atan(x)},
            { "logx", Math.Log },
            { "log(x)", Math.Log }
        };
        /// <summary>
        /// Supported operators.
        /// </summary>
        private static List<char> Operators = new List<char> { '+', '-', '*', '/', '^' };
        /// <summary>
        /// Calculates each side of the input operator and replace Zn to that for making equation shorter.Adds Zn Key to dictionary fo 
        /// next calculations needed.
        /// </summary>
        /// <param name="operatorChr"></param>
        /// <param name="operatorFunction"></param>
        private static void CalculatePartsByOperator(char operatorChr,Func<double, double, double> operatorFunction)
        {
            for (int i = 0; i < Data.Length; i++)
            {
                if (Data[i] == operatorChr)
                {
                    if (i == 0 || i == Data.Length - 1)
                        throw new ArgumentException();
                    string firstPart = string.Empty;
                    string secondPart = string.Empty;
                    for (int j = i - 1; j >= 0 && !Operators.Contains(Data[j]); j--)
                        firstPart += Data[j];
                    firstPart = new string(firstPart.Reverse().ToArray());
                    for (int j = i + 1; j < Data.Length && !Operators.Contains(Data[j]); j++)
                        secondPart += Data[j];
                    double d = 0;
                    double d2 = 0;
                    if (secondPart.Length == 0 || firstPart.Length == 0)
                        throw new ArgumentException();
                    if ((firstPart.Contains('x') || firstPart.Contains('Z')) && double.TryParse(secondPart, out d))
                        Functions.Add("Z" + Indexer, (x) => operatorFunction(Functions[firstPart](x), d));

                    else if ((secondPart.Contains('x') || secondPart.Contains('Z')) && double.TryParse(firstPart, out d))
                        Functions.Add("Z" + Indexer, (x) => operatorFunction(d, Functions[secondPart](x)));

                    else if (double.TryParse(secondPart, out d) && double.TryParse(firstPart, out d2))
                        Functions.Add("Z" + Indexer, (x) => operatorFunction(d, d2));

                    else if((secondPart.Contains('x') || secondPart.Contains('Z')) && (firstPart.Contains('x') || firstPart.Contains('Z')))
                        Functions.Add("Z" + Indexer, (x) => operatorFunction(Functions[firstPart](x), Functions[secondPart](x)));

                    else
                        throw new ArgumentException();
                    Data = Data.Replace(firstPart + operatorChr + secondPart, "Z" + Indexer++);
                    //Here We delete some characters and add two chacters so we need to resume from past position by modifying index
                    //e.g x^2+3 = A0+3
                    i -= (firstPart.Length + 1 + secondPart.Length) - 2;
                    i = i < 0 ? 0 : i;
                }
            }
        }
        /// <summary>
        /// Runs calculator on true order to finds a delegate that calculates equation and returns it
        /// </summary>
        /// <param name="inputEquation"></param>
        /// <returns></returns>
        public static Func<double, double> GetDelegate(string inputEquation)
        {
            double constant = 0;
            if (double.TryParse(inputEquation.Replace(" ", ""), out constant))
                return (x) => constant;
            SetData(inputEquation);
            CalculatePartsByOperator('^', (x, y) => Math.Pow(x, y));
            CalculatePartsByOperator('*', (x, y) => x * y);
            CalculatePartsByOperator('/', (x, y) => x / y);
            CalculatePartsByOperator('-', (x, y) => x - y);
            CalculatePartsByOperator('+', (x, y) => x + y);
            if (Functions.Values.Count == SingleFunctions.Values.Count)
            {
                if (SingleFunctions.ContainsKey(inputEquation))
                    return SingleFunctions[inputEquation];
                throw new ArgumentException();
            }
            return Functions.Values.Last();
        }

        //Extention Methods
        /// <summary>
        /// Adding missed * charaters.Normalize input string.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string AddMissedCrosses(this string input)
        {
            string output = string.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                output += input[i];
                if (i < input.Length - 1 && char.IsDigit(input[i]) && char.IsLetter(input[i + 1]))
                    output += '*';
            }
            if (output.Length >= 1 && new List<char> (){'+', '-' }.Contains(output[0]))
                output = "0" + output;
            return output;
        }
    }
}
