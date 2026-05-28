using System;
using System.Collections.Generic;
using System.Drawing;
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
        int score = 0;

        bool darkMode = false;

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

                score += 10;
                labelScoreCount.Text = score.ToString();

                textBoxInput.Clear();
                LoadNewWord();
            }
            else
            {
                score -= 5;
                labelScoreCount.Text = score.ToString();

                textBoxFailedAttempts.AppendText(guess + Environment.NewLine);
            }
        }

        private void buttonSkip_Click(object sender, EventArgs e)
        {
            score -= 2;
            labelScoreCount.Text = score.ToString();

            textBoxInput.Clear();
            LoadNewWord();
        }

        private void buttonDarkMode_Click(object sender, EventArgs e)
        {
            darkMode = !darkMode;
            ApplyDarkMode(darkMode);
        }

        private void ApplyDarkMode(bool enable)
        {
            if (enable)
            {
                this.BackColor = Color.FromArgb(30, 30, 30);

                foreach (Control c in this.Controls)
                {
                    if (c is Label)
                        c.ForeColor = Color.White;

                    if (c is TextBox tb)
                    {
                        tb.BackColor = Color.FromArgb(50, 50, 50);
                        tb.ForeColor = Color.White;
                    }

                    if (c is Button btn)
                    {
                        btn.BackColor = Color.FromArgb(70, 70, 70);
                        btn.ForeColor = Color.White;
                    }
                }
            }
            else
            {
                this.BackColor = SystemColors.Control;

                foreach (Control c in this.Controls)
                {
                    if (c is Label)
                        c.ForeColor = Color.Black;

                    if (c is TextBox tb)
                    {
                        tb.BackColor = Color.White;
                        tb.ForeColor = Color.Black;
                    }

                    if (c is Button btn)
                    {
                        btn.BackColor = SystemColors.Control;
                        btn.ForeColor = Color.Black;
                    }
                }
            }
        }
    }
}
