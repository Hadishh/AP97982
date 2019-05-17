using System;
using System.Collections.Generic;
namespace APLabDigiKalaProject
{
    public class Seller: DigiKalaUser
    {
        public Seller(string fullName, double accountCredit, List<Item> shopItems, string shopName):
            base(fullName, accountCredit)
        {
            ShopItems = shopItems;
            ShopName = shopName;
        }
        public List<Item> ShopItems { get; set; }
        public string ShopName { get; }
        public int ReleaseNewItem(Item item)
        {
            ShopItems.Add(item);
            return ShopItems.Count;
        }
    }
}
