using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A11
{
    public class Account
    {
        public Account(double balance)
        {
            if (balance < 0)
            {
                Console.WriteLine("Initial balance is invalid. Setting balance to 0.");
                Balance = 0;
            }
            else
                Balance = balance;
        }
        public double Balance { get; set; }
        public void Credit(double amount)
        {
            if (amount < 0)
                throw new ArgumentException("Credit amount must be positive");
            Balance += amount;
        }
        public bool Debit(double amount)
        {
            if (amount < 0)
                throw new ArgumentException("Debit amount must be positive");
            if (Balance - amount < 0)
            {
                Console.WriteLine("Debit amount exceeded account balance.");
                return false;
            }
            else
            {
                Balance -= amount;
                return true;
            }
        }
    }
}
