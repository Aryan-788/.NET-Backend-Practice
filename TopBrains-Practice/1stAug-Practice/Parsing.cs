using System;

public class Parsing
{
    public static void Start()
    {
        int n = int.Parse(Console.ReadLine());

        int sum = 0;

        for (int i = 0; i < n; i++)
        {
            string token = Console.ReadLine();

            int value;
            if (int.TryParse(token, out value))
            {
                sum += value;
            }
        }

        Console.WriteLine(sum);
    }
}