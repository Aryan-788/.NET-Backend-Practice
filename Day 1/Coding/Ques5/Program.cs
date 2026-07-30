using System;

class Project
{
    public static void Main()
    {
        Console.WriteLine("Five marks such as: ");

        double sum = 0;
        double marks;

        for(int i=0;i<5; i++)
        {
            marks = TakeInput();
            sum += marks;
            
        }

        double avg = sum / 5;
        double percentage = sum / 500 * 100;

        Console.WriteLine("Total: " + sum);
        Console.WriteLine("Average: " + avg);
        Console.WriteLine("Percentage: " + percentage.ToString("F2"));

    }

    public static double TakeInput()
    {
        while (true)
        {
            if(!double.TryParse(Console.ReadLine(), out double marks))
            {
                Console.WriteLine("Invalid Marks Format!");
            }else if(marks < 0 || marks > 100)
            {
                Console.WriteLine("Makrs Must be in between 0 and 100");
            }
            else
            {
                return marks;
            }
        }
    }
}