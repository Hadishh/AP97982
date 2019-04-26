using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Customer
    {
        private string _Name;
        public City City { get; set; }
        public List<Order> Orders { get; set; }
        public string Name
        {
            get { return _Name; }
            set
            {
                if (value == string.Empty)
                    throw new Exception("Customer's name can't be empty");
                _Name = value;
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
                foreach(var product in order.Products)
                    if (repeats.ContainsKey(product))
                        repeats[product]++;
                    else
                        repeats.Add(product, 0);
            int max = repeats.Values.ToList().Max();
            Product mostOrderedProduct = null;
            foreach(var item in repeats)
                if(item.Value == max)
                {
                    mostOrderedProduct = item.Key;
                    break;
                }
            return mostOrderedProduct;
        }

        public List<Order> UndeliveredOrders()
        {
            List<Order> undeliveredOrders = new List<Order>();
            foreach(var order in Orders)
                if (!order.IsDelivered)
                    undeliveredOrders.Add(order);
            return undeliveredOrders;
        }
    }
}