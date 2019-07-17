using Microsoft.VisualStudio.TestTools.UnitTesting;
using P1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1.Tests
{
    [TestClass()]
    public class EquationSolverTests
    {
        [TestMethod()]
        public void EquationSolverTest()
        {
            EquationSolver eqs = new EquationSolver("2 x + 3y =0 , 2y + 3x = 10");
            List<char> variables = new List<char>() { 'x', 'y' };
            CollectionAssert.AreEqual(variables, eqs.AllVariables);
        }

        [TestMethod()]
        public void CreateMatrixTest()
        {
            EquationSolver eqs = new EquationSolver("2x+3y+4z=0,5z+3y+2x=10,6x+7y+8z=13");
            Matrix<double> exceptedMatrix = new Matrix<double>(new List<Vector<double>>() {
                new Vector<double>(3){2, 3, 4},
                new Vector<double>(3){2, 3, 5},
                new Vector<double>(3){6, 7, 8}
                });
            Assert.AreEqual(exceptedMatrix, eqs.CreateMatrix());
            eqs = new EquationSolver("2x+3y=0,2x=10,6x+7y+8z=13");
            exceptedMatrix = new Matrix<double>(new List<Vector<double>>() {
                new Vector<double>(3){2, 3, 0},
                new Vector<double>(3){2, 0, 0},
                new Vector<double>(3){6, 7, 8}
                });
            Assert.AreEqual(exceptedMatrix, eqs.CreateMatrix());
            eqs = new EquationSolver("2x+3y=0,6x+7y+8z=13");
            exceptedMatrix = new Matrix<double>(new List<Vector<double>>() {
                new Vector<double>(3){2, 3, 0},
                new Vector<double>(3){6, 7, 8},
                new Vector<double>(3){0, 0, 0}
                });
           Assert.AreEqual(exceptedMatrix, eqs.CreateMatrix());
        }

        [TestMethod()]
        public void AnswerTest()
        {
            EquationSolver eqs = new EquationSolver("3x+2y+3z=0,2x+3y+4z=0,4x+6y+8z=0");
            Assert.AreEqual("No Unique Solution", eqs.Answer());
            eqs = new EquationSolver("4a+x+2y +3z = 5,2a+x+3y+7z=2,a+x+y+1.5z=3,2a+x+y+1.5z=3");
            Assert.AreEqual("a=0.000,x=1.000,y=5.000,z=-2.000", eqs.Answer());
            eqs = new EquationSolver("1x+2y+3z=1,4x + 5y + 6z = 2,7x + 8y + 9z = 3");
            Assert.AreEqual("No Unique Solution", eqs.Answer());
            eqs = new EquationSolver("3a+1b+2f+2r+9e=9,3a+9b+3f+3r+0e=1,3a+8b+5f+1r+2e=4,3a+7b+7f+4r+7e=5,3a+b+8f+2r+4e=4");
            Assert.AreEqual("a=1.284,b=0.032,e=0.801,f=-0.166,r=-0.881", eqs.Answer());
        }

    }
}