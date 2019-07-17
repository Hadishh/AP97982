using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1
{
    public class LinearEquation
    {
        public List<char> Variables { get; private set; }
        public string LeftSide { get; private set; }
        public double RightSide { get; private set; }
        public LinearEquation(string data)
        {
            var parts = data.Split('=');
            Variables = new List<char>();
            double rightSide;
            if (parts.Length != 2 || !double.TryParse(parts[1], out rightSide))
                throw new ArgumentException();
            LeftSide = parts[0];
            RightSide = rightSide;
            FindVariables();
        }
        /// <summary>
        /// Find all variables used in the equation string
        /// </summary>
        private void FindVariables()
        {
            foreach (var c in LeftSide)
                if (char.IsLetter(c))
                    Variables.Add(c);
            Variables = Variables.OrderBy(c => c).ToList();
        }
    }
}
