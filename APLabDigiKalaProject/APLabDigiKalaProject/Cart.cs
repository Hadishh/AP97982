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
            Bill finalizedBill = new Bill(Owner);
            finalizedBill.Checkout = TotalAmount;
            return finalizedBill;
        }
        public double AddItem(Item item)
        {
            Items.Add(item);
            TotalAmount += item.Price;
            return item.Price;
        }
        public bool RemoveItem(Item item)
        {
            if (!Items.Contains(item))
                return false;
            TotalAmount -= item.Price;
            Items.Remove(item);
            return true;
        }
            
    }
}
