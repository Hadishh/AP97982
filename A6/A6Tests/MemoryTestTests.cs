using Microsoft.VisualStudio.TestTools.UnitTesting;
//using APAssignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Runtime.InteropServices;
using A6;
//nameSpace Changed 
namespace A6Tests
{
    [TestClass]
    public class MemoryTestTests
    {
        [TestMethod]
        public void VariableSizeTest()
        {
            //Structures Initialized
            TypeOfSize5 tos5 = new TypeOfSize5();
            VerifySize(tos5, 5);
            TypeOfSize22 tos22 = new TypeOfSize22();
            VerifySize(tos22, 22);
            TypeOfSize125 tos125 = new TypeOfSize125();
            VerifySize(tos125, 125);
            TypeOfSize1024 tos1024 = new TypeOfSize1024();
            VerifySize(tos1024, 1024);
        }

    
        [TestMethod]
        public void StackDepth10Test()
        {
           
            int recursionDepth = GetMaxRecursion(0, new TypeForMaxStackOfDepth10());
            Assert.AreEqual(10, recursionDepth);
        }

        [TestMethod]
        public void StackDepth100Test()
        {
            int recursionDepth = GetMaxRecursion(0, new TypeForMaxStackOfDepth100());
            Assert.AreEqual(100, recursionDepth);
        }

        [TestMethod]
        public void StackDepth1000Test()
        {
            TypeOfSize2048 Kb2;
            TypeOfSize1024 Kb1;
            TypeOfSize128 bytes128;
            int recursionDepth = GetMaxRecursion(0, new TypeForMaxStackOfDepth1000());
            //Assert.AreEqual(1000, recursionDepth);
            Assert.AreEqual(true, recursionDepth < 1010 && recursionDepth > 990);
        }

        [TestMethod]
        public void StackDepth3000Test()
        {
            TypeOfSize8192 Kb8;
            TypeOfSize2048 Kb2;
            TypeOfSize8 bytes8;
            int recursionDepth = GetMaxRecursion(0, new TypeForMaxStackOfDepth3000());
            Assert.AreEqual(3000, recursionDepth);
            //Assert.AreEqual(true, recursionDepth <= 3020 && recursionDepth >= 2980);
        }
        
        [TestMethod]
        public void HeapMemoryTest()
        {
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);
            var memSize = GC.GetTotalMemory(true);
            TypeWithMemoryOnHeap r = new TypeWithMemoryOnHeap();
            r.Allocate();

            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);
            var memDiff1 = GC.GetTotalMemory(true) - memSize;
            r.DeAllocate();

            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);
            var memDiff2 = GC.GetTotalMemory(true) - memSize;

            Assert.IsTrue(memDiff1 < 4_100_000 && memDiff1 > 3_900_000);
            Assert.IsTrue(memDiff2 < 100_000 && memDiff2 > -100_000);
        }
        
        [TestMethod]
        public void RefValueTypeCopyTest1()
        {
            StructOrClass1 soc1a = new StructOrClass1();
            soc1a.X = 1;
            var soc1b = soc1a;
            soc1a.X = 2; ;
            Assert.AreNotEqual(soc1a.X, soc1b.X);
        }
        
        [TestMethod]
        public void RefValueTypeCopyTest2()
        {
            StructOrClass2 soc1a = new StructOrClass2();
            soc1a.X = 1;
            var soc1b = soc1a;
            soc1a.X = 2; ;
            Assert.AreEqual(soc1a.X, soc1b.X);
        }
    
        [TestMethod]
        public void RefValueTypeCopyTest3()
        {
            StructOrClass3 soc1a = new StructOrClass3();
            var soc2 = new StructOrClass2();
            soc2.X = 5;
            soc1a.X = soc2;
            var soc1b = soc1a;
            soc1a.X.X = 6; 
            Assert.AreEqual(soc1a.X.X, soc1b.X.X);
            Assert.AreEqual(soc2.X, soc1b.X.X);

        }
        
        [TestMethod]
        public void BoxingTest()
        {
            StructOrClass1 soc = new StructOrClass1();
            soc.X = 5;
            object o = soc;
            soc.X = 6;
            StructOrClass1 soc2 = (StructOrClass1) o;
            Assert.AreEqual(5, soc2.X);
        }
        
        [TestMethod]
        public void TypeTest()
        {
            string str = null;
            int value = Program.GetObjectType(str);
            Assert.AreEqual(0, value);
            value = Program.GetObjectType(new int[] { 2 });
            Assert.AreEqual(1, value);
            value = Program.GetObjectType(24434);
            Assert.AreEqual(2, value);
        }
        
        [TestMethod]
        public void IdealHusbandTest()
        {
            FutureHusbandType fht = FutureHusbandType.HasBigNose;
            Assert.AreEqual(false, Program.IdealHusband(fht));

            fht = FutureHusbandType.IsBald;
            Assert.AreEqual(false, Program.IdealHusband(fht));

            fht = FutureHusbandType.IsShort;
            Assert.AreEqual(false, Program.IdealHusband(fht));

            fht = FutureHusbandType.IsBald | FutureHusbandType.IsShort;
            Assert.AreEqual(true, Program.IdealHusband(fht));

            fht = FutureHusbandType.IsBald | FutureHusbandType.HasBigNose;
            Assert.AreEqual(true, Program.IdealHusband(fht));

            fht = FutureHusbandType.IsShort | FutureHusbandType.HasBigNose;
            Assert.AreEqual(true, Program.IdealHusband(fht));

            fht = FutureHusbandType.IsShort | FutureHusbandType.HasBigNose | FutureHusbandType.IsBald;
            Assert.AreEqual(false, Program.IdealHusband(fht));


        }
        
        #region Helper Methods
        private void VerifySize<_Type>(_Type tos, int expectedSize)
        {
            int actualSize = Marshal.SizeOf(tos);
            Assert.AreEqual(expectedSize, actualSize);
        }

        private int GetMaxRecursion<_Type>(int currentDepth, _Type bvt)
        {
            try
            {
                EnsureSufficientExecutionStack();
                return GetMaxRecursion(currentDepth + 1, bvt);
            }
            catch (InsufficientExecutionStackException) {}
            return currentDepth;
        }
        #endregion
    }
}