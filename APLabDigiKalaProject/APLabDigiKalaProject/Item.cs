using System;

namespace APLabDigiKalaProject
{
    public class Item
    {
        public Item(string title, double price, DateTime date, string brand, Seller seller)
        {
            this.Title = title;
            this.Id = IdHandler++;
            this.Brand = brand;
            this.Price = price;
            this.Date = date;
            Seller = seller;
            Seller.ReleaseNewItem(this);
        }
        public int Id { get; set; }
        static int IdHandler = 0;
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
        public Seller Seller;
        //Seller Not Implemented
        //TODO
        public void AddToCart(/*Customer customer*/)
        {
            //TODO
        }
        

    }
}
