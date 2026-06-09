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

        // Речници за оригиналните цветове
        Dictionary<Control, Color> originalBackColors = new Dictionary<Control, Color>();
        Dictionary<Control, Color> originalForeColors = new Dictionary<Control, Color>();
        Color originalFormBackColor;

        public IndexForm()
        {
            InitializeComponent();

            originalFormBackColor = this.BackColor;

            // Записваме оригиналните цветове веднага при стартиране
            foreach (Control c in GetAllControls(this))
            {
                originalBackColors[c] = c.BackColor;
                originalForeColors[c] = c.ForeColor;
            }

            if (File.Exists("words.txt"))
            {
                words = File.ReadAllLines("words.txt")
                             .Where(w => !string.IsNullOrWhiteSpace(w))
                             .Select(w => w.Trim().ToLower())
                             .ToList();
            }

            if (words.Count > 0)
            {
                LoadNewWord();
            }
        }

        string Scramble(string word)
        {
            return new string(word.OrderBy(c => random.Next()).ToArray());
        }

        void LoadNewWord()
        {
            if (words.Count == 0) return;
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

                foreach (Control c in GetAllControls(this))
                {
                    if (c is Label)
                    {
                        c.ForeColor = Color.White;

                        // Директно хващаме трите кутийки с числата по име и им махаме кубичния фон
                        if (c.Name == "labelAttemptsCount" ||
                            c.Name == "labelGuessedWordsCount" ||
                            c.Name == "labelScoreCount")
                        {
                            c.BackColor = Color.Transparent;
                        }
                    }

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
                this.BackColor = originalFormBackColor;

                foreach (Control c in GetAllControls(this))
                {
                    if (originalBackColors.TryGetValue(c, out Color backColor))
                        c.BackColor = backColor;

                    if (originalForeColors.TryGetValue(c, out Color foreColor))
                        c.ForeColor = foreColor;
                }
            }
        }

        private IEnumerable<Control> GetAllControls(Control container)
        {
            foreach (Control c in container.Controls)
            {
                yield return c;
                foreach (Control child in GetAllControls(c))
                {
                    yield return child;
                }
            }
        }
    }
}