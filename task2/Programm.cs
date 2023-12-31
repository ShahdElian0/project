﻿using System.Xml.Linq;

namespace assigment2
{
    internal class Programm
    {
public class Account
        {
            private string name;
            protected double balance;

            public Account(string name = "Unnamed Account", double balance = 0.0)
            {
                this.name = name;
                this.balance = balance;
            }

            public bool Deposit(double amount)
            {
                if (amount < 0)
                    return false;
                else
                {
                    balance += amount;
                    return true;
                }
            }

            public virtual bool Withdraw(double amount)
            {
                if (balance - amount >= 0)
                {
                    balance -= amount;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public double GetBalance()
            {
                return balance;
            }

            public override string ToString()
            {
                return $"[Account: {name}: {balance}]";
            }

            
            public static double operator +(Account acc1, Account acc2)
            {
                return acc1.GetBalance() + acc2.GetBalance();
            }
        }

        
        public class SavingsAccount : Account
        {
            private double interestRate;

            public SavingsAccount(string name = "Unnamed Savings Account", double balance = 0.0, double interestRate = 0.0)
                : base(name, balance)
            {
                this.interestRate = interestRate;
            }

            public double GetInterestRate()
            {
                return interestRate;
            }

            public override string ToString()
            {
                return $"[Savings Account: {name}: {balance}, Interest Rate: {interestRate}%]";
            }
        }

        
        public class CheckingAccount : Account
        {
            private const double WithdrawalFee = 1.50;

            public CheckingAccount(string name = "Unnamed Checking Account", double balance = 0.0)
                : base(name, balance)
            {
            }

            public override bool Withdraw(double amount)
            {
                amount += WithdrawalFee;
                return base.Withdraw(amount);
            }

            public override string ToString()
            {
                return $"[Checking Account: {name}: {balance}]";
            }
        }

       
        public class TrustAccount : SavingsAccount
        {
            private const int MaxWithdrawalsPerYear = 3;
            private const double MaxWithdrawalPercentage = 0.2;
            private const double BonusAmount = 50.0;

            private int withdrawalCount;

            public TrustAccount(string name = "Unnamed Trust Account", double balance = 0.0, double interestRate = 0.0)
                : base(name, balance, interestRate)
            {
                withdrawalCount = 0;
            }

            public override bool Withdraw(double amount)
            {
                if (withdrawalCount < MaxWithdrawalsPerYear && amount <= balance * MaxWithdrawalPercentage)
                {
                    withdrawalCount++;
                    return base.Withdraw(amount);
                }
                else
                {
                    return false;
                }
            }

            public override bool Deposit(double amount)
            {
                if (amount >= 5000)
                {
                    amount += BonusAmount; 
                }
                return base.Deposit(amount);
            }

            public override string ToString()
            {
                return $"[Trust Account: {name}: {balance}, Interest Rate: {interestRate}%, Withdrawals: {withdrawalCount}/{MaxWithdrawalsPerYear}]";
            }
        }

        public static class AccountUtil
        {
           

            public static void Display(List<Account> accounts)
            {
                Console.WriteLine("\n=== Accounts ==========================================");
                foreach (var acc in accounts)
                {
                    Console.WriteLine(acc);
                }
            }

            public static void Deposit(List<Account> accounts, double amount)
            {
                Console.WriteLine("\n=== Depositing to Accounts =================================");
                foreach (var acc in accounts)
                {
                    if (acc.Deposit(amount))
                        Console.WriteLine($"Deposited {amount} to {acc}");
                    else
                        Console.WriteLine($"Failed Deposit of {amount} to {acc}");
                }
            }

            public static void Withdraw(List<Account> accounts, double amount)
            {
                Console.WriteLine("\n=== Withdrawing from Accounts ==============================");
                foreach (var acc in accounts)
                {
                    if (acc.Withdraw(amount))
                        Console.WriteLine($"Withdrew {amount} from {acc}");
                    else
                        Console.WriteLine($"Failed Withdrawal of {amount} from {acc}");
                }
            }
        }

            static void Main()
            {
               
                var accounts = new List<Account>();
                accounts.Add(new Account());
                accounts.Add(new Account("Larry"));
                accounts.Add(new Account("Moe", 2000));
                accounts.Add(new Account("Curly", 5000));

                AccountUtil.Display(accounts);
                AccountUtil.Deposit(accounts, 1000);
                AccountUtil.Withdraw(accounts, 2000);

                
                var savAccounts = new List<SavingsAccount>();
                savAccounts.Add(new SavingsAccount());
                savAccounts.Add(new SavingsAccount("Superman"));
                savAccounts.Add(new SavingsAccount("Batman", 2000));
                savAccounts.Add(new SavingsAccount("Wonderwoman", 5000, 5.0));

                AccountUtil.Display(savAccounts);
                AccountUtil.Deposit(savAccounts, 1000);
                AccountUtil.Withdraw(savAccounts, 2000);

               
                var checAccounts = new List<CheckingAccount>();
                checAccounts.Add(new CheckingAccount());
                checAccounts.Add(new CheckingAccount("Larry2"));
                checAccounts.Add(new CheckingAccount("Moe2", 2000));
                checAccounts.Add(new CheckingAccount("Curly2", 5000));

                AccountUtil.Display(checAccounts);
                AccountUtil.Deposit(checAccounts, 1000);
                AccountUtil.Withdraw(checAccounts, 2000);
                AccountUtil.Withdraw(checAccounts, 2000);

               
                var trustAccounts = new List<TrustAccount>();
                trustAccounts.Add(new TrustAccount());
                trustAccounts.Add(new TrustAccount("Superman2"));
                trustAccounts.Add(new TrustAccount("Batman2", 2000));
                trustAccounts.Add(new TrustAccount("Wonderwoman2", 5000, 5.0));

                AccountUtil.Display(trustAccounts);
                AccountUtil.Deposit(trustAccounts, 1000);
                AccountUtil.Deposit(trustAccounts, 6000);
                AccountUtil.Withdraw(trustAccounts, 2000);
                AccountUtil.Withdraw(trustAccounts, 3000);
                AccountUtil.Withdraw(trustAccounts, 500);

                Console.WriteLine();
            }
        }
    }

