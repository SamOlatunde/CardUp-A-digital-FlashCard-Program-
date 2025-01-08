# Digital Flashcard Program Documentation

## Overview

The Digital Flashcard Program is a simple Windows Forms application in C# that allows users to study flashcards. Users can load flashcards from a `.txt` file, navigate through them, and toggle between the question and answer of each flashcard. The program includes basic error handling for file loading, empty files, and invalid formats.

## Code Explanation

### Flashcard Class

The `Flashcard` class defines the structure for each flashcard, containing a `Question` and an `Answer`.

```csharp
public class Flashcard
{
    public string Question { get; set; }  // The question on the flashcard
    public string Answer { get; set; }    // The answer to the flashcard's question
}


### FlashCardParser Class

The `FlashCardParser` class is responsible for reading and parsing the flashcard file. It processes each line of the file, expecting the format `Question|Answer`. It returns a list of `Flashcard` objects.

#### Method: `ParseFile`

```csharp
public static List<Flashcard> ParseFile(string filePath)
{
    List<Flashcard> flashcards = new List<Flashcard>();
    string[] lines = File.ReadAllLines(filePath);

    if (lines.Length == 0)
    {
        MessageBox.Show("The file is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return flashcards;
    }

    List<string> invalidLines = new List<string>();

    foreach (var line in lines)
    {
        string[] parts = line.Trim().Split('|');
        if (parts.Length == 2)
        {
            flashcards.Add(new Flashcard { Question = parts[0], Answer = parts[1] });
        }
        else
        {
            invalidLines.Add(line);
        }
    }

    if (invalidLines.Any())
    {
        MessageBox.Show($"Skipped {invalidLines.Count} invalid lines.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
    return flashcards;
}
```

### DigiCards Form Class

The `DigiCards` class is the main form of the application. It handles the user interface and user interactions, such as loading flashcards, navigating through them, and displaying the current card.

#### Key Components

- **flashcards**: A list to store the flashcards loaded from a file.
- **currentCardIndex**: An integer to track the index of the current flashcard being displayed.
- **currentlyShowing**: A character used to track whether the current flashcard shows the question (`'Q'`) or answer (`'A'`).

#### Method: `title_extractor`

```csharp
private string title_extractor(string filePath)
{
    string fileName = Path.GetFileNameWithoutExtension(filePath);
    string[] title_parts = fileName.Split('_');
    string complete_title = "";

    for (int i = 0; i < title_parts.Count(); i++)
    {
        complete_title += title_parts[i] + " ";
    }

    return complete_title;
}
```

This method extracts and returns the title of the flashcard set based on the filename (e.g., "Math_Flashcards.txt" becomes "Math Flashcards").

#### Method: `btnHelp_Click`

```csharp
private void btnHelp_Click(object sender, EventArgs e)
{
    MessageBox.Show("This is a digital flashcard app! Use the buttons to navigate flashcards.");
}
```

This method displays a help message explaining how to use the flashcard program.

#### Method: `btnNext_Click`

```csharp
private void btnNext_Click(object sender, EventArgs e)
{
    if (flashcards == null || flashcards.Count == 0)
    {
        MessageBox.Show($"No cards loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
    else
    {
        currentCardIndex = (currentCardIndex + 1) % flashcards.Count;
        lblFDisplay.Text = flashcards[currentCardIndex].Question;
        currentlyShowing = 'Q';
    }
}
```

This method displays the next flashcard and updates the `currentCardIndex`. If no cards are loaded, an error message is displayed.

#### Method: `btnShow_Click`

```csharp
private void btnShow_Click(object sender, EventArgs e)
{
    if (flashcards == null || flashcards.Count == 0)
    {
        MessageBox.Show($"No cards loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
    else
    {
        switch (currentlyShowing)
        {
            case 'Q':
                lblFDisplay.Text = flashcards[currentCardIndex].Answer;
                currentlyShowing = 'A';
                break;
            case 'A':
                lblFDisplay.Text = flashcards[currentCardIndex].Question;
                currentlyShowing = 'Q';
                break;
        }
    }
}
```

This method toggles between displaying the question and the answer of the current flashcard.

#### Method: `btnLoad_Click`

```csharp
private void btnLoad_Click(object sender, EventArgs e)
{
    OpenFileDialog dialog = new OpenFileDialog();
    dialog.Filter = "Text Files|*.txt";
    dialog.Title = "Select a Flashcard File";

    if (dialog.ShowDialog() == DialogResult.OK)
    {
        string filePath = dialog.FileName;
        flashcards = FlashCardParser.ParseFile(filePath); // Decode the file and store flashcards in a list
        currentCardIndex = 0;

        MessageBox.Show($"Loaded {flashcards.Count} flashcards");

        Title.TextAlign = ContentAlignment.MiddleCenter;
        Title.Text = title_extractor(filePath);

        lblFDisplay.Text = flashcards[currentCardIndex].Question;
        currentlyShowing = 'Q';
    }
}
```

This method opens a file dialog for the user to select a flashcard file. After loading the file, it parses the flashcards and updates the display.

#### Method: `btnNext_Load`

```csharp
private void btnNext_Load(object sender, EventArgs e)
{
    lblFDisplay.Text = "Welcome to Digital Flashcards! Click the Load " +
         "button to load your flashcards and kickstart your study session!";
}
```

This method sets an initial welcome message when the program starts.

#### Method: `lblFDisplay_Click`

```csharp
private void lblFDisplay_Click(object sender, EventArgs e)
{
    if (flashcards == null || flashcards.Count == 0)
    {
        MessageBox.Show($"No cards loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
    else
    {
        switch (currentlyShowing)
        {
            case 'Q':
                lblFDisplay.Text = flashcards[currentCardIndex].Answer;
                currentlyShowing = 'A';
                break;
            case 'A':
                lblFDisplay.Text = flashcards[currentCardIndex].Question;
                currentlyShowing = 'Q';
                break;
        }
    }
}
```

This method is triggered when the user clicks on the flashcard label. It toggles between displaying the question and answer.

#### Method: `btnPrev_Click`

```csharp
private void btnPrev_Click(object sender, EventArgs e)
{
    if (flashcards == null || flashcards.Count == 0)
    {
        MessageBox.Show($"No cards loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
    else
    {
        currentCardIndex = (currentCardIndex - 1 + flashcards.Count) % flashcards.Count;
        lblFDisplay.Text = flashcards[currentCardIndex].Question;
        currentlyShowing = 'Q';
    }
}
```

This method displays the previous flashcard by updating the `currentCardIndex` and toggles back to the question.

---

## Error Handling

- **No Cards Loaded**: If there are no flashcards loaded, the user will receive a warning when attempting to navigate through the cards or toggle the question/answer.
- **Invalid Flashcard Format**: Lines in the `.txt` file that do not follow the `Question|Answer` format are skipped, and a warning is shown.

---

## Example Usage

1. **Prepare a `.txt` file** with flashcards in the following format:
   ```
   What is the capital of France?|Paris
   Who wrote "1984"?|George Orwell
   ```

2. **Run the program** and click the **Load** button to select the flashcard file.
3. **Navigate through flashcards** using the **Next** and **Previous** buttons.
4. **Toggle between question and answer** by clicking the flashcard label.
5. **Get helpful messages** when there are issues like no cards loaded or invalid format.

---
