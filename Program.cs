using System;
using System.Collections.Generic;

public static class AnsiCodes
{
    public const string Bold = "\x1b[1m";
    public const string Dim = "\x1b[2m";
    public const string Reset = "\x1b[0m";
}

class Program
{
    static void WriteWithColor(string text, ConsoleColor color)
    {
        ConsoleColor originalColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ForegroundColor = originalColor;
    }
    static void Main(string[] args)
    {
        Diary diary = new Diary("diary.txt");
        bool running = true;
        
        while (running)
        {        
            Console.WriteLine($"\n---------------------------------------------------------------------\n");    
            Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");

            WriteWithColor("Dear, ", ConsoleColor.Yellow); 
            WriteWithColor($"{AnsiCodes.Bold}Diary{AnsiCodes.Reset}", ConsoleColor.Yellow); 
            WriteWithColor("!\n", ConsoleColor.Yellow); 

            Console.WriteLine("\n1. Write a New Entry");
            Console.WriteLine("2. View All Entries");
            Console.WriteLine("3. Search Entry by Date");
            Console.WriteLine("4. Exit");
            WriteWithColor($"{AnsiCodes.Bold}\n> {AnsiCodes.Reset}", ConsoleColor.Cyan);
            Console.Write($"Select an option {AnsiCodes.Bold}(1-4){AnsiCodes.Reset}: ");
            
            string choice = Console.ReadLine();
            
            if (string.IsNullOrEmpty(choice))
            {
                running = false;
                continue;
            }
            
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
                    WriteWithColor($"{AnsiCodes.Bold}\t>> {AnsiCodes.Reset}", ConsoleColor.Cyan);
                    Console.Write($"{AnsiCodes.Bold}Invalid option.{AnsiCodes.Reset} Please try again.\n");
                    break;
            }
        }
    }

    static void WriteNewEntry(Diary diary)
    {
        Console.WriteLine($"\n---------------------------------------------------------------------\n");
        WriteWithColor($"{AnsiCodes.Bold}\t\t\tWrite a New Entry{AnsiCodes.Reset}", ConsoleColor.Yellow);
        Console.WriteLine("\n\t(press Enter twice to save, or just Enter to cancel)");
        Console.WriteLine();
        string entry = "";
        string line;
        int emptyLines = 0;
        
        while (true)
        {
            line = Console.ReadLine();
            
            if (string.IsNullOrEmpty(line) && entry.Length == 0)
            {
                WriteWithColor($"{AnsiCodes.Bold}\t>> {AnsiCodes.Reset}", ConsoleColor.Cyan);
                Console.Write("Your diary entry has been canceled.\n");
                return;
            }
            
            if (string.IsNullOrEmpty(line))
            {
                emptyLines++;
                if (emptyLines >= 2)
                {
                    break;
                }
            }
            else
            {
                emptyLines = 0;
            }
            
            entry += line + "\n";
        }
        
        if (!string.IsNullOrWhiteSpace(entry))
        {
            diary.WriteEntry(entry.Trim());
            WriteWithColor($"{AnsiCodes.Bold}\t>> {AnsiCodes.Reset}", ConsoleColor.Cyan);
            Console.Write("Your diary entry has been saved successfully!\n");
        }
        else
        {
            WriteWithColor($"{AnsiCodes.Bold}\t>> {AnsiCodes.Reset}", ConsoleColor.Cyan);
            Console.Write($"No content entered. {AnsiCodes.Bold}Your diary entry was not saved{AnsiCodes.Reset}.\n");
        }
    }

    static void ViewAllEntries(Diary diary)
    {
        Console.WriteLine($"\n---------------------------------------------------------------------");
        WriteWithColor($"{AnsiCodes.Bold}\n\t\t\tAll Diary Entries{AnsiCodes.Reset}", ConsoleColor.Yellow);
        Console.WriteLine("\n\t\t(press Enter to return to the menu)\n");
        
        List<string> entries = diary.ViewAllEntries();
        
        if (entries.Count == 0)
        {
            WriteWithColor($"{AnsiCodes.Bold}\t>> {AnsiCodes.Reset}", ConsoleColor.Cyan);
            Console.Write("No entries found—yet.\n");
        }
        else
        {
            foreach (string line in entries)
            {
                if (line.StartsWith("[") && line.Contains("-") && line.Contains("]"))
                {
                    WriteWithColor(line + "\n", ConsoleColor.Magenta);
                }
                else
                {
                    Console.WriteLine(line);
                }
            }
        }

        while (true)
        {
            WriteWithColor($"{AnsiCodes.Bold}> {AnsiCodes.Reset}", ConsoleColor.Cyan);
            Console.Write($"Would you like to return to the main menu? {AnsiCodes.Bold}(Y/N){AnsiCodes.Reset}: ");
            string response = Console.ReadLine()?.Trim().ToUpper();

            if (response == "Y" || string.IsNullOrEmpty(response))
            {
                break;
            }
            else if (response == "N")
            {
                WriteWithColor($"{AnsiCodes.Bold}> {AnsiCodes.Reset}", ConsoleColor.Cyan);
                Console.Write("Press any key to continue browsing entries... ");
                Console.ReadKey();
                Console.WriteLine();
                ViewAllEntries(diary);
                break;
            }
            else
            {
                WriteWithColor($"{AnsiCodes.Bold}\t>> {AnsiCodes.Reset}", ConsoleColor.Cyan);
                Console.Write($"{AnsiCodes.Bold}Invalid input.{AnsiCodes.Reset} Please enter Y or N.\n");
            }
        }
    }

    static void SearchByDate(Diary diary)
    {
        Console.WriteLine($"\n---------------------------------------------------------------------");
        WriteWithColor($"{AnsiCodes.Bold}\n\t\t\tSearch Entry by Date{AnsiCodes.Reset}", ConsoleColor.Yellow);
        WriteWithColor($"{AnsiCodes.Bold}\n\n> {AnsiCodes.Reset}", ConsoleColor.Cyan);
        Console.Write($"Enter date to search {AnsiCodes.Bold}(YYYY-MM-DD){AnsiCodes.Reset} or press Enter to cancel: ");
        string date = Console.ReadLine();
        
        if (string.IsNullOrEmpty(date))
        {
            WriteWithColor($"{AnsiCodes.Bold}\t>> {AnsiCodes.Reset}", ConsoleColor.Cyan);
            Console.Write("Search canceled.\n");
            return;
        }
        
        List<string> results = diary.SearchByDate(date);
        
        if (results.Count == 0)
        {
            WriteWithColor($"{AnsiCodes.Bold}\t>> {AnsiCodes.Reset}", ConsoleColor.Cyan);
            Console.Write($"No entries found for {AnsiCodes.Bold}{date}{AnsiCodes.Reset}.\n");
        }
        else
        {   
            WriteWithColor($"{AnsiCodes.Bold}> {AnsiCodes.Reset}", ConsoleColor.Cyan);
            Console.Write("Showing entries for ");
            WriteWithColor($"{AnsiCodes.Bold}{date}{AnsiCodes.Reset}:\n\n", ConsoleColor.Magenta);
            foreach (string line in results)
            {
                if (line.StartsWith("[") && line.Contains("-") && line.Contains("]"))
                {
                    WriteWithColor(line + "\n", ConsoleColor.Magenta);
                }
                else
                {
                    Console.WriteLine(line);
                }
            }
        }
        
        while (true)
        {
            WriteWithColor($"{AnsiCodes.Bold}> {AnsiCodes.Reset}", ConsoleColor.Cyan);
            Console.Write($"Would you like to return to the main menu? {AnsiCodes.Bold}(Y/N){AnsiCodes.Reset}: ");
            string response = Console.ReadLine()?.Trim().ToUpper();

            if (response == "Y" || string.IsNullOrEmpty(response))
            {
                break;
            }
            else if (response == "N")
            {
                WriteWithColor($"{AnsiCodes.Bold}> {AnsiCodes.Reset}", ConsoleColor.Cyan);
                Console.Write("Press any key to search for other entries... ");
                Console.ReadKey();
                Console.WriteLine();
                SearchByDate(diary);
                break;
            }
            else
            {
                WriteWithColor($"{AnsiCodes.Bold}\t>> {AnsiCodes.Reset}", ConsoleColor.Cyan);
                Console.Write($"{AnsiCodes.Bold}Invalid input.{AnsiCodes.Reset} Please enter Y or N.\n");
            }
        }
    }
}