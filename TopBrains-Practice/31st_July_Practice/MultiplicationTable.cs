// Return the multiplication table row for a number n from 1..upto.
// Example: n = 3, upto = 5-> [3, 6, 9, 12, 15]

// Input: n(int), upto(int)
// Output: row(int[])

// Constraints:
// 0 <= upto <= 1e5
// - 1e4 <= n <= 1e4

using System;

class MultiplicationTable
{
    public static int[] GetRow(int n, int upto)
    {
        int[] row = new int[upto];
        for (int i = 0; i < upto; i++)
        {
            row[i] = n * (i + 1);
        }
        return row;
    }

    public static void Start()
    {
        int n = 3;
        int upto = 5;
        int[] row = GetRow(n, upto);
        Console.WriteLine("Multiplication table for " + n + " up to " + upto + ":");
        foreach (int value in row)
        {
            Console.Write(value + " ");
        }
        Console.WriteLine();
    }
}