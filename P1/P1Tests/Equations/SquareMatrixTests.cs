﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            const double det2 = 0;
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

    }
}