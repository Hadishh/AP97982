using System.Collections.Generic;
namespace APLabDigiKalaProject
{
    public class DigiKala
    {
        public DigiKala(List<Customer> customers, List<Seller> sellers, ItemInventory inventory)
        {
            Inventory = inventory;
            Customers = customers;
            Sellers = sellers;
            AllUsers = new List<DigiKalaUser>();
            AllUsers.AddRange(sellers);
            AllUsers.AddRange(customers);
        }
        List<DigiKalaUser> AllUsers;
        public List<Customer> Customers { get; set; }
        public List<Seller> Sellers { get; set; }
        public ItemInventory Inventory { get; set; }
        public bool RemoveUser(DigiKalaUser user) => AllUsers.Remove(user);
    }
}
