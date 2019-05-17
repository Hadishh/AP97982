using System.Collections.Generic;
using System;

namespace APLabDigiKalaProject
{
    public class Customer: DigiKalaUser
    {
        public Customer(string fullName, double accountCredit, Cart cart, List<Bill> bills) :
            base(fullName, accountCredit)
        {
            if (cart.Owner != this)
                throw new ArgumentException($"This Cart Dosen't Belong To Customer : {fullName}");
            Cart = cart;
            Bills = bills;
        }
        public Customer(string fullName, double accountCredit) :
            base(fullName, accountCredit)
        {
            Cart = new Cart(this, new List<Item>(), 0);
            Bills = new List<Bill>();
        }
        public Cart Cart { get; set; }
        public List<Bill> Bills { get; set; }
        public double AddToCart(Item item)
        {
            return Cart.AddItem(item);
        }
        public Bill MakeBill()
        {
            Bill lastBill = new Bill(this);
            return lastBill;
        }
    }
}
