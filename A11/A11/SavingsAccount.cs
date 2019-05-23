using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace A11
{
    public class SavingsAccount : Account
    {
        public double InterestRate { get; set; }
        public SavingsAccount(double balance, double interestRate)
            : base(balance)
        {
            InterestRate = interestRate;
        }
        public double CalculateInterest()
            => this.Balance * InterestRate;
    }
}
