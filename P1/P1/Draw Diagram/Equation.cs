using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1
{
    public class Equation : IDrawable
    {
        public List<string> EquationParts { get; }
        public List<char> InverntoryOperators { get; }
        public Equation(List<char> inventoryOperators, List<string> parts)
        {
            EquationParts = parts;
            InverntoryOperators = inventoryOperators;
        }
        /// <summary>
        /// Gives the list of separated functions and return a equation with separated functions
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static Equation GetSeparatedEquations(string text)
        {
            List<string> results = new List<string>();
            List<char> invetroies = new List<char>();
            string temp = string.Empty;
            foreach(var c in text)
            {
                
                if(new List<char> { '+', '-' }.Contains(c))
                {
                    results.Add(temp);
                    temp = string.Empty;
                    invetroies.Add(c);
                }
                else
                    temp += c;
            }
            return new Equation(invetroies, results);
        }
        public bool Draw()
        {
            return true;
        }
    }
}
