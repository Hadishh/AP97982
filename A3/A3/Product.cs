using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Product
    {
        public string _Name;
        public float _Price;
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
        public float Price
        {
            get
            {
                return _Price;
            }
            set
            {
                _Price = value;
            }
        }
        public Product(string name, float price)
        {
            Name = name;
            Price = price;
        }
    }
}