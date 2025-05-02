using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Diary diary = new Diary("diary.txt");
        bool running = true;
        
        while (running)
        {
            Console.WriteLine("\nWelcome to your Digital Diary!");
            Console.WriteLine("1. Write a New Entry");
            Console.WriteLine("2. View All Entries");
            Console.WriteLine("3. Search Entry by Date");
            Console.WriteLine("4. Exit");
            Console.Write("> Select an option: ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    WriteNewEntry(diary);
                    break;
                case "2":
                    ViewAllEntries(diary);
                    break;
                case "3":
                    SearchByDate(diary);
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void WriteNewEntry(Diary diary)
    {
        Console.WriteLine("\nWrite your diary entry (press Enter on an empty line to finish):");
        string entry = "";
        string line;
        
        while (!string.IsNullOrWhiteSpace(line = Console.ReadLine()))
        {
            entry += line + "\n";
        }
        
        if (!string.IsNullOrWhiteSpace(entry))
        {
            diary.WriteEntry(entry.Trim());
            Console.WriteLine(">> Entry saved successfully!");
        }
        else
        {
            Console.WriteLine(">> No content entered. Entry not saved.");
        }
    }

    static void ViewAllEntries(Diary diary)
    {
        Console.WriteLine("\nAll Diary Entries:");
        List<string> entries = diary.ViewAllEntries();
        
        if (entries.Count == 0)
        {
            Console.WriteLine("No entries found.");
        }
        else
        {
            foreach (string line in entries)
            {
                Console.WriteLine(line);
            }
        }
    }

    static void SearchByDate(Diary diary)
    {
        Console.Write("\nEnter date to search (YYYY-MM-DD): ");
        string date = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(date))
        {
            Console.WriteLine("Invalid date format.");
            return;
        }
        
        List<string> results = diary.SearchByDate(date);
        
        if (results.Count == 0)
        {
            Console.WriteLine($"No entries found for {date}.");
        }
        else
        {
            Console.WriteLine($"\nEntries for {date}:");
            foreach (string line in results)
            {
                Console.WriteLine(line);
            }
        }
    }
}