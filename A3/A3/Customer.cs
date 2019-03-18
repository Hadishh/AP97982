using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Customer
    {
        public string _Name;
        public City _City;
        public List<Order> _Orders;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }
        public City City
        {
            get
            {
                return _City;
            }
            set
            {
                _City = value;
            }
        }
        public List<Order> Orders
        {
            get
            {
                return _Orders;
            }
            set
            {
                _Orders = value;
            }
        }
        public Customer(string name, City city, List<Order> orders)
        {
            Name = name;
            City = city;
            Orders = orders;
        }

        public Product MostOrderedProduct()
        {
            Dictionary<Product, int> repeats = new Dictionary<Product, int>();
            foreach(Order order in Orders)
            {
                foreach(var product in order.Products)
                {
                    if (repeats.ContainsKey(product))
                    {
                        repeats[product]++;
                    }
                    else
                    {
                        repeats.Add(product, 0);
                    }
                }
            }
            int max = repeats.Values.ToList().Max();
            Product mostOrderedProduct = null;
            foreach(var item in repeats)
            {
                if(item.Value == max)
                {
                    mostOrderedProduct = item.Key;
                    break;
                }
            }
            return mostOrderedProduct;
        }

        public List<Order> UndeliveredOrders()
        {
            List<Order> undeliveredOrders = new List<Order>();
            foreach(var order in Orders)
            {
                if (!order.IsDelivered)
                    undeliveredOrders.Add(order);
            }
            return undeliveredOrders;
        }
    }
}