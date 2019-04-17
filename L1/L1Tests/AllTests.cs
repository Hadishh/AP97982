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
            Assert.AreEqual("1144", TestData.allFlights[0].FlightID);
            Assert.AreEqual(TestData.airline1, TestData.allFlights[0].AirLine);
            //Reserved By user 10
            Assert.AreEqual(98, TestData.allFlights[0].Capacity);
            Assert.AreEqual("Hamedan", TestData.allFlights[0].Source);
            Assert.AreEqual("Mashhad", TestData.allFlights[0].Destination);
            Assert.AreEqual(new DateTime(year: 2019, month: 3, day: 21), TestData.allFlights[0].FlyDate);
            CollectionAssert.AreEqual(TestData.allFlights, DB.Flights);
        }
        [TestMethod()]
        public void IsFullTests()
        {
            Assert.AreEqual(true, TestData.allFlights[6].IsFull());
            Assert.AreEqual(false, TestData.allFlights[0].IsFull());
        }
    }
    [TestClass()]
    public class UserTests
    {
        [TestMethod()]
        public void UserTest()
        {
            Assert.AreEqual("Sepehr Hashemi", TestData.Sepehr.FullName);
            Assert.AreEqual("9643", TestData.Sepehr.NationalID);
            Assert.AreEqual("+981111111111", TestData.Sepehr.PhoneNumber);
        }

        [TestMethod()]
        public void ReserveTest()
        {
            TestData.Sepehr.Reserve(TestData.allTickets[0]);
            TestData.Sepehr.Reserve(TestData.allTickets[3]);
            TestData.Reza.Reserve(TestData.allTickets[1]);
            TestData.Ali.Reserve(TestData.allTickets[2]);
            TestData.Ahmad.Reserve(TestData.allTickets[4]);
            TestData.Kazem.Reserve(TestData.allTickets[5]);
            TestData.Kazem.Reserve(TestData.allTickets[6]);
            Assert.AreEqual(98, TestData.allFlights[0].Capacity);
            Assert.AreEqual(TestData.Sepehr , TestData.allTickets[0].Buyer);
            Assert.AreEqual(-712000.0 , TestData.Kazem.Account);

        }

        [TestMethod()]
        public void CancelTest()
        {
            List<Ticket> kazemTickets = TestData.Kazem.Tickets;
            kazemTickets.Remove(TestData.allTickets[6]);
            TestData.Kazem.Cancel(TestData.allTickets[6]);
            TestData.Kazem.Cancel(TestData.allTickets[0]);
            Assert.AreNotEqual(null, TestData.allTickets[0].Buyer);
            Assert.AreEqual(null, TestData.allTickets[6].Buyer);
            Assert.AreEqual(-530000, TestData.Kazem.Account);
            CollectionAssert.AreEqual(kazemTickets, TestData.Kazem.Tickets);
        }

        [TestMethod()]
        public void DateFilteredTicketsTest()
        {
            DateTime start = new DateTime(year: 2019, month: 5, day: 1);
            DateTime end = new DateTime(year: 2019, month: 10, day: 1);
           
            CollectionAssert.AreEqual(TestData.DataFilteredExceptedTickets, TestData.user10.DateFilteredTickets(start, end));
        }

        [TestMethod()]
        public void NowruzTicketsTest()
        {
            CollectionAssert.AreEqual(TestData.NowruzExceptedTickets, TestData.user10.NowruzTickets());
        }

        [TestMethod()]
        public void AirlineTicketsTest()
        {
            CollectionAssert.AreEqual(TestData.MahanAirTickets, TestData.user10.AirlineTickets(TestData.airline1));
        }

        [TestMethod()]
        public void RouteTicketsTest()
        {
            CollectionAssert.AreEqual(TestData.ShirazToTeh, TestData.Sepehr.RouteTickets("Shiraz", "Tehran"));
        }
    }
    [TestClass()]
    public class TicketTests
    {
        [TestMethod()]
        public void TicketTest()
        {
            Assert.AreEqual(TestData.allFlights[0], TestData.allTickets[0].Flight);
            Assert.AreEqual(250000, TestData.allTickets[0].Price);
            Assert.AreEqual(TestData.Sepehr, TestData.allTickets[0].Buyer);
        }
        [TestMethod()]
        public void IsSoldTest()
        {
            Assert.AreEqual(true, TestData.allTickets[0].IsSold());
            Assert.AreEqual(false, TestData.allTickets[20].IsSold());
        }
    }
    [TestClass()]
    public class DBTests
    {
        [TestMethod()]
        public void MostExpensiveTicketsTest()
        {
            Assert.AreEqual(TestData.allTickets[16], DB.MostExpensiveTicket());
        }
        [TestMethod()]
        public void FavouriteAirlineTest()
        {
            TestData.user10.Reserve(TestData.allTickets[16]);
            Assert.AreEqual(TestData.airline4, DB.FavouriteAirline());
        }
        [TestMethod()]
        public void UserDebtsTest()
        {
            List<User> users = DB.Users;
            double x = TestData.user10.Account;
            Assert.AreEqual(-4993000, DB.UsersDebts());
        }
    }
}