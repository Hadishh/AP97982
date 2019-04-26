using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Shop
    {
        private string _Name;
        public List<Customer> Customers { get; set; }
        public string Name
        {
            get { return _Name; }
            set
            {
                if (value == string.Empty)
                    throw new Exception("Shop name can't be empty");
                _Name = value;
            }
        }
        public Shop(string name, List<Customer> customers)
        {
            Name = name;
            Customers = customers;
        }
        public List<City> CitiesCustomersAreFrom()
        {
            List<City> citiesCustomersAreFrom = new List<City>();
            foreach(Customer customer in Customers)
                if (!citiesCustomersAreFrom.Contains(customer.City))
                    citiesCustomersAreFrom.Add(customer.City);
            return citiesCustomersAreFrom;
        }
        public List<Customer> CustomersFromCity(City city)
        {
            List<Customer> customersFromCity = new List<Customer>();
            foreach(var customer in Customers)
                if(customer.City == city)
                    customersFromCity.Add(customer);
            return customersFromCity;
        }
        public List<Customer> CustomersWithMostOrders()
        {
            //find Most Orders!
            long maxOrdersCount = 0;
            foreach(var customer in Customers)
                if (customer.Orders.Count > maxOrdersCount)
                    maxOrdersCount = customer.Orders.Count;
            //List All Customers With That Max Orders Value
            List<Customer> mostOrderedCustomers = new List<Customer>();
            foreach(var customer in Customers)
                if (customer.Orders.Count == maxOrdersCount)
                    mostOrderedCustomers.Add(customer);
            return mostOrderedCustomers;
        }
    }
}