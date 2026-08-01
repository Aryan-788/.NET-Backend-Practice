using System;

public class Ques27
{
    static double? Average(double?[] values)
    {
        double sum = 0;
        int count = 0;

        foreach (double? value in values)
        {
            if (value.HasValue)
            {
                sum += value.Value;
                count++;
            }
        }

        if (count == 0)
            return null;

        return Math.Round(sum / count, 2, MidpointRounding.AwayFromZero);
    }

    public static void Start()
    {
        int n = int.Parse(Console.ReadLine());

        double?[] values = new double?[n];

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();

            if (input.ToLower() == "null")
                values[i] = null;
            else
                values[i] = double.Parse(input);
        }

        double? result = Average(values);

        if (result.HasValue)
            Console.WriteLine(result.Value);
        else
            Console.WriteLine("null");
    }
}