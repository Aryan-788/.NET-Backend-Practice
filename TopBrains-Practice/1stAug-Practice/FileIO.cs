using System;
using System.IO;

public class FileIO
{
    public static void Start()
    {
        string inputFile = "log.txt";
        string outputFile = "error.txt";

        if (File.Exists(inputFile))
        {
            string[] lines = File.ReadAllLines(inputFile);

            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                foreach (string line in lines)
                {
                    if (line.Contains("ERROR"))
                    {
                        writer.WriteLine(line);
                    }
                }
            }

            Console.WriteLine("ERROR logs extracted successfully.");
        }
        else
        {
            Console.WriteLine("log.txt not found.");
        }
    }
}