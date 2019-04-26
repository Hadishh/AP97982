using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Product
    {
        private string _Name;
        private float _Price;
        public string Name
        {
            get { return _Name; }
            set
            {
                if (value == string.Empty)
                    throw new Exception("Product name can't be empty");
                _Name = value;
            }
        }
        public float Price
        {
            get { return _Price; }
            set
            {
                if (value < 0f)
                    throw new Exception("Price less than zero!");
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