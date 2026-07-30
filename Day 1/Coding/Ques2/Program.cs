using System;

class Program
{
    public static void Main()
    {
        decimal weight = GetDecimalValue("Weight: ");
        decimal height = GetDecimalValue("Height: ");

        decimal BMI = weight / (height * height);

        Console.WriteLine("Body Details: ");
        Console.WriteLine("Body Weight: " + weight);
        Console.WriteLine("Body Height: " + height);
        Console.WriteLine("Body Mass Index: " + BMI.ToString("F2"));


    }

    public static decimal GetDecimalValue(string str)
    {
        while (true)
        {
            Console.Write(str);
            if(!decimal.TryParse(Console.ReadLine(), out decimal value))
            {
                Console.WriteLine("Invalid Input Format!");
            }
            else if(value <= 0)
            {
                Console.WriteLine($"{str} can't be in negative...");
            }
            else
            {
                return value;
            }
        }
    }
}