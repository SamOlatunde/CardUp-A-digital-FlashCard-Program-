using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;




namespace Digital_Falshcard_Program
{

    public partial class DigiCards : Form
    {
        
        private List<Flashcard> flashcards = new List<Flashcard>(); //stores flashcards 
        private int currentCardIndex; //stores location of currently showing card 

        // allows us to keep track of which part of
        // flashcard we a re showing, question or answer
        private char currentlyShowing = '\0'; 


        private string title_extractor (string filePath)
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

        public DigiCards()
        {
            InitializeComponent();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a digital flashcard app! Use the buttons to navigate flashcards.");
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            // error handling 
            if (flashcards == null || flashcards.Count == 0)
            {
               MessageBox.Show($"No cards loaded.", "Error",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // update index, show next question, and update
                // currentlyShowing part of card 
                currentCardIndex = (currentCardIndex + 1) % flashcards.Count;
                lblFDisplay.Text = flashcards[currentCardIndex].Question;
                currentlyShowing = 'Q';
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (flashcards == null || flashcards.Count == 0)
            {
                MessageBox.Show($"No cards loaded.", "Error",MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnLoad_Click(object sender, EventArgs e)// actually btn click
        {
            // Logic that allows user to select text files containing flashcards 
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text Files|*.txt";
            dialog.Title = "Select a Flashcard File";

            // file selection is successfully, parse file and begin 
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = dialog.FileName;

                flashcards = FlashCardParser.ParseFile(filePath); //decode the file  and store flashcards in a list 
                currentCardIndex = 0;  //update the index 

                MessageBox.Show($"Loaded {flashcards.Count} flashcards");

                // Display the title of the set of flashcards 
                Title.Font = new Font("Lucida Console", 14);
                Title.TextAlign = ContentAlignment.MiddleCenter;
                Title.Text = title_extractor(filePath);

                // once we've sucessfully loaded the cards, show the first card, update currentlyshowing 
                lblFDisplay.Text = flashcards[currentCardIndex].Question;
                currentlyShowing = 'Q';
            }
        }


        private void btnNext_Load(object sender, EventArgs e)
        {
            lblFDisplay.Font = new Font("Lucida Consle", 14, FontStyle.Bold);

            lblFDisplay.Text = "Welcome to Digital Flashcards! Click the Load " +
                 "button to load your flashcards and kickstart your study session!";

        }

        private void lblFDisplay_Click(object sender, EventArgs e)
        {
            if (flashcards == null || flashcards.Count == 0)
            {
                MessageBox.Show($"No cards loaded.", "Error",MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (flashcards == null || flashcards.Count == 0 )
            {
                MessageBox.Show($"No cards loaded.", "Error",MessageBoxButtons.OK, MessageBoxIcon.Warning);
               
            }
            else 
            {
                currentCardIndex = (currentCardIndex - 1 + flashcards.Count) % flashcards.Count;
                lblFDisplay.Text = flashcards[currentCardIndex].Question;
                currentlyShowing = 'Q';
            }
        }
    }
}
