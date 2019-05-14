using System.Collections.Generic;

namespace APLabDigiKalaProject
{
    public class Cart
    {
        public Cart(Customer owner, List<Item> items, double totalAmount)
        {
            Owner = owner;
            Items = items;
            TotalAmount = totalAmount;
        }
        public Customer Owner { get; set; }
        public List<Item> Items { get; set; }
        public double TotalAmount { get; set; }
        public Bill Finalize()
        {
            //TODO
            return null;
        }
        public double AddItem(Item item)
        {
            Items.Add(item);
            return item.Price;
        }
        public bool RemoveItem(Item item) => Items.Remove(item);
    }
}
