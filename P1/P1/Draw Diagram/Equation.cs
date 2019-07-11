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
        
        public Equation(params string[] parts)
        {
            EquationParts = parts.ToList();

        }
        /// <summary>
        /// Gives the list of separated functions and return a equation with separated functions
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static Equation GetSeparatedEquations(string text)
        {
            List<string> results = new List<string>();
            foreach (var item in text.Split(new char[] { '+', '-' }))
                results.Add(item.Replace(" ", string.Empty));
            return new Equation(results.ToArray());
        }
        public bool Draw()
        {
            return true;
        }
    }
}
