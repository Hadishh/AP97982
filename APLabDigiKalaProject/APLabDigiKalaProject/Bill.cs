using System.Collections.Generic;
namespace APLabDigiKalaProject
{
    public class Bill
    {
        public List<Item> Items { get; set; }
        public double Checkout { get; set; }
        public bool Paid { get; private set; }
        DigiKalaUser User { get; }
        public Bill(DigiKalaUser user)
        {
            User = user;
            Paid = false;
        }
        public bool PayByCredit()
        {
            if(Checkout > User.AccountCredit)
                return false;
            User.AccountCredit -= Checkout;
            this.Paid = true;
            return true;
        }
    }
}
