using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    public class DB
    {
        public static List<Airline> Airlines = new List<Airline>();

        public static List<User> Users = new List<User>();

        public static List<Ticket> Tickets = new List<Ticket>();

        public static List<Flight> Flights = new List<Flight>();

        public static void AddAirline(Airline airline)
        {
            Airlines.Add(airline);
        }

        public static void AddTicket(Ticket ticket)
        {
            Tickets.Add(ticket);
        }

        public static void AddUser(User user)
        {
            Users.Add(user);
        }

        public static void AddFlight(Flight flight)
        {
            Flights.Add(flight);
        }

        public static void DeleteAirline(Airline airline)
        {
            Airlines.Remove(airline);
        }

        public static void DeleteTicket(Ticket ticket)
        {
            Tickets.Remove(ticket);
        }

        public static void DeleteUser(User user)
        {
            Users.Remove(user);
        }

        public static void DeleteFlight(Flight flight)
        {
            Flights.Remove(flight);
        }

        /// <summary>
        /// returns most expensive ticket
        /// </summary>
        /// <returns></returns>
        public static Ticket MostExpensiveTicket()
        {
            double maxPrice = 0;
            Ticket maxPriceTicket = null;
            foreach(var ticket in Tickets)
            {
                if(ticket.Price > maxPrice)
                {
                    maxPrice = ticket.Price;
                    maxPriceTicket = ticket;
                }
            }
            return maxPriceTicket;
        }

        /// <summary>
        /// returns airline with most sold tickets
        /// </summary>
        /// <returns></returns>
        public static Airline FavouriteAirline()
        {
            Dictionary<Airline, int> airlineSales = new Dictionary<Airline, int>();
            foreach(var ticket in Tickets)
            {
                if (ticket.IsSold())
                {
                    if (airlineSales.ContainsKey(ticket.Flight.AirLine))
                    {
                        airlineSales[ticket.Flight.AirLine]++;
                    }
                    else
                    {
                        airlineSales.Add(ticket.Flight.AirLine, 1);
                    }
                }
            }
            int max = airlineSales.Values.ToList().Max();
            foreach(var item in airlineSales)
            {
                if (item.Value == max)
                    return item.Key;
            }
            return null;
        }

        /// <summary>
        /// returns amount of money users should pay from their credit accounts
        /// </summary>
        /// <returns></returns>
        public static double UsersDebts()
        {
            double allPrice = 0.0;
            foreach(var item in Users)
            {
                if(item.Account < 0)
                {
                    allPrice += item.Account;
                }
            }
            return allPrice;
        }

        /// <summary>
        /// returns passengers favourite destination
        /// </summary>
        /// <returns></returns>
        public static string FavouriteDestination()
        {
            Dictionary<string, int> destRepeats = new Dictionary<string, int>();
            foreach(var item in Flights)
            {
                if (destRepeats.ContainsKey(item.Destination))
                {
                    destRepeats[item.Destination]++;
                }
                else
                {
                    destRepeats.Add(item.Destination, 1);
                }
            }
            int maxRepeat = destRepeats.Values.ToList().Max();
            foreach(var dic in destRepeats)
            {
                if (maxRepeat == dic.Value)
                    return dic.Key;
            }
            return null;
        }

    }
}
