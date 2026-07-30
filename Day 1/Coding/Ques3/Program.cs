
using System;

class Program
{
    public static void Main()
    {
        double Length = GetDoubleInput("Length: ");
        double Width = GetDoubleInput("Width: ");
        double Height = GetDoubleInput("Height: ");
        double volumn = Length * Width * Height;

        Console.WriteLine("***Details***");
        Console.WriteLine("Length: "+ Length);
        Console.WriteLine("Width: " + Width);
        Console.WriteLine("Height: " + Height);
        Console.WriteLine("Volumn : " + volumn.ToString("F2"));
    }

    public static double GetDoubleInput(string str)
    {
        while (true)
        {
            Console.Write(str);
            if(!double.TryParse(Console.ReadLine(), out double value))
            {
                Console.WriteLine("Invalid Input Format!");
            }
            else if(value <= 0){
                Console.WriteLine("Value Can't be in negative...");
            }
            else
            {
                return value;
            }
        }
    }
}