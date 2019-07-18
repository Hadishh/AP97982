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
    public class TaylorSeriesTests
    {
        [TestMethod()]
        public void CalculateTest()
        {
            TaylorSeries series = new TaylorSeries(Math.Sin);
            var answer = Math.Round(series.Calculate(2, 0, 1), 8);
            Assert.AreEqual(0.83333333, answer);
            answer = Math.Round(series.Calculate(4, 0, 1), 8);
            Assert.AreEqual(0.84146825, answer);
            answer = Math.Round(series.Calculate(3, 1, 2), 8);
            Assert.AreEqual(0.9610378, answer);
            answer = Math.Round(series.Calculate(6, 3, 5), 8);
            Assert.AreEqual(-0.971033, answer);
            answer = Math.Round(series.Calculate(3, -1, 2), 8);
            Assert.AreEqual(4.56605536, answer);
        }
    }
}