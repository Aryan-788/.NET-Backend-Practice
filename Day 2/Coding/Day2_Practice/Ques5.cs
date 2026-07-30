using System;

public static class MathOperations
{
    
    public static int Add(int a, int b)
    {
        return a + b;
    }

    
    public static int Add(params int[] numbers)
    {
        int sum = 0;

        foreach (int num in numbers)
        {
            sum += num;
        }

        return sum;
    }

    
    public static int Multiply(int a, int b)
    {
        return a * b;
    }

    
    public static int Multiply(params int[] numbers)
    {
        int product = 1;

        foreach (int num in numbers)
        {
            product *= num;
        }

        return product;
    }
}

class Ques5
{
    public static void Start()
    {
        
        Console.WriteLine("Add(5, 10) = " + MathOperations.Add(5, 10));

        
        Console.WriteLine("Add(1,2,3,4,5) = " + MathOperations.Add(1, 2, 3, 4, 5));

        
        Console.WriteLine("Multiply(2,3) = " + MathOperations.Multiply(2, 3));

        
        Console.WriteLine("Multiply(2,3,4,5) = " + MathOperations.Multiply(2, 3, 4, 5));
    }
}