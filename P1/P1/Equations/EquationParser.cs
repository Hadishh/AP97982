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
            
            Vector<double> vector = new Vector<double>(orderedVariables.Count);
            for(int i = 0; i < equation.Length; i++)
            {
                if (!char.IsLetter(equation[i]))
                    continue;
                if (orderedVariables.Contains(equation[i]))
                {
                    StringBuilder builder = new StringBuilder();
                    for (int j = i - 1; j >= 0 && !Operators.Contains(equation[j + 1]); j--)
                        builder.Append(equation[j]);
                    string value = new string(builder.ToString().Reverse().ToArray());
                    if (value == "+" || value == "-")
                        value += 1;
                    double d = 0;
                    if (!double.TryParse(value, out d))
                        throw new ArgumentException();
                    vector[orderedVariables.IndexOf(equation[i])] += d;
                }
                else
                    throw new ArgumentException();
            }
            return vector;
        }
    }
}
