using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1
{
    public static partial class EquationParser
    {
        public static Vector<double> GetVetcor(string equation, List<char> orderedVariables)
        {
            Vector<double> vector = new Vector<double>(equation.Split(new char[] { '+', '-'}).Length);
            for(int i = 0; i < equation.Length; i++)
            {
                if (orderedVariables.Contains(equation[i]))
                {
                    StringBuilder builder = new StringBuilder();
                    for(int j = i - 1; j >= 0 && !Operators.Contains(equation[j + 1]); j--)
                        builder.Append(equation[j]);
                    string value = new string(builder.ToString().Reverse().ToArray());
                    double d = 0;
                    if (!double.TryParse(value, out d))
                        throw new ArgumentException();
                    vector[orderedVariables.IndexOf(equation[i])] = d;
                }
                else if (char.IsLetter(equation[i]))
                {
                    orderedVariables.Add(equation[i]);
                    i--;
                }
            }
            return vector;
        }
    }
}
