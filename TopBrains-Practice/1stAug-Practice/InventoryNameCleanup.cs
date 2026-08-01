using System;
using System.Globalization;
using System.Text;

class InventoryNameCleanup
{
    public static void Start()
    {
        string input = Console.ReadLine();

        input = input.Trim();

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            if (i == 0 || input[i] != input[i - 1])
            {
                sb.Append(input[i]);
            }
        }

        string[] words = sb.ToString().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        string result = string.Join(" ", words);

        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        result = textInfo.ToTitleCase(result.ToLower());

        Console.WriteLine(result);
    }
}