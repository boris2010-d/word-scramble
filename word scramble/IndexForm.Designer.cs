using System.Drawing;
using System.Windows.Forms;

namespace word_scramble
{
    partial class IndexForm
    {
        private System.ComponentModel.IContainer components = null;


        private Label labelTitle;
        private Label labelAttempts;
        private Label labelAttemptsCount;
        private Label labelGuessedWordsCount;
        private Label labelScrambledWord;
        private Label labelFailedAttempts;
        private Label labelGuessedWords;
        private TextBox textBoxInput;
        private TextBox textBoxFailedAttempts;
        private Button buttonCheck;
        private Button buttonSkip;
        private Button buttonDarkMode;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            labelTitle = new Label();
            labelAttempts = new Label();
            labelAttemptsCount = new Label();
            labelGuessedWordsCount = new Label();
            labelScrambledWord = new Label();
            labelFailedAttempts = new Label();
            labelGuessedWords = new Label();
            textBoxInput = new TextBox();
            textBoxFailedAttempts = new TextBox();
            buttonCheck = new Button();
            buttonSkip = new Button();
            buttonDarkMode = new Button();
            labelScore = new Label();
            labelScoreCount = new Label();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.Anchor = AnchorStyles.Top;
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Microsoft Sans Serif", 19.8F, FontStyle.Bold);
            labelTitle.Location = new Point(252, 36);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(255, 38);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Word Scramble";
            // 
            // labelAttempts
            // 
            labelAttempts.AutoSize = true;
            labelAttempts.Location = new Point(67, 116);
            labelAttempts.Name = "labelAttempts";
            labelAttempts.Size = new Size(73, 20);
            labelAttempts.TabIndex = 1;
            labelAttempts.Text = "Attempts:";
            // 
            // labelAttemptsCount
            // 
            labelAttemptsCount.AutoSize = true;
            labelAttemptsCount.Location = new Point(146, 116);
            labelAttemptsCount.Name = "labelAttemptsCount";
            labelAttemptsCount.Size = new Size(17, 20);
            labelAttemptsCount.TabIndex = 2;
            labelAttemptsCount.Text = "0";
            // 
            // labelGuessedWordsCount
            // 
            labelGuessedWordsCount.AutoSize = true;
            labelGuessedWordsCount.Location = new Point(567, 116);
            labelGuessedWordsCount.Name = "labelGuessedWordsCount";
            labelGuessedWordsCount.Size = new Size(17, 20);
            labelGuessedWordsCount.TabIndex = 3;
            labelGuessedWordsCount.Text = "0";
            // 
            // labelScrambledWord
            // 
            labelScrambledWord.AutoSize = true;
            labelScrambledWord.Location = new Point(311, 169);
            labelScrambledWord.Name = "labelScrambledWord";
            labelScrambledWord.Size = new Size(37, 20);
            labelScrambledWord.TabIndex = 4;
            labelScrambledWord.Text = "????";
            // 
            // labelFailedAttempts
            // 
            labelFailedAttempts.AutoSize = true;
            labelFailedAttempts.Location = new Point(311, 251);
            labelFailedAttempts.Name = "labelFailedAttempts";
            labelFailedAttempts.Size = new Size(114, 20);
            labelFailedAttempts.TabIndex = 5;
            labelFailedAttempts.Text = "Failed attempts:";
            // 
            // labelGuessedWords
            // 
            labelGuessedWords.AutoSize = true;
            labelGuessedWords.Location = new Point(450, 116);
            labelGuessedWords.Name = "labelGuessedWords";
            labelGuessedWords.Size = new Size(111, 20);
            labelGuessedWords.TabIndex = 6;
            labelGuessedWords.Text = "Guessed words:";
            // 
            // textBoxInput
            // 
            textBoxInput.Location = new Point(265, 200);
            textBoxInput.Name = "textBoxInput";
            textBoxInput.Size = new Size(125, 27);
            textBoxInput.TabIndex = 1;
            // 
            // textBoxFailedAttempts
            // 
            textBoxFailedAttempts.Location = new Point(265, 274);
            textBoxFailedAttempts.Multiline = true;
            textBoxFailedAttempts.Name = "textBoxFailedAttempts";
            textBoxFailedAttempts.ReadOnly = true;
            textBoxFailedAttempts.Size = new Size(200, 120);
            textBoxFailedAttempts.TabIndex = 7;
            // 
            // buttonCheck
            // 
            buttonCheck.Location = new Point(413, 165);
            buttonCheck.Name = "buttonCheck";
            buttonCheck.Size = new Size(94, 29);
            buttonCheck.TabIndex = 8;
            buttonCheck.Text = "Check";
            buttonCheck.UseVisualStyleBackColor = true;
            buttonCheck.Click += buttonCheck_Click;
            // 
            // buttonSkip
            // 
            buttonSkip.Location = new Point(413, 200);
            buttonSkip.Name = "buttonSkip";
            buttonSkip.Size = new Size(94, 29);
            buttonSkip.TabIndex = 9;
            buttonSkip.Text = "Skip";
            buttonSkip.UseVisualStyleBackColor = true;
            buttonSkip.Click += buttonSkip_Click;
            // 
            // buttonDarkMode
            // 
            buttonDarkMode.Location = new Point(20, 20);
            buttonDarkMode.Name = "buttonDarkMode";
            buttonDarkMode.Size = new Size(120, 30);
            buttonDarkMode.TabIndex = 0;
            buttonDarkMode.Text = "🌙";
            buttonDarkMode.Click += buttonDarkMode_Click;
            // 
            // labelScore
            // 
            labelScore.AutoSize = true;
            labelScore.Location = new Point(67, 169);
            labelScore.Name = "labelScore";
            labelScore.Size = new Size(49, 20);
            labelScore.TabIndex = 10;
            labelScore.Text = "Score:";
            // 
            // labelScoreCount
            // 
            labelScoreCount.AutoSize = true;
            labelScoreCount.Location = new Point(123, 169);
            labelScoreCount.Name = "labelScoreCount";
            labelScoreCount.Size = new Size(17, 20);
            labelScoreCount.TabIndex = 11;
            labelScoreCount.Text = "0";
            // 
            // IndexForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 403);
            Controls.Add(labelScoreCount);
            Controls.Add(labelScore);
            Controls.Add(buttonDarkMode);
            Controls.Add(buttonSkip);
            Controls.Add(buttonCheck);
            Controls.Add(textBoxFailedAttempts);
            Controls.Add(textBoxInput);
            Controls.Add(labelGuessedWords);
            Controls.Add(labelFailedAttempts);
            Controls.Add(labelScrambledWord);
            Controls.Add(labelGuessedWordsCount);
            Controls.Add(labelAttemptsCount);
            Controls.Add(labelAttempts);
            Controls.Add(labelTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "IndexForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Word Scramble";
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private Label labelScore;
        private Label labelScoreCount;
    }
}
