using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1
{
    public static class EquationParser
    {
        private static string Data;
        private static int Indexer;
        static Dictionary<string, Func<double, double>> Functions;
        public static void SetData(string data)
        {
            Data = data.Replace(" ", string.Empty).AddMissedCrosses();
            Functions = new Dictionary<string, Func<double, double>>(SingleFunctions);
            Indexer = 0;
        }
        public static string GetData { get => Data; }
        public static Dictionary<string, Func<double, double>> SingleFunctions = new Dictionary<string, Func<double, double>>()
        {
            { "sin(x)", Math.Sin },
            { "sinx", Math.Sin },
            { "cos(x)", Math.Cos },
            { "cosx", Math.Cos},
            { "tan(x)", Math.Tan},
            { "logx", Math.Log },
            { "log(x)", Math.Log },
            { "|x|", Math.Abs },
            { "x", (x) => x }
        };
        private static List<char> Operators = new List<char> { '+', '-', '*', '/', '^' };
        public static void CalculatePartsByOperator(char operatorChr,Func<double, double, double> operatorFunction)
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
                    //DebugMode
                    string current = Data;
                    //Here We delete some characters and add two chacters so we need to resume from past position by modifying index
                    //e.g x^2+3 = A0+3
                    i -= (firstPart.Length + 1 + secondPart.Length) - 2;
                }
            }
        }
        public static string AddMissedCrosses(this string input)
        {
            string output = string.Empty;
            for(int i = 0; i < input.Length; i++)
            {
                output += input[i];
                if (i < input.Length - 1 && char.IsDigit(input[i]) && char.IsLetter(input[i + 1]))
                    output += '*';
            }
            return output;
        }
    }
}
