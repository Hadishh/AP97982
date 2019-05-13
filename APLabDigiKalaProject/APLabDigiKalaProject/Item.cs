using System;

namespace APLabDigiKalaProject
{
    public class Item
    {
        public Item(string title, double price, DateTime date, string brand, string seller)
        {
            this.Title = title;
            this.Id = 0;
            this.Brand = brand;
            this.Price = price;
            this.Date = date;
            Seller = seller;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        private double _Price;
        public double Price
        {
            get
            {
                return _Price;
            }
            set
            {
                //Update Price
                if (value > _Price * 1.2 && _Price != 0)
                {
                    _Price = _Price * 1.2;
                }
                else if (value < _Price * 0.8)
                {
                    _Price = _Price * 0.8;
                }
                else
                {
                    _Price = value;
                }
            }
        }
        public DateTime Date { get; set; }
        public string Brand { get; set; }
        public string Seller;
        //Seller Not Implemented
        //TODO
        public void AddToCart(/*Customer customer*/)
        {
            //TODO
        }
        

    }
}
