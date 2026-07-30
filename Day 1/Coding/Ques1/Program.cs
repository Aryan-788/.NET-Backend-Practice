using System;
class Question1
{
    public static void Main()
    {
        // Console.Write("Price: ");
        // decimal price = Convert.ToDecimal(Console.ReadLine());
        decimal price = GetDecimalInput("Price: ");

        // Console.Write("Quantity: ");
        // int quantity = Convert.ToInt32(Console.ReadLine());
        int quantity = GetIntInput("Quantity: ");


        // Console.Write("Discount: ");
        // int discount = Convert.ToInt32(Console.ReadLine());
        int discount = GetIntInput("Discount: ");

        decimal total = price * quantity;
        decimal discountPrice = (discount / 100m) * total;
        decimal payableAmount = total - discountPrice;


        Console.WriteLine("---- Summary ----");
        Console.WriteLine("Total Price: " + total);
        Console.WriteLine("Discount Amount: " + discountPrice);
        Console.WriteLine("Final Payable Amount: " + payableAmount.ToString("F2"));

    }
    public static decimal GetDecimalInput(string str)
    {
        while (true)
        {
            Console.Write(str);
            if(!decimal.TryParse(Console.ReadLine(), out decimal value))
            {
                Console.WriteLine("Invalid Input Format");
            }
            else
            {
                return value;
            }
        }
    }

    public static int GetIntInput(string str)
    {
        while (true)
        {
            Console.Write(str);
            if (!int.TryParse(Console.ReadLine(), out int value))
            {
                Console.WriteLine("Invalid Input Format");
            }
            else
            {
                return value;
            }
        }

    }
}