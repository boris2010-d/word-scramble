# Word Scramble Game

A simple Windows Forms application written in **C# (.NET Framework)** where players must guess scrambled words from different categories.

## Features

* 🎮 Word scramble gameplay
* 📂 Multiple categories:

  * Animals
  * Food
  * Cities
* 🎲 Random word selection and scrambling
* 📊 Score tracking
* ✅ Correct and incorrect attempt statistics
* ⏭️ Skip word functionality
* 🌙 Dark Mode support
* 📋 Failed attempts history
* 📄 External word lists stored in text files

---

## How It Works

1. Select a category from the dropdown menu.
2. A scrambled word is displayed.
3. Enter your guess in the text box.
4. Press **Check**:

   * Correct answer → +10 points
   * Wrong answer → -5 points
5. Press **Skip** to load a new word:

   * Skip penalty → -2 points
6. Track your progress through:

   * Total attempts
   * Guessed words
   * Score

---

## Project Structure

```text
word_scramble/
│
├── IndexForm.cs
├── animals.txt
├── food.txt
├── cities.txt
├── words.txt
└── README.md
```

### Text Files

The game loads words from external text files:

* `animals.txt`
* `food.txt`
* `cities.txt`

Each file should contain one word per line.

Example:

```text
dog
cat
elephant
lion
tiger
```

---

## Technologies Used

* C#
* Windows Forms (WinForms)
* .NET Framework
* System.Drawing
* System.IO
* LINQ

---

## Scoring System

| Action         | Points |
| -------------- | ------ |
| Correct answer | +10    |
| Wrong answer   | -5     |
| Skip word      | -2     |

---

## Dark Mode

The application includes a Dark Mode feature that:

* Changes the form background
* Updates button colors
* Updates text box colors
* Adjusts label text colors
* Restores original colors when disabled

---

## Error Handling

If a category file is missing, the application will not crash. Instead, it loads a placeholder word:

```csharp
words = new List<string> { "error" };
```

This ensures the game remains stable even when files are unavailable.

---

## Installation

1. Clone the repository:

```bash
git clone https://github.com/your-username/word-scramble.git
```

2. Open the solution in Visual Studio.

3. Make sure the following files are present in the output directory:

```text
animals.txt
food.txt
cities.txt
```

4. Build and run the project.

---

## Future Improvements

* Add difficulty levels
* Timer mode
* High score system
* Sound effects
* More word categories
* Multiplayer support
* Save statistics between sessions

