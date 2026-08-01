using System;

class ArithmeticExpressions
{
    public static void Start()
    {
        string expression = Console.ReadLine();

        string[] parts = expression.Split(' ');

        // Check expression format
        if (parts.Length != 3)
        {
            Console.WriteLine("Error:InvalidExpression");
            return;
        }

        int a, b;
        if (!int.TryParse(parts[0], out a) || !int.TryParse(parts[2], out b))
        {
            Console.WriteLine("Error:InvalidNumber");
            return;
        }

        string op = parts[1];
        int result = 0;

        switch (op)
        {
            case "+":
                result = a + b;
                break;

            case "-":
                result = a - b;
                break;

            case "*":
                result = a * b;
                break;

            case "/":
                if (b == 0)
                {
                    Console.WriteLine("Error:DivideByZero");
                    return;
                }
                result = a / b;
                break;

            default:
                Console.WriteLine("Error:UnknownOperator");
                return;
        }

        Console.WriteLine(result);
    }
}