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
    public class CalculatorTests
    {
        [TestMethod()]
        public void CalculateAllTest()
        {
            Calculator.Instance.CalculateAll("2x+x^2+sin(x)^3");
            Calculator.Instance.CalculateAll("2x+x^2+2sin(x)^3 + x^3 + 3*cos(x)");
            Calculator.Instance.CalculateAll("2x+x^2+3sin(x)^3");
        }
    }
}