using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace word_scramble
{
    public partial class IndexForm : Form
    {
        List<string> words = new List<string>();
        Random random = new Random();

        string currentWord = "";
        string scrambledWord = "";

        int attempts = 0;
        int guessedWords = 0;

        public IndexForm()
        {
            InitializeComponent();



            words = File.ReadAllLines("words.txt")
                         .Where(w => !string.IsNullOrWhiteSpace(w))
                         .Select(w => w.Trim().ToLower())
                         .ToList();




            LoadNewWord();
        }

        string Scramble(string word)
        {
            return new string(word.OrderBy(c => random.Next()).ToArray());
        }


        void LoadNewWord()
        {
            currentWord = words[random.Next(words.Count)].Trim().ToLower();
            scrambledWord = Scramble(currentWord);
            labelScrambledWord.Text = scrambledWord;


        }


        private void buttonCheck_Click(object sender, EventArgs e)
        {
            string guess = textBoxInput.Text.Trim().ToLower();


            if (guess == "")
                return;

            attempts++;
            labelAttemptsCount.Text = attempts.ToString();

            if (guess == currentWord)
            {
                guessedWords++;
                labelGuessedWordsCount.Text = guessedWords.ToString();

                textBoxInput.Clear();
                LoadNewWord();
            }
            else
            {

                textBoxFailedAttempts.AppendText(guess + Environment.NewLine);
            }
        }


        private void buttonSkip_Click(object sender, EventArgs e)
        {
            textBoxInput.Clear();
            LoadNewWord();
        }
    }
}
