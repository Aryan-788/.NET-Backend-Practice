using System;
using System.Collections.Generic;

class Ques2
{

    public static bool TryParseISBN(string input, out string cleanedISBN)
    {
        cleanedISBN = input.Replace("-", "").Replace(" ", "");

        if(cleanedISBN.Length == 13)
        {
            foreach(char ch in cleanedISBN)
            {
                if (!char.IsDigit(ch))
                {
                    cleanedISBN = "";
                    return false;
                }
            }
            return true;
        }
        cleanedISBN = "";
        return false;
    }
    public static bool TryProcessOrdeer(out List<string> validISBNs, params string[] isbnList)
    {
        validISBNs = new List<string>();

        foreach(string isbn in isbnList)
        {
            string cleanedISBN;

            if(TryParseISBN(isbn, out cleanedISBN))
            {
                validISBNs.Add(cleanedISBN);
            }
        }

        return validISBNs.Count > 0;
    }

    public static void Start()
    {
        List<string> validBooks;

        bool res = TryProcessOrdeer(out validBooks, "978-3-16-148410-0", "978 1 56619 909 4", "978-0-306-40615-7", "978-0-306-40615-X", "invalid-isbn");

        Console.WriteLine("Order Processed: " + res);

        Console.WriteLine("Valid ISBNs:");

        foreach (string isbn in validBooks)
        {
            Console.WriteLine(isbn);
        }
    }
}