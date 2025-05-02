using System;
using System.IO;
using System.Collections.Generic;

public class Diary
{
    private string filePath;

    public Diary(string path)
    {
        filePath = path;
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
        }
    }

    public void WriteEntry(string text)
    {
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        using (StreamWriter writer = File.AppendText(filePath))
        {
            writer.WriteLine($"[{timestamp}]");
            writer.WriteLine(text);
            writer.WriteLine();
        }
    }

    public List<string> ViewAllEntries()
    {
        List<string> entries = new List<string>();
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            entries.AddRange(lines);
        }
        return entries;
    }

    public List<string> SearchByDate(string date)
    {
        List<string> results = new List<string>();
        if (!File.Exists(filePath)) return results;

        string[] allLines = File.ReadAllLines(filePath);
        bool insideMatchingEntry = false;

        for (int i = 0; i < allLines.Length; i++)
        {
            if (allLines[i].StartsWith($"[{date}") || 
                allLines[i].StartsWith($"[{date.Split(' ')[0]}"))
            {
                insideMatchingEntry = true;
                results.Add(allLines[i]);

                i++;
                while (i < allLines.Length && !allLines[i].StartsWith("["))
                {
                    if (!string.IsNullOrWhiteSpace(allLines[i]))
                    {
                        results.Add(allLines[i]);
                    }
                    else if (i + 1 < allLines.Length && !allLines[i + 1].StartsWith("["))
                    {
                        results.Add(allLines[i]);
                    }
                    i++;
                }
                results.Add("");
                if (i < allLines.Length) i--;
            }
        }

        return results;
    }
}