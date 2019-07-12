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
    public class EquationParserTests
    {
        [TestMethod()]
        public void GetDelegateTest()
        {
            var func = EquationParser.GetDelegate("2x + 3x+ 3 ^ x + 2^x");
            Assert.AreEqual(2f, func(0));
            Assert.AreEqual(10f, func(1));
            func = EquationParser.GetDelegate("sinx + cotx + cosx");
            Assert.AreEqual(double.PositiveInfinity, func(0));
            func = EquationParser.GetDelegate("logx + |x|");
            Assert.AreEqual(1f, func(1));
            func = EquationParser.GetDelegate("sinhx + coshx");
            Assert.AreEqual(1, func(0));
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void GetDelegateTestException()
        {
            var func = EquationParser.GetDelegate("2x + 3x+ 3 ^ x + 2^x+");
        }

        [TestMethod()]
        public void AddMissedCrossesTest()
        {
            string input = "2x + 3x+ 2 + 2sinx+ 2logx";
            Assert.AreEqual("2*x + 3*x+ 2 + 2*sinx+ 2*logx", input.AddMissedCrosses());
        }
    }
}