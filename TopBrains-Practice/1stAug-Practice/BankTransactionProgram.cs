using System;

class BankTransactionProgram
{
    static int FinalBalance(int initialBalance, int[] transactions)
    {
        int balance = initialBalance;

        foreach (int transaction in transactions)
        {
            if (transaction >= 0)
            {
                // Deposit
                balance += transaction;
            }
            else
            {
                // Withdraw only if enough balance
                if (balance >= -transaction)
                {
                    balance += transaction;   // transaction is negative
                }
            }
        }

        return balance;
    }

    public static void Start()
    {
        int initialBalance = int.Parse(Console.ReadLine());

        int n = int.Parse(Console.ReadLine());

        int[] transactions = new int[n];

        for (int i = 0; i < n; i++)
        {
            transactions[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine(FinalBalance(initialBalance, transactions));
    }
}