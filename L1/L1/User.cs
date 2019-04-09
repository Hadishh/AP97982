using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    public class User
    {
        public string FullName;

        public string NationalID;

        public string PhoneNumber;

        public List<Ticket> Tickets;

        public double Account;

        public User(string fullName, string nationalID, string phoneNumber, double account = 0)
        {
            FullName = fullName;
            NationalID = nationalID;
            PhoneNumber = phoneNumber;
            Tickets = new List<Ticket>();
            Account = account;
            DB.AddUser(this);
        }

        /// <summary>
        /// reserve new ticket
        /// do necessary changes on Ticket, Flight, and User properties.
        /// </summary>
        /// <param name="ticket"></param>
        public void Reserve(Ticket ticket)
        {
            //TODO
            Tickets.Add(ticket);
            ticket.Flight.Capacity--;
            Account -= ticket.Price;
            ticket.Buyer = this;
        }

        /// <summary>
        /// cancel ticket reservation
        /// do necessary changes on Ticket, Flight, and User properties.
        /// 40% of the ticket price backs to the buyer account
        /// </summary>
        /// <param name="ticket"></param>
        public void Cancel(Ticket ticket)
        {
            ticket.Buyer = null;
            Account += ticket.Price * 40 / 100f;
            ticket.Flight.Capacity++;
            Tickets.Remove(ticket);
        }

        /// <summary>
        /// returns tickets with dates between two significant dates
        /// </summary>
        /// <param name="startDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <returns></returns>
        public List<Ticket> DateFilteredTickets(DateTime startDateTime, DateTime endDateTime)
        {
            List<Ticket> dateFilteredTickets = new List<Ticket>();
            List<Ticket> allTickets = DB.Tickets;
            foreach(Ticket item in allTickets)
            {
                int firstCompare = DateTime.Compare(startDateTime, item.Flight.FlyDate);
                int secondCmpare = DateTime.Compare(item.Flight.FlyDate, endDateTime);
                if (firstCompare >= 0 && secondCmpare >= 0)
                    dateFilteredTickets.Add(item);
            }
            if (dateFilteredTickets.Count == 0)
                return null;
            else
                return dateFilteredTickets;
        }

        /// <summary>
        /// returns tickets with dates between 18 March, 28 March
        /// </summary>
        /// <returns></returns>
        public List<Ticket> NowruzTickets()
        {
            List<Ticket> nowruzTickets = new List<Ticket>();
            List<Ticket> allTickets = DB.Tickets;
            foreach(Ticket item in allTickets)
            {
                if(item.Flight.FlyDate.Month == 3 && item.Flight.FlyDate.Day <= 28 
                    && item.Flight.FlyDate.Day >= 18)
                {
                    nowruzTickets.Add(item);
                }
            }
            if (nowruzTickets.Count == 0)
                return null;
            else
                return nowruzTickets;
        }

        /// <summary>
        /// returns tickets of a significant airline
        /// </summary>
        /// <param name="airline"></param>
        /// <returns></returns>
        public List<Ticket> AirlineTickets(Airline airline)
        {
            List<Ticket> airlineTickets = new List<Ticket>();
            List<Ticket> allTickets = DB.Tickets;
            foreach(Ticket item in allTickets)
            {
                if (item.Flight.AirLine == airline)
                    airlineTickets.Add(item);
            }
            if (airlineTickets.Count == 0)
                return null;
            else
                return airlineTickets;
        }

        /// <summary>
        /// returns tickets with a significent route
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <returns></returns>
        public List<Ticket> RouteTickets(string source, string dest)
        {
            List<Ticket> routeTickets = new List<Ticket>();
            List<Ticket> allTickets = DB.Tickets;
            foreach (Ticket item in allTickets)
            {
                if (item.Flight.Source == source && item.Flight.Destination == dest)
                    routeTickets.Add(item);
            }
            if (routeTickets.Count == 0)
                return null;
            else
                return routeTickets;
        }

    }
}
