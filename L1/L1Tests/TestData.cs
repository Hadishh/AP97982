using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using L1;
namespace L1.Tests
{
    public class TestData
    {

        public static User Sepehr = new User("Sepehr Hashemi", "9643", "+981111111111");
        public static User Reza = new User("Reza Mousavi", "3312", "+981111111112");
        public static User Ali = new User("Ali Amadi", "9856", "+981111111113");
        public static User Mohammad = new User("Mohammad Alavi", "4065", "+981111111114");
        public static User Kazem = new User("Kazem Ghalamchi", "1176", "+981111111115");
        public static User Ahmad = new User("Ahmad Rezaii", "1327", "+981111111116");
        public static User user7 = new User("Sepehr Hashemi", "9845", "+981111111117");
        public static User user8 = new User("Sepehr Hashemi", "1098", "+981111111118");
        public static User user9 = new User("Sepehr Hashemi", "8865", "+981111111119");
        public static User user10 = new User("Sepehr Hashemi", "9010", "+981111111110");
        //Airlines
        public static Airline airline1 = new Airline("Mahan");
        public static Airline airline2 = new Airline("IranAir");
        public static Airline airline3 = new Airline("KishAir");
        public static Airline airline4 = new Airline("Asemaan");
        //Flights
        public static List<Flight> allFlights = new List<Flight>()
        {
            new Flight("1144", airline1, 100, "Hamedan", "Mashhad", new DateTime(year: 2019, month: 3, day: 21)) //0
            ,new Flight("1217", airline2, 50, "Tehran", "Esfahan", new DateTime(year: 2019, month: 3, day: 27)) //1
            ,new Flight("4113", airline4, 100, "Rasht", "Yazd", new DateTime(year: 2019, month: 5, day: 11)) //2
            ,new Flight("9525", airline1, 70, "Tehran", "Shiraz", new DateTime(year: 2019, month: 4, day: 9)) //3
            ,new Flight("9525", airline1, 70, "Shiraz", "Tehran", new DateTime(year: 2019, month: 5, day: 9)) //4
            ,new Flight("1618", airline4, 60, "Mashhad", "Tehran", new DateTime(year: 2019, month: 8, day: 15)) //5
            ,new Flight("1362", airline3, 0, "Kish", "Tehran", new DateTime(year: 2019, month: 9, day: 25)) //6
            ,new Flight("1362", airline3, 0, "Shiraz", "Tehran", new DateTime(year: 2019, month: 8, day: 24)) //7

        };
        //Tickets
        public static List<Ticket> allTickets = new List<Ticket>() {
            new Ticket(allFlights[0], 250000, null), //0  7 12 14 18 20
            new Ticket(allFlights[2], 353000, null), //1
            new Ticket(allFlights[1], 550000, null), //2
            new Ticket(allFlights[0], 650000, null), //3
            new Ticket(allFlights[3], 150000, null), //4
            new Ticket(allFlights[2], 257000, null), //5
            new Ticket(allFlights[5], 455000, null), //6
            new Ticket(allFlights[4], 150000, null), //7
            new Ticket(allFlights[3], 850000, null), //8
            new Ticket(allFlights[1], 340000, null), //9
            new Ticket(allFlights[0], 160000, null), //10
            new Ticket(allFlights[3], 190000, null), //11
            new Ticket(allFlights[4], 699000, null), //12
            new Ticket(allFlights[5], 175000, null), //13
            new Ticket(allFlights[4], 250000, null), //14
            new Ticket(allFlights[1], 503000, null), //15
            new Ticket(allFlights[2], 2450000, null), //16
            new Ticket(allFlights[3], 225000, null), //17
            new Ticket(allFlights[4], 655000, null), //18
            new Ticket(allFlights[5], 750000, null), //19
            new Ticket(allFlights[7], 750000, null)  //20
    };
        public static List<Ticket> DataFilteredExceptedTickets = new List<Ticket>() {
            allTickets[1],
            allTickets[5],
            allTickets[6],
            allTickets[7],
            allTickets[12],
            allTickets[13],
            allTickets[14],
            allTickets[16],
            allTickets[18],
            allTickets[19],
            allTickets[20]
            };
        public static List<Ticket> NowruzExceptedTickets = new List<Ticket>()
        {
            allTickets[0],
            allTickets[2],
            allTickets[3],
            allTickets[9],
            allTickets[10],
            allTickets[15]
        };
        public static List<Ticket> MahanAirTickets = new List<Ticket>()
        {
           allTickets[0],
           allTickets[3],
           allTickets[4],
           allTickets[7],
           allTickets[8],
           allTickets[10],
           allTickets[11],
           allTickets[12],
           allTickets[14],
           allTickets[17],
           allTickets[18],
        };
        public static List<Ticket> ShirazToTeh = new List<Ticket>()
        {
            allTickets[7],
            allTickets[12],
            allTickets[14],
            allTickets[18],
            allTickets[20]
        };
    }
}
