using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digital_Falshcard_Program
{
    public class Flashcard // datatype to hold flashcard data 
    {
        public string Question { get; set; }
        public string Answer { get; set; }

    }
    public class FlashCardParser
    {
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
    }
}
