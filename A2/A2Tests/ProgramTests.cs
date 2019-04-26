using Microsoft.VisualStudio.TestTools.UnitTesting;
using A2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void AssignPiTest()
        {
            double piTest;
            Program.AssignPi(out piTest);
            Assert.AreEqual(Math.PI, piTest);
            return;
        }

        [TestMethod()]
        public void SquareTest()
        {
            double a = 5.0;
            Program.Square(ref a);
            Assert.AreEqual(25.0, a);
            a = 2.5;
            Program.Square(ref a);
            Assert.AreEqual(6.25, a);
            a = 1.5;
            Program.Square(ref a);
            Assert.AreEqual(2.25, a);
            a = 1.2;
            Program.Square(ref a);
            Assert.AreEqual(1.44, a);
            return;
        }

        [TestMethod()]
        public void SwapTest()
        {
            int first = 5, second = 6;
            Program.Swap(ref first, ref second);
            Assert.AreEqual(6, first);
            Assert.AreEqual(5, second);
            first = -1;
            second = 54;
            Program.Swap(ref first, ref second);
            Assert.AreEqual(54, first);
            Assert.AreEqual(-1, second);
            return;
        }

        [TestMethod()]
        public void SumTest()
        {
            int sum;
            Program.Sum(out sum, 1, 2, 6, 7, 8, 9);
            Assert.AreEqual(33, sum);
            Program.Sum(out sum, 1);
            Assert.AreEqual(1, sum);
            Program.Sum(out sum, 3, 2, 4);
            Assert.AreEqual(9, sum);
            return;
        }

        [TestMethod()]
        public void AppendTest()
        {
            int[] array = new int[] { 1, 2, 6, 4, 7 };
            int[] expected = new int[] { 1, 2, 6, 4, 7, 8 };
            int mustAppend = 8;
            Program.Append(ref array, mustAppend);
            CollectionAssert.AreEqual(expected, array);
            array = new int[] {};
            expected = new int[] {269};
            mustAppend = 269;
            Program.Append(ref array, mustAppend);
            CollectionAssert.AreEqual(expected, array);
            return;
        }

        [TestMethod()]
        public void AbsArrayTest()
        {
            int[] array = new int[] { -1, -3, 4, -6, 4, 8, -7 };
            int[] expected = new int[] { 1, 3, 4, 6, 4, 8, 7 };
            Program.AbsArray(array);
            CollectionAssert.AreEqual(expected, array);
            array = new int[] { };
            expected = new int[] { };
            Program.AbsArray(array);
            CollectionAssert.AreEqual(expected, array);
            return;
        }

        [TestMethod()]
        public void ArraySwapTest()
        {
            int[] firstArray = new int[] { 1, 2, 3 };
            int[] secondArray = new int[] { 4, 5, 6 };
            int[] expectedFirst = new int[] { 4, 5, 6 };
            int[] expectedSecond = new int[] { 1, 2, 3 };
            Program.ArraySwap(firstArray, secondArray);
            CollectionAssert.AreEqual(expectedFirst, firstArray);
            CollectionAssert.AreEqual(expectedSecond, secondArray);
            firstArray = new int[] { 1 };
            secondArray = new int[] { 2 };
            expectedFirst = new int[] { 2 };
            expectedSecond = new int[] { 1 };
            Program.ArraySwap(firstArray, secondArray);
            CollectionAssert.AreEqual(expectedFirst, firstArray);
            CollectionAssert.AreEqual(expectedSecond, secondArray);
            return;
        }

        [TestMethod()]
        public void ArraySwapTest1()
        {
            int[] firstArray = new int[] { 1, 2, 3, 4, 5, 6 };
            int[] secondArray = new int[] { 4, 5, 6 };
            int[] expectedFirst = new int[] { 4, 5, 6 };
            int[] expectedSecond = new int[] { 1, 2, 3, 4, 5, 6 };
            Program.ArraySwap(ref firstArray, ref secondArray);
            CollectionAssert.AreEqual(expectedFirst, firstArray);
            CollectionAssert.AreEqual(expectedSecond, secondArray);
            firstArray = new int[] { 1 };
            secondArray = new int[] {  };
            expectedFirst = new int[] {  };
            expectedSecond = new int[] { 1 };
            Program.ArraySwap(ref firstArray, ref secondArray);
            CollectionAssert.AreEqual(expectedFirst, firstArray);
            CollectionAssert.AreEqual(expectedSecond, secondArray);
            return;
        }
    }
}