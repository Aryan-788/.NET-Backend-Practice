using System;
using System.Collections.Generic;

public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int Marks { get; set; }

    public Student(string name, int age, int marks)
    {
        Name = name;
        Age = age;
        Marks = marks;
    }
}

public class StudentComparer : IComparer<Student>
{
    public int Compare(Student x, Student y)
    {
        int result = y.Marks.CompareTo(x.Marks);

        // 2. If Marks are equal, sort by Youngest Age (Ascending)
        if (result == 0)
        {
            result = x.Age.CompareTo(y.Age);
        }

        return result;
    }
}

class CustomSorting
{
    public static void Start()
    {
        List<Student> students = new List<Student>()
        {
            new Student("Aryan", 20, 85),
            new Student("Rahul", 19, 90),
            new Student("Neha", 18, 90),
            new Student("Priya", 21, 85),
            new Student("Aman", 20, 95)
        };

        // Sort using custom comparer
        students.Sort(new StudentComparer());

        Console.WriteLine("Sorted Students:");

        foreach (Student s in students)
        {
            Console.WriteLine($"{s.Name} - Age: {s.Age}, Marks: {s.Marks}");
        }
    }
}