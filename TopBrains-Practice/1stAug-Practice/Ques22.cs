using System;
using System.Collections.Generic;
using System.Text;

public class Ques22
{
    static bool IsVowel(char ch)
    {
        ch = char.ToLower(ch);
        return ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u';
    }

    public static void Start()
    {
        string first = Console.ReadLine();
        string second = Console.ReadLine();

        HashSet<char> secondChars = new HashSet<char>();

        foreach (char c in second)
        {
            secondChars.Add(char.ToLower(c));
        }

        StringBuilder temp = new StringBuilder();

        // Task 1: Remove common consonants
        foreach (char c in first)
        {
            char lower = char.ToLower(c);

            if (!IsVowel(c) && secondChars.Contains(lower))
                continue;

            temp.Append(c);
        }

        // Task 2: Remove consecutive duplicates
        StringBuilder result = new StringBuilder();

        foreach (char c in temp.ToString())
        {
            if (result.Length == 0 || result[result.Length - 1] != c)
            {
                result.Append(c);
            }
        }

        Console.WriteLine(result.ToString());
    }
}