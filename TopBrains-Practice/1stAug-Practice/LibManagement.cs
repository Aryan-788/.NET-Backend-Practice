using System;
using System.Collections.Generic;

class LibManagement
{
    static List<dynamic> books = new List<dynamic>();

    public static void Start()
    {
        while (true)
        {
            Console.WriteLine("\n===== Book Library Management =====");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Update Book");
            Console.WriteLine("3. Delete Book");
            Console.WriteLine("4. View All Books");
            Console.WriteLine("5. Search Book by Name");
            Console.WriteLine("6. Search Book by Publisher");
            Console.WriteLine("7. Highest Price Book");
            Console.WriteLine("8. Lowest Price Book");
            Console.WriteLine("9. Exit");
            Console.Write("Enter Choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddBook();
                    break;

                case 2:
                    UpdateBook();
                    break;

                case 3:
                    DeleteBook();
                    break;

                case 4:
                    ViewBooks();
                    break;

                case 5:
                    SearchByName();
                    break;

                case 6:
                    SearchByPublisher();
                    break;

                case 7:
                    HighestPriceBook();
                    break;

                case 8:
                    LowestPriceBook();
                    break;

                case 9:
                    return;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }

    static void AddBook()
    {
        dynamic book = new System.Dynamic.ExpandoObject();

        Console.Write("Book ID: ");
        book.Id = int.Parse(Console.ReadLine());

        Console.Write("Book Name: ");
        book.Name = Console.ReadLine();

        Console.Write("Publisher: ");
        book.Publisher = Console.ReadLine();

        Console.Write("Price: ");
        book.Price = double.Parse(Console.ReadLine());

        books.Add(book);

        Console.WriteLine("Book Added Successfully.");
    }

    static void UpdateBook()
    {
        Console.Write("Enter Book ID: ");
        int id = int.Parse(Console.ReadLine());

        foreach (dynamic book in books)
        {
            if (book.Id == id)
            {
                Console.Write("New Name: ");
                book.Name = Console.ReadLine();

                Console.Write("New Publisher: ");
                book.Publisher = Console.ReadLine();

                Console.Write("New Price: ");
                book.Price = double.Parse(Console.ReadLine());

                Console.WriteLine("Book Updated.");
                return;
            }
        }

        Console.WriteLine("Book Not Found.");
    }

    static void DeleteBook()
    {
        Console.Write("Enter Book ID: ");
        int id = int.Parse(Console.ReadLine());

        for (int i = 0; i < books.Count; i++)
        {
            if (books[i].Id == id)
            {
                books.RemoveAt(i);
                Console.WriteLine("Book Deleted.");
                return;
            }
        }

        Console.WriteLine("Book Not Found.");
    }

    static void ViewBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No Books Available.");
            return;
        }

        foreach (dynamic book in books)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("ID: " + book.Id);
            Console.WriteLine("Name: " + book.Name);
            Console.WriteLine("Publisher: " + book.Publisher);
            Console.WriteLine("Price: " + book.Price);
        }
    }

    static void SearchByName()
    {
        Console.Write("Enter Book Name: ");
        string name = Console.ReadLine();

        bool found = false;

        foreach (dynamic book in books)
        {
            if (book.Name.ToLower().Contains(name.ToLower()))
            {
                Console.WriteLine(book.Id + " " + book.Name + " " + book.Publisher + " " + book.Price);
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("Book Not Found.");
    }

    static void SearchByPublisher()
    {
        Console.Write("Enter Publisher Name: ");
        string publisher = Console.ReadLine();

        bool found = false;

        foreach (dynamic book in books)
        {
            if (book.Publisher.ToLower().Contains(publisher.ToLower()))
            {
                Console.WriteLine(book.Id + " " + book.Name + " " + book.Publisher + " " + book.Price);
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("Book Not Found.");
    }

    static void HighestPriceBook()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No Books Available.");
            return;
        }

        dynamic highest = books[0];

        foreach (dynamic book in books)
        {
            if (book.Price > highest.Price)
            {
                highest = book;
            }
        }

        Console.WriteLine("Highest Price Book:");
        Console.WriteLine(highest.Id + " " + highest.Name + " " + highest.Publisher + " " + highest.Price);
    }

    static void LowestPriceBook()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No Books Available.");
            return;
        }

        dynamic lowest = books[0];

        foreach (dynamic book in books)
        {
            if (book.Price < lowest.Price)
            {
                lowest = book;
            }
        }

        Console.WriteLine("Lowest Price Book:");
        Console.WriteLine(lowest.Id + " " + lowest.Name + " " + lowest.Publisher + " " + lowest.Price);
    }
}