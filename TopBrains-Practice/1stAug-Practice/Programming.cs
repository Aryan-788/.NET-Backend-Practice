using System;

class Programming
{
    static int SumOfDigits(int num)
    {
        int sum = 0;

        while (num > 0)
        {
            sum += num % 10;
            num /= 10;
        }

        return sum;
    }

    static bool IsPrime(int num)
    {
        if (num <= 1)
            return false;

        for (int i = 2; i <= Math.Sqrt(num); i++)
        {
            if (num % i == 0)
                return false;
        }

        return true;
    }

    public static void Start()
    {
        int m = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());

        int count = 0;

        for (int x = m; x <= n; x++)
        {
            if (x > 0 && !IsPrime(x))
            {
                int s = SumOfDigits(x);
                int squareSum = SumOfDigits(x * x);

                if (squareSum == s * s)
                {
                    count++;
                }
            }
        }

        Console.WriteLine(count);
    }
}