using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1
{
    class EquationSolver
    {
        public List<char> AllVariables { get; private set; }
        public List<LinearEquation> AllEquations { get; private set; }
        public Vector<double> RighSide { get; set; }
        SquareMatrix<double> Matrix { get; set; }
        public EquationSolver(string equations)
        {
            AllVariables = new List<char>();
            AllEquations = new List<LinearEquation>();
            var allEquations = equations.Split(',');
            foreach(var eq in allEquations)
            {
                LinearEquation equation = new LinearEquation(eq);
                AllEquations.Add(equation);
                AllVariables.AddRange(equation.Variables);
            }
            AllVariables = AllVariables.OrderBy(c => c).Distinct().ToList();
            Matrix = CreateMatrix();
        }
        public SquareMatrix<double> CreateMatrix()
        {
            SquareMatrix<double> matrix = new SquareMatrix<double>(AllVariables.Count);
            RighSide = new Vector<double>(AllVariables.Count);
            foreach (var equation in AllEquations)
            {
                RighSide.Add(equation.RightSide);
                matrix.Add(EquationParser.GetVetcor(equation.LeftSide, AllVariables));
            }
            return matrix;
        }
        public string Answer()
        {
            StringBuilder result = new StringBuilder();
            var determinant = SquareMatrix<double>.Determinant(Matrix);
            if (determinant == 0)
                if (SquareMatrix<double>.Determinant(Matrix.ReplaceColumn(RighSide, 0)) == 0)
                    return "No Unique Solution";
                else
                    return "No Solution";
            for(int i = 0; i < AllVariables.Count; i++)
            {
                double answer = SquareMatrix<double>.Determinant(Matrix.ReplaceColumn(RighSide, i)) / determinant;
                result.Append(AllVariables[i].ToString() + "=" + answer.ToString() + ','.ToString());
            }
            return result.ToString().Trim(',');
        }
        public override string ToString()
            => Answer();
    }
}
