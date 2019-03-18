using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Order
    {
        public List<Product> _Products;
        public bool _IsDelivered;
        public List<Product> Products
        {
            get
            {
                return _Products;
            }
            set
            {
                _Products = value;
            }
        }
        public bool IsDelivered
        {
            get
            {
                return _IsDelivered;
            }
            set
            {
                _IsDelivered = value;
            }
        }
        public Order(List<Product> products, bool isDelivered)
        {
            Products = products;
            IsDelivered = isDelivered;
        }

        public float CalculateTotalPrice()
        {
            float allPrice = 0f;
            foreach(var item in Products)
            {
                allPrice += item.Price;
            }
            return allPrice;
        }
    }
}