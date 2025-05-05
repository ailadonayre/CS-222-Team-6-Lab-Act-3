<p align="center">
  <img src="images/Digital Diary Main Banner.jpg" style="max-width: 600px; height: auto;" alt="DigitalDiary">
</p>

## 🌟 About
**Digital Diary** is a simple, modular, console-based C# application designed to let users write, view, and search diary entries. Using file handling techniques, all entries are stored persistently in a text file. The project showcases core object-oriented programming (OOP) principles, particularly encapsulation and abstraction, in a practical and beginner-friendly manner.

## 📔 Table of Contents
-  [1. Program Features](#proj-feat)
-  [2. OOP principles used](#OOP)
-  [3. Instructions on running the app](#inst)
-  [4. File Structure](#struct)
-  [5. Sample Output](#output)
-  [6. Members](#member) 
-  [7. Acknowledgement](#ack) 

## <a id="proj-feat">🎯 Program Features</a>
- Write and save new diary entries with timestamps
- View all saved diary entries
- Search for entries by specific date (`YYYY-MM-DD`)
- Clean console-based UI with an interactive menu

## <a id="OOP">⚖️ OOP Principles Used</a>

  ###🔐 Encapsulation
  Encapsulation is the bundling of data and methods within a class, and restricting direct access to the class’s internal components.


 ###✅ In This Project:
  The Diary class encapsulates the file handling logic. The internal data (filePath) is declared as private, and access is only provided through public methods. This hides   the implementation details and protects the internal state.


  📁 Code Reference:

```
  private string filePath;

  public Diary(string path)
  {
    filePath = path;
    if (!File.Exists(filePath))
    {
        File.Create(filePath).Close();
    }
  }
```

  Only methods like WriteEntry, ViewAllEntries, and SearchByDate can access or modify the file. External classes cannot access filePath directly, enforcing encapsulation.



  ###🧩 Abstraction
  Abstraction allows a class to expose only essential behaviors while hiding implementation complexity.


  ✅ In This Project:
  The Diary class abstracts file operations like writing and reading by providing easy-to-use methods. The main program doesn’t need to know anything about StreamWriter,     file creation, or line-by-line parsing.


  ###📁 Code Reference:
  
```
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
```

  Users simply call WriteEntry("Today was a good day"), and the file-handling logic is hidden from them.

  *(Optional for extension: Inheritance and Polymorphism could be used to create versions of the diary with password protection or tagging.)*


  ###🧬 Inheritance
  Inheritance allows new classes to reuse and extend the functionality of existing classes.


  ###🔒 PasswordProtectedDiary – Inheritance
  You can create a child class of Diary that includes password protection. This way, all existing functionality is inherited, and you can add access control logic on top.

```
  public class PasswordProtectedDiary : Diary
  {
      private string password;

      public PasswordProtectedDiary(string path, string password) : base(path)
      {
          this.password = password;
      }

      public bool Authenticate(string inputPassword)
      {
          return inputPassword == password;
      }

      // You could override WriteEntry or ViewAllEntries to enforce authentication
  }
```

  ###🧠 Explanation:
  This demonstrates inheritance (extending Diary) and could also allow method overriding for protected access to entries.


  ###🔁 Polymorphism 
  Polymorphism allows objects to take on multiple forms depending on context, typically using method overriding or interfaces.


  ###🏷️ TaggedDiary – Polymorphism
  You could use polymorphism to extend or overload diary methods to include tags or categories per entry.

```
  public class TaggedDiary : Diary
  {
      public TaggedDiary(string path) : base(path) {}

      public void WriteEntry(string text, string tag)
      {
          string taggedText = $"#{tag}\n{text}";
          base.WriteEntry(taggedText);
      }
  }
```

  ###🧠 Explanation:
  This demonstrates polymorphism via method overloading—same method name (WriteEntry), but different parameters.


## <a id="inst">⚙️ Instructions to Run the App</a>
1. Clone the repository from GitHub.
2. Open the project using Visual Studio.
3. Ensure `Program.cs` and `Diary.cs` are inside the project folder.
4. Build and run the application.
5. Follow the console menu to use the diary.

## <a id="struct">📁 File Structure</a>
```
├── bin/Debug/net9.0
│   └── diary.txt       # (Auto-created) File where diary entries are stored
├── images              # Contains the images used for the README file
├── obj
├── Diary.cs            # Contains the Diary class with file handling logic
├── Program.cs          # Handles the menu and user interaction
├── README.md
```

## <a id="output">🛠️ Sample Output</a>
```
---------------------------------------------------------------------

2025-05-03 01:30:34
Dear, Diary!

1. Write a New Entry
2. View All Entries
3. Search Entry by Date
4. Exit

> Select an option (1-4):
```

**Write a New Entry:**
```
---------------------------------------------------------------------

                        Write a New Entry
        (press Enter twice to save, or just Enter to cancel)

Dear, Diary:

Today, I went to the mall with my sister. When I got back home, I   
walked my dog, Milly, and strolled down the park. I came back home
and ate dinner with my family afterwards.


        >> Your diary entry has been saved successfully!

---------------------------------------------------------------------
```

**View All Entries:**
```
----------------------------------------------------------------------

                        All Diary Entries
                (press Enter to return to the menu)

[2025-04-28 06:16:22]
Hahahahhhahah dear diary bwahahah

[2025-04-28 06:17:09]
Dear diary blah blah balh

[2025-05-02 23:22:28]
Dear, Diary:
Hahaha wala lang bye

xo, Aila

[2025-05-02 23:36:16]
dddddd

[2025-05-02 23:40:02]
ggggggggggggggggggggggg

[2025-05-02 23:41:23]
jejeejjejeje

[2025-05-03 00:31:29]
Hi, good morning!

[2025-05-03 01:32:48]
Dear, Diary:

Today, I went to the mall with my sister. When I got back home, I
walked my dog, Milly, and strolled down the park. I came back home
and ate dinner with my family afterwards.

> Would you like to return to the main menu? (Y/N):
```

**Search Entry by Date:**
```
----------------------------------------------------------------------

                        Search Entry by Date

> Enter date to search (YYYY-MM-DD) or press Enter to cancel: 2025-05-03
> Showing entries for 2025-05-03:

[2025-05-03 00:31:29]
Hi, good morning!

[2025-05-03 01:32:48]
Dear, Diary:

Today, I went to the mall with my sister. When I got back home, I
walked my dog, Milly, and strolled down the park. I came back home
and ate dinner with my family afterwards.

> Would you like to return to the main menu? (Y/N): 
```

## <a id="member">👥 Group Members</a>
| Name | SR-Code | 
|------|---------|
| [Calog, Chester King](https://github.com/ChesterCalog) | 23-09045 |   
| [Donayre, Aila Roshiele](https://github.com/ailaroshiele) | 23-02175 |  
| [Villanueva, Daniel](https://github.com/danielbvillanueva) | 23-01037 | 
| [Tarcelo, Mark Niño](https://github.com/ElgatoMe0w) | 20-08675 | 

## <a id="ack">💎 Acknowledgements</a>
Special thanks to our instructor for guiding us in learning C# file handling and OOP. This activity helped us apply classroom concepts to a real-world style application.
