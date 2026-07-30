class InsufficientAmount : Exception
{
    public InsufficientAmount(string msg): base(msg)
    {
        
    }
}

class Program
{
    public static void Main()
    {
        decimal openingBalance = GetDecimalInput("Enter Opening Balance: ");
        decimal depositAmount = GetDecimalInput("Enter Deposit Amount: ");
        decimal withdrawalAmount = GetDecimalInput("Enter Withdrawals Amount: ");

        try
        {
            if (withdrawalAmount > openingBalance)
            {
                throw new InsufficientAmount("Insufficient Balance...");
            }
        }catch(InsufficientAmount ex)
        {
            Console.WriteLine(ex.Message);
        }

        openingBalance += depositAmount;

        Console.WriteLine("Updated Balance: " + openingBalance);    

    }

    public static decimal GetDecimalInput(string str)
    {
        while (true)
        {
            Console.Write(str);
            if (!decimal.TryParse(Console.ReadLine(), out decimal value))
            {
                Console.WriteLine("Invalid Input Format!");
            }
            else if (value <= 0)
            {
                Console.WriteLine("Value Can't be in negative...");
            }
            else
            {
                return value;
            }
        }
    }
}