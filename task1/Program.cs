
namespace ConsoleApp1
{
    public class Account
    {
        private string name;
        private decimal balance;

        public Account(string name, decimal startingBalance)
        {
            this.name = name;
            this.balance = startingBalance;
        }

        public void Deposit(decimal amountToAdd)
        {
            balance += amountToAdd;
        }

        public void Withdraw(decimal amountToWithdraw)
        {
            if (amountToWithdraw > balance)
            {
                Console.WriteLine("Insufficient funds. Withdrawal not allowed.");
            }
            else
            {
                balance -= amountToWithdraw;
            }
        }
        public string Name
        {
            get { return name; }
        }

        public void Print()
        {
            Console.WriteLine($"Account Name: {name}");
            Console.WriteLine($"Balance: $ { balance}");
        }

        public class Program
        {
            public static void Main()
            {
                Account account = new Account("Jake's Account™", 200000);
                account.Deposit(10000);
                account.Print();
            }
        }
    }
}
          
