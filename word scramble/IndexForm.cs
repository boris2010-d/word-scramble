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
        // Списък с думи за текущата категория
        List<string> words = new List<string>();

        // Генератор за случайни числа (за разбъркване)
        Random random = new Random();

        // Текуща дума и разбърканата ѝ версия
        string currentWord = "";
        string scrambledWord = "";

        // Статистики
        int attempts = 0;
        int guessedWords = 0;
        int score = 0;

        // Флаг за тъмен режим
        bool darkMode = false;

        // Речници за оригиналните цветове на контролите
        Dictionary<Control, Color> originalBackColors = new Dictionary<Control, Color>();
        Dictionary<Control, Color> originalForeColors = new Dictionary<Control, Color>();
        Color originalFormBackColor;

        public IndexForm()
        {
            InitializeComponent();

            // Запазваме оригиналния фон на формата
            originalFormBackColor = this.BackColor;

            // Запазваме оригиналните цветове на всички контроли
            foreach (Control c in GetAllControls(this))
            {
                originalBackColors[c] = c.BackColor;
                originalForeColors[c] = c.ForeColor;
            }

            // Зареждаме категориите в ComboBox-а
            comboCategory.DataSource = new string[] { "Animals", "Food", "Cities" };

            // Зареждаме думи и първата разбъркана дума
            LoadCategoryWords();
            LoadNewWord();
        }

        private void LoadCategoryWords()
        {
            // Файл по подразбиране
            string file = "words.txt";

            // Избор на файл според избраната категория
            if (comboCategory.SelectedItem != null)
            {
                if (comboCategory.SelectedItem.ToString() == "Animals")
                    file = "animals.txt";
                else if (comboCategory.SelectedItem.ToString() == "Food")
                    file = "food.txt";
                else if (comboCategory.SelectedItem.ToString() == "Cities")
                    file = "cities.txt";
            }

            // Проверка дали файлът съществува
            if (File.Exists(file))
            {
                // Четем думите, премахваме празни редове и ги правим малки букви
                words = File.ReadAllLines(file)
                             .Where(w => !string.IsNullOrWhiteSpace(w))
                             .Select(w => w.Trim().ToLower())
                             .ToList();
            }
            else
            {
                // Ако файлът липсва → играта няма да крашне
                words = new List<string> { "error" };
            }
        }

        // Разбъркване на дума чрез случайно сортиране
        string Scramble(string word)
        {
            return new string(word.OrderBy(c => random.Next()).ToArray());
        }

        // Зареждане на нова дума
        void LoadNewWord()
        {
            if (words.Count == 0) return;

            currentWord = words[random.Next(words.Count)].Trim().ToLower();
            scrambledWord = Scramble(currentWord);
            labelScrambledWord.Text = scrambledWord;
        }

        // Проверка на въведената дума
        private void buttonCheck_Click(object sender, EventArgs e)
        {
            string guess = textBoxInput.Text.Trim().ToLower();

            // Ако полето е празно → нищо не правим
            if (guess == "")
                return;

            attempts++;
            labelAttemptsCount.Text = attempts.ToString();

            // Ако думата е позната
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
                // Грешен опит
                score -= 5;
                labelScoreCount.Text = score.ToString();

                // Добавяме грешния опит в списъка
                textBoxFailedAttempts.AppendText(guess + Environment.NewLine);
            }
        }

        // Пропускане на дума
        private void buttonSkip_Click(object sender, EventArgs e)
        {
            score -= 2;
            labelScoreCount.Text = score.ToString();

            textBoxInput.Clear();
            LoadNewWord();
        }

        // Превключване на Dark Mode
        private void buttonDarkMode_Click(object sender, EventArgs e)
        {
            darkMode = !darkMode;
            ApplyDarkMode(darkMode);
        }

        // Смяна на категория
        private void comboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCategoryWords();
            LoadNewWord();
        }

        // Приложение на тъмен/светъл режим
        private void ApplyDarkMode(bool enable)
        {
            if (enable)
            {
                // Фон на формата
                this.BackColor = Color.FromArgb(30, 30, 30);

                foreach (Control c in GetAllControls(this))
                {
                    // Етикети
                    if (c is Label)
                    {
                        c.ForeColor = Color.White;

                        // Тези етикети трябва да са прозрачни
                        if (c.Name == "labelAttemptsCount" ||
                            c.Name == "labelGuessedWordsCount" ||
                            c.Name == "labelScoreCount")
                        {
                            c.BackColor = Color.Transparent;
                        }
                    }

                    // Текстови полета
                    if (c is TextBox tb)
                    {
                        tb.BackColor = Color.FromArgb(50, 50, 50);
                        tb.ForeColor = Color.White;
                    }

                    // Бутони
                    if (c is Button btn)
                    {
                        btn.BackColor = Color.FromArgb(70, 70, 70);
                        btn.ForeColor = Color.White;
                    }

                    // Комбо кутия
                    if (c is ComboBox combo)
                    {
                        combo.BackColor = Color.FromArgb(50, 50, 50);
                        combo.ForeColor = Color.White;
                    }
                }
            }
            else
            {
                // Връщане към оригиналните цветове
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

        // Рекурсивно взимане на всички контроли във формата
        private IEnumerable<Control> GetAllControls(Control container)
        {
            foreach (Control c in container.Controls)
            {
                yield return c;

                foreach (Control child in GetAllControls(c))
                    yield return child;
            }
        }
    }
}
