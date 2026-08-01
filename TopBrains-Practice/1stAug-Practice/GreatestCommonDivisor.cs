using System;

public class GreatestCommonDivisor
{
    static int GCD(int a, int b)
    {
        if (b == 0)
            return a;

        return GCD(b, a % b);
    }

    public static void Start()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());

        Console.WriteLine(GCD(a, b));
    }
}
