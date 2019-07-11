using Microsoft.VisualStudio.TestTools.UnitTesting;
using P1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace P1.Tests
{
    [TestClass()]
    public class EquationUITests
    {
        [TestMethod()]
        public void GetSeparatedEquationsTest()
        {
            string input = "2x + 3 ^ x + x * sin(x) - 2";
            List<string> expectedOutput = new List<string>()
            {
                "2x",
                "3^x",
                "x*sin(x)",
                "2"
            };
            CollectionAssert.AreEqual(expectedOutput, EquationUI.GetSeparatedEquations(input));
        }
    }
}