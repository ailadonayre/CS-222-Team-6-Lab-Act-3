<p align="center">
  <img src="images/logo1.png" width="600" height="400" alt="DigitalDiary"> 
</p>

## 🌟 About the Project
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

### Encapsulation
- The file path and logic for writing, viewing, and searching diary entries are hidden within the `Diary` class.
- Only specific methods (`WriteEntry`, `ViewAllEntries`, `SearchByDate`) are exposed to interact with the diary file.

### Abstraction
- Users of the `Diary` class interact only through high-level methods, without needing to understand file handling logic like `StreamWriter` or `File.Exists`.

*(Optional for extension: Inheritance and Polymorphism could be used to create versions of the diary with password protection or tagging.)*

## <a id="inst">⚙️ Instructions to Run the App</a>
1. Clone the repository from GitHub.
2. Open the project using Visual Studio.
3. Ensure `Program.cs` and `Diary.cs` are inside the project folder.
4. Build and run the application.
5. Follow the console menu to use the diary.

## <a id="struct">📁 File Structure</a>
```
├── main/
│   ├── Program.cs       # Handles the menu and user interaction
│   ├── Diary.cs         # Contains the Diary class with file handling logic
│   └── diary.txt        # (Auto-created) File where diary entries are stored
├── README.md
```

## <a id="output">🛠️ Sample Output</a>
```
=== DIGITAL DIARY ===
1. Write a New Entry
2. View All Entries
3. Search Entry by Date
4. Exit
Choose an option: 1

Write your diary entry (press Enter to submit): Had a productive day learning C# file handling.
Entry successfully written.

Press any key to return to menu...
```

_Search by date example:_
```
Enter date to search (YYYY-MM-DD): 2025-05-01
---- Entries on 2025-05-01 ----
2025-05-01 18:43:12 | Had a productive day learning C# file handling.
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
