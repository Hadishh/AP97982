using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1
{
    public class EquationSolver
    {
        public List<char> AllVariables { get; private set; }
        public List<LinearEquation> AllEquations { get; private set; }
        public Vector<double> RighSide { get; private set; }
        public SquareMatrix<double> Matrix { get; private set; }
        /// <summary>
        /// Equation solver Ctor. Be Aware Argument Exceptions. Creates Matrix automatically.
        /// </summary>
        /// <param name="equations"></param>
        public EquationSolver(string equations)
        {
            AllVariables = new List<char>();
            AllEquations = new List<LinearEquation>();
            var allEquations = equations.Split(',');
            foreach(var eq in allEquations)
            {
                LinearEquation equation = new LinearEquation(eq.Replace(" ", string.Empty));
                AllEquations.Add(equation);
                AllVariables.AddRange(equation.Variables);
            }
            AllVariables = AllVariables.OrderBy(c => c).Distinct().ToList();
            Matrix = CreateMatrix();
        }
        /// <summary>
        /// Creates Matrix of multiples and returns it
        /// </summary>
        /// <returns></returns>
        public SquareMatrix<double> CreateMatrix()
        {
            SquareMatrix<double> matrix = new SquareMatrix<double>(AllVariables.Count);
            RighSide = new Vector<double>(AllVariables.Count);
            foreach (var equation in AllEquations)
            {
                RighSide.Add(equation.RightSide);
                matrix.Add(EquationParser.GetVetcor(equation.LeftSide, AllVariables));
            }
            for (int i = AllEquations.Count; i < matrix.Size; i++)
                matrix.Add(new Vector<double>(matrix.Size));
            return matrix;
        }
        /// <summary>
        /// Finds the answer in crammer way.
        /// </summary>
        /// <returns></returns>
        public string Answer()
        {
            StringBuilder result = new StringBuilder();
            var determinant = SquareMatrix<double>.Determinant(Matrix);
            if (determinant == 0)
            {
                int index = 0;
                for (int i = 0; i < Matrix.Size; i++)
                {
                    for (int j = i + 1; j < Matrix.Size; j++)
                    {
                        RighSide[j] -= RighSide[i] * (Matrix[j][i] / Matrix[i][i]);
                        Matrix[j] -= Matrix[i] * (Matrix[j][i] / Matrix[i][i]);
                    }
                    if (AllZeroInRow(out index))
                        if (RighSide[index] == 0)
                            return "No Unique Solution";
                        else
                            return "No Solution";
                }
            }
            for (int i = 0; i < AllVariables.Count; i++)
            {
                double answer = SquareMatrix<double>.Determinant(Matrix.ReplaceColumn(RighSide, i)) / determinant;
                result.Append(AllVariables[i].ToString() + "=" + answer.ToString("0.000") + ','.ToString());
            }
            return result.ToString().Trim(',');
        }
        /// <summary>
        /// checks there exist a row that all it's elements are zero.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private bool AllZeroInRow(out int index)
        {
            for (int i = 0; i < Matrix.Size; i++)
            {
                bool b = true;
                foreach (var item in Matrix[i])
                    if (item != 0)
                        b = false;
                if (b)
                {
                    index = i;
                    return true;
                }
            }
            index = -1;
            return false;
        }
    }
}
