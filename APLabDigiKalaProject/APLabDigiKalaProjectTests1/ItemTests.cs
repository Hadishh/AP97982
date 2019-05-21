using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using APLabDigiKalaProject;

namespace APLabDigikalaTests
{
    [TestClass]
    public class DigiTests
    {
        private ItemInventory TestInitialize()
        {
            var inventory = new ItemInventory();
            var customers = new List<Customer>()
            {

            };
            var sellersTemp = new List<Seller>()
            {
                new Seller("Hadi Sheikhi", 1230, "Hadi Khan Shop"),
                new Seller("Eshsandar", 13254, "EhsanShop"),
                new Seller("Shah Soltan", 100000000009, "SoltanShop"),
                new Seller("Restaurent", 3642, "CheloKababi!")
            };
            var itemsTmp = new List<Item>()
            {
                
                new Item("Kase", 12.3, new DateTime(2012, 2, 21), "Ehsandar",sellersTemp[1]),
                new Item("Boshghab", 23, new DateTime(2000, 1, 25),"Ehsandar", sellersTemp[1]),
                new Item("Ahan", 2, new DateTime(2019, 2, 1), "Gholami", sellersTemp[0]),
                new Item("Alat", 4.5, new DateTime(2003, 7, 23), "Gholami", sellersTemp[0]),
                new Item("Docharkhe", 123.4, new DateTime(2018, 4, 4), "Gholami",sellersTemp[2]),
                new Item("Mouse", 21.3, new DateTime(2019, 1, 1), "Genius", sellersTemp[0]),
                new Item("Cat", 1, new DateTime(2020, 2, 21), "Hamsayeh", sellersTemp[3]),
                new Item("Car", 100000000, new DateTime(2030, 3, 29), "Iran Kh", sellersTemp[2]),
                new Item("Marker", 3.45, new DateTime(2012, 5, 11), "Panter", sellersTemp[3]),
                new Item("Smart Phone", 2300000, new DateTime(2017, 4, 13), "Sony", sellersTemp[2]),
            };
            
            foreach (Item item in itemsTmp)
            {
                inventory.AddItem(item);
            }

            return inventory;
        }
        

        [TestMethod]
        public void FilterDateTest()
        {
            var inv = TestInitialize();
            var releaseFilter = new ReleaseDateFilter(new DateTime(2012, 2, 12));
            var filtered = inv.Filter(new List<IFilter> { releaseFilter });

            CollectionAssert.DoesNotContain(filtered, inv.Items[1]);
        }

        [TestMethod]
        public void FilterPriceTest()
        {
            var inv = TestInitialize();
            var priceRangeFilter = new PriceRangeFilter(100, 200);
            var filtered = inv.Filter(new List<IFilter> { priceRangeFilter });

            CollectionAssert.Contains(filtered, inv.Items[4]);
        }

        [TestMethod]
        public void FilterBrandTest()
        {
            var inv = TestInitialize();
            var brandFilter = new BrandFilter("Ehsandar");
            var filtered = inv.Filter(new List<IFilter> { brandFilter });

            CollectionAssert.Contains(filtered, inv.Items[1]);
        }
    }
}