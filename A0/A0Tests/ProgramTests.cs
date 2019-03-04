using Microsoft.VisualStudio.TestTools.UnitTesting;
using A0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A0.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void AddTest()
        {
            long a = 11111;
            long b = 22223;
            //long Expected = Program.Add(a, b);
            Assert.AreEqual(33334, Program.Add(a, b));
        }

        [TestMethod()]
        public void SubstractTest()
        {
            Assert.AreEqual(5, Program.Substract(12, 7));
        }

        [TestMethod()]
        public void NegateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ProductTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SquareTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void FactorialTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SqrtTest()
        {
            Assert.Fail();
        }
    }
}