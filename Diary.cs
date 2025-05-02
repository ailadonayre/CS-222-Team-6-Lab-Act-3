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
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            bool found = false;
            
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith($"[{date}") || found)
                {
                    found = true;
                    results.Add(lines[i]);
                    
                    i++;
                    while (i < lines.Length && !string.IsNullOrWhiteSpace(lines[i]) 
                           && !lines[i].StartsWith("["))
                    {
                        results.Add(lines[i]);
                        i++;
                    }
                    found = false;
                    if (i < lines.Length) results.Add("");
                }
            }
        }
        return results;
    }
}