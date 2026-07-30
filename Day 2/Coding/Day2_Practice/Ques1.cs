using System;

public static class FinancialCalculator
{
    public static double CalculateCompoundInterest(double principal, double rate, int time)
    {
        int compundingFreq = 1;
        return principal * Math.Pow((1 + rate / compundingFreq), compundingFreq * time);
    }

    public static double CalculateCompoundInterest(double principal, double rate, int time, int compundingFreq)
    {
        return principal * Math.Pow((1 + rate / compundingFreq), compundingFreq * time);
    }

    // method with default parameter values
    public static double CalculateCompoundInterestWithDefaults(double principal, double rate, int time = 1, int compundingFreq = 1)
    {
        return principal * Math.Pow((1 + rate / compundingFreq), compundingFreq * time);
    }
}

class Ques1
{
    public static void Start()
    {
        double amt1 = FinancialCalculator.CalculateCompoundInterest(10000, 0.05, 10);

        double amt2 = FinancialCalculator.CalculateCompoundInterest(10000, 0.05, 10, 12);

        Console.WriteLine("Future Value (Annually): $" + amt1.ToString("F2"));
        Console.WriteLine("Future Value (Monthly): $" + amt2.ToString("F2"));   

        Console.WriteLine();

        double amt3 = FinancialCalculator.CalculateCompoundInterestWithDefaults(10000, 0.05);

        Console.WriteLine("Future Value (Annually with Defaults): $" + amt3.ToString("F2"));

        double amt4 = FinancialCalculator.CalculateCompoundInterest(principal: 10000, rate: 0.05, time: 10, compundingFreq: 12);

        Console.WriteLine("Future Value (Monthly with Named Parameters): $" + amt4.ToString("F2"));


    }
}