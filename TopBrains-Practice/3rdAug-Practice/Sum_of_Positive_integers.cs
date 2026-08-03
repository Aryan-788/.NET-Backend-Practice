using System;

class Sum_of_Positive_integers
{
    static int SumPositive(int[] nums)
    {
        int sum = 0;

        foreach (int num in nums)
        {
            if (num == 0)
                break;         

            if (num < 0)
                continue;       

            sum += num;        
        }

        return sum;
    }

    public static void Start()
    {
        int n = int.Parse(Console.ReadLine());

        int[] nums = new int[n];

        for (int i = 0; i < n; i++)
        {
            nums[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine(SumPositive(nums));
    }
}