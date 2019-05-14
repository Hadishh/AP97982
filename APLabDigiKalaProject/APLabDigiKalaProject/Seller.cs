using System;
using System.Collections.Generic;
namespace APLabDigiKalaProject
{
    public class Seller: DigiKalaUser
    {
        public Seller(int id, string fullName, double accountCredit, List<Item> shopItems, string shopName):
            base(id, fullName, accountCredit)
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
