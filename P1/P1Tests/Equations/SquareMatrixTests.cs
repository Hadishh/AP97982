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
    public class SquareMatrixTests
    {
        [TestMethod()]
        public void DeterminantTest()
        {
            const double det1 = 0;
            SquareMatrix<double> matrix1 = new SquareMatrix<double>(3)
            {
                new Vector<double>(3){1, 2, 3},
                new Vector<double>(3){4, 5, 6},
                new Vector<double>(3){7, 8, 9}
            };
            const double det2 = 54;
            SquareMatrix<int> matrix2 = new SquareMatrix<int>(4)
            {
                new Vector<int>(4){5, 6, 7, 9},
                new Vector<int>(4){5, 4, 2, 3},
                new Vector<int>(4){1, 2, 2, 2},
                new Vector<int>(4){7, 8, 1, 3}
            };
            Assert.AreEqual(det1, SquareMatrix<double>.Determinant(matrix1));
            Assert.AreEqual(det2, SquareMatrix<int>.Determinant(matrix2));
        }

        [TestMethod()]
        public void ReplaceColumnTest()
        {
            SquareMatrix<double> expectedMatrix1 = new SquareMatrix<double>(3)
            {
                new Vector<double>(3){2, 2, 3},
                new Vector<double>(3){2, 5, 6},
                new Vector<double>(3){2, 8, 9}
            };
            SquareMatrix<double> matrix1 = new SquareMatrix<double>(3)
            {
                new Vector<double>(3){1, 2, 3},
                new Vector<double>(3){4, 5, 6},
                new Vector<double>(3){7, 8, 9}
            };
            Assert.AreEqual(expectedMatrix1, matrix1.ReplaceColumn(new Vector<double>(3) { 2, 2, 2 }, 0));
            SquareMatrix<int> expectedMatrix2 = new SquareMatrix<int>(4)
            {
                new Vector<int>(4){5, 6, 0, 9},
                new Vector<int>(4){5, 4, 0, 3},
                new Vector<int>(4){1, 2, 0, 2},
                new Vector<int>(4){7, 8, 0, 3}
            };
            SquareMatrix<int> matrix2 = new SquareMatrix<int>(4)
            {
                new Vector<int>(4){5, 6, 7, 9},
                new Vector<int>(4){5, 4, 2, 3},
                new Vector<int>(4){1, 2, 2, 2},
                new Vector<int>(4){7, 8, 1, 3}
            };
            Assert.AreEqual(expectedMatrix2, matrix2.ReplaceColumn(new Vector<int>(4) { 0, 0, 0, 0 }, 2));
        }
    }
}