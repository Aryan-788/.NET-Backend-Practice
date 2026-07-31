class Swapping
{
    static void SwapRef(ref int a, ref int b)
    {
        a = a + b;
        b = a - b;
        a = a - b;
    }

    static void SwapOut(int a, int b, out int x, out int y)
    {
        x = b;
        y = a;
    }
    public static void Start()
    {

        int num1 = 10, num2 = 20;
        Console.WriteLine("Before swapping: num1 = " + num1 + ", num2 = " + num2);
        SwapRef(ref num1, ref num2);
        Console.WriteLine("After swapping: num1 = " + num1 + ", num2 = " + num2);

        int num3 = 30, num4 = 40;
        Console.WriteLine("Before swapping: num3 = " + num3 + ", num4 = " + num4);
        SwapOut(num3, num4, out num3, out num4);
        Console.WriteLine("After swapping: num3 = " + num3 + ", num4 = " + num4);

    }
}