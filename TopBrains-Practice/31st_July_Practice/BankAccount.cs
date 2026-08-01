using System;
// namespace BankSys
// {
    public class Account
    {
        // TODO: Add private fields
        private string name;
        private double balance;

        // TODO: Implement constructor
        public Account(string name, double initialBalance)
        {
            this.name = name;
            this.balance = initialBalance;
        }

        // TODO: Implement deposit method
        public double Deposit(double amount)
        {
            balance += amount;
            return balance;
        }

        // TODO: Implement getBalance method
        public double GetBalance()
        {
            return balance;
        }

        // TODO: Implement setName method
        public void SetName(string newName)
        {
            name = newName;
        }

        // TODO: Implement getName method
        public string GetName()
        {
            return name;
        }
    }

    class BankAccount
    {
        public static void Start()
        {
            // Test your implementation here
            Account account1 = new Account("Alok Mittal", 1250.00);
            Console.WriteLine(account1.GetBalance());

            Account account2 = new Account("John Doe", 500);
            Console.WriteLine(account2.GetBalance());

            Console.WriteLine(account1.Deposit(0.5));
            Console.WriteLine(account1.GetBalance());

            account1.SetName("Riya Verma");
            Console.WriteLine(account1.GetName());
        }
    }
// }