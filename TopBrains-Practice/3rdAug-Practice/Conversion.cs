using System;

class Conversion
{
    static double FeetToCentimeters(int feet)
    {
        double centimeters = feet * 30.48;
        return Math.Round(centimeters, 2, MidpointRounding.AwayFromZero);
    }

    public static void Start()
    {
        int feet = int.Parse(Console.ReadLine());

        Console.WriteLine(FeetToCentimeters(feet));
    }
}