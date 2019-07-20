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
    public class LinearEquationTests
    {
        [TestMethod()]
        public void LinearEquationTest()
        {
            LinearEquation eq = new LinearEquation("2x+3y=10");
            Assert.AreEqual(10, eq.RightSide);
            Assert.AreEqual("2x+3y", eq.LeftSide);
            CollectionAssert.AreEqual(new List<char>() { 'x', 'y' }, eq.Variables);
            eq = new LinearEquation("2x+3y+4z+5a=120");
            Assert.AreEqual(120, eq.RightSide);
            Assert.AreEqual("2x+3y+4z+5a", eq.LeftSide);
            CollectionAssert.AreEqual(new List<char>() { 'a', 'x', 'y', 'z' }, eq.Variables);
        }
    }
}