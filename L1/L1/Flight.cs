using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    public class Flight
    {
        //Properties:
        //FlightID: string
        //Airline: Airline
        //Capacity: int
        //Source: string
        //Destination: string
        //FlyDate: DateTime
        string _FlightID;
        public string FlightID
        {
            get
            {
                return _FlightID;
            }
            set
            {
                if(value == null || value == string.Empty)
                {
                    throw new Exception("FlightClass :: Flight ID Field Can't Null Or Empty!");
                }
                _FlightID = value;
            }
        }
        Airline _Airline;
        public Airline AirLine
        {
            get
            {
                return _Airline;
            }
            set
            {
                if (value == null)
                {
                    throw new Exception("FlightClass :: Airline Field Can't Null! Airline Can't Set!");
                }
                else
                    _Airline = value;
            }
        }
        int _Capacity;
        public int Capacity
        {
            get
            {
                return _Capacity;
            }
            set
            {
                _Capacity = value;
            }
        }
        string _Source;
        public string Source
        {
            get
            {
                return _Source;
            }
            set
            {
                if (value == null || value == string.Empty)
                    throw new Exception("FlightClass :: Source Field Can't Null! Source Can't Set!");
                else
                {
                    _Source = value;
                }
            }
        }
        string _Destination;
        public string Destination
        {
            get
            {
                return _Destination;
            }
            set
            {
                if (value == null || value == string.Empty)
                    throw new Exception("FlightClass :: Destination Field Can't Be Null! Destination Can't Set!");
                else
                    _Destination = value;
            }
        }
        DateTime _FlyDate;
        public DateTime FlyDate
        {
            get
            {
                return FlyDate;
            }
            set
            {
                if (value == null)
                    throw new Exception("FlightClass :: FlyDate Field Can't Null! FlyDate Can't Set!");
                else
                    _FlyDate = value;
            }
        }
        /// <summary>
        /// set properties and add the object to DB
        /// </summary>
        /// <param name="id"></param>
        /// <param name="airline"></param>
        /// <param name="capacity"></param>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <param name="dateTime"></param>
        public Flight(string id, Airline airline, int capacity, string source, string dest,
            DateTime dateTime)
        {
            //TODO
            FlightID = id;
            AirLine = airline;
            Capacity = capacity;
            Source = source;
            Destination = dest;
            FlyDate = dateTime;
            DB.AddFlight(this);
        }

        public bool IsFull() => Capacity == 0;
    }
}
