using Microsoft.VisualStudio.TestTools.UnitTesting;
using L1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1.Tests
{
    [TestClass()]
    public class AirlineTests
    {
        [TestMethod()]
        public void AirlineTest()
        {
            Assert.AreEqual("Mahan", TestData.airline1.Name);
            Assert.AreEqual("IranAir", TestData.airline2.Name);
            Assert.AreEqual("KishAir", TestData.airline3.Name);
            Assert.AreEqual("Asemaan", TestData.airline4.Name);
        }
    }
    [TestClass()]
    public class FlightTests
    {
        [TestMethod()]
        public void FlightTest()
        {
           // Assert.AreEqual("1144", TestData.)
        }
    }
    [TestClass()]
    public class UserTests
    {
        [TestMethod()]
        public void UserTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ReserveTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CancelTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DateFilteredTicketsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void NowruzTicketsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AirlineTicketsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RouteTicketsTest()
        {
            Assert.Fail();
        }
    }
}