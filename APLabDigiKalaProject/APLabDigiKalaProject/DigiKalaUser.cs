namespace APLabDigiKalaProject
{
    public class DigiKalaUser
    {
        public DigiKalaUser(string fullName, double accountCredit) 
        {
            Id = IdHandler++;
            FullName = fullName;
            AccountCredit = accountCredit;
        }
        public int Id { get; set; }
        static int IdHandler = 2000;
        public string FullName { get; }
        public double AccountCredit { get; set; }
        public bool ExpendCredit(double amount)
        {
            if (AccountCredit < amount || amount < 0)
                return false;
            AccountCredit -= amount;
            return true;
        }
        public bool AddupCredit(double amount)
        {
            if (amount < 0)
                return false;
            AccountCredit += amount;
            return true;
        }
    }
}
