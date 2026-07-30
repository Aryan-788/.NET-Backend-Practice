using System;

class Ques4
{
    static double CalculateArea(double radius, int decimals = 2)
    {
        double area = Math.PI * radius * radius;
        return Math.Round(area, decimals);
    }

    static double CalculateArea(double length, double width)
    {
        return length * width;
    }

    static double CalculateArea(double triangleBase, double height, bool isTriangle)
    {
        return 0.5 * triangleBase * height;
    }

    public static void Start()
    {
        Console.WriteLine("Circle Area = " + CalculateArea(5));

        Console.WriteLine("Rectangle Area = " + CalculateArea(4, 6));

        Console.WriteLine("Triangle Area = " + CalculateArea(3, 7, true));

        Console.WriteLine("Circle Area (4 decimals) = " + CalculateArea(radius: 5, decimals: 4));

    }
}