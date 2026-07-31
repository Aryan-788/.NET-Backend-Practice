using System;
using System.Collections.Generic;
using System.Text.Json;
class Student
{
    public string Name {get; set;}
    public int Score {get; set;}

    public Student(string name, int score)
    {
        Name = name;
        Score = score;
    }

}
class StringFormat
{
    public static string GetStudentsJson(string[] items, int minScore)
    {
        List<Student> students = new List<Student>();

        foreach(string item in items)
        {
            string[] parts = item.Split(':');

            if(parts.Length == 2 && int.TryParse(parts[1], out int score))
            {
                students.Add(new Student(parts[0], score));
            }
        }

        var result = students.Where(s => s.Score >= minScore).OrderByDescending(s => s.Score).ThenBy(s => s.Name).ToList();

        return JsonSerializer.Serialize(result);
    }

    public static void Start()
    {
        int n = int.Parse(Console.ReadLine());

        string[] items = new string[n];

        for(int i=0; i<n; i++)
        {
            items[i] = Console.ReadLine();

        }

        int minScore = int.Parse(Console.ReadLine());

        string json = GetStudentsJson(items, minScore);

        Console.WriteLine(json);
    }
}