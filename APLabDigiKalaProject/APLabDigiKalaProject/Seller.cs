using System;
using System.Collections.Generic;
namespace APLabDigiKalaProject
{
    public class Seller: DigiKalaUser
    {
        public Seller(string fullName, double accountCredit, string shopName):
            base(fullName, accountCredit)
        {
            ShopItems = new List<Item>();
            ShopName = shopName;
        }
        public List<Item> ShopItems { get; set; }
        public string ShopName { get; }
        public int ReleaseNewItem(Item item)
        {
            ShopItems.Add(item);
            AccountCredit -= item.Price;
            return ShopItems.Count;
        }
    }
}
