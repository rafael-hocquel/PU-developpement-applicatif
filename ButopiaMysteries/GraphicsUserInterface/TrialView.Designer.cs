namespace ButopiaMysteries.GraphicsUserInterface
{
    partial class TrialView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            trialNameLabel = new Label();
            trialSkillLabel = new Label();
            trialIndicatorLabel = new Label();
            trialSkillLevelLabel = new Label();
            trialIndicatorLevelLabel = new Label();
            trialDifficultyLabel = new Label();
            trialStartButton = new Button();
            trialCloseButton = new Button();
            numberOfTrials = new Label();
            numericUDNumberOfTrial = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUDNumberOfTrial).BeginInit();
            SuspendLayout();
            // 
            // trialNameLabel
            // 
            trialNameLabel.AutoSize = true;
            trialNameLabel.Location = new Point(33, 81);
            trialNameLabel.Name = "trialNameLabel";
            trialNameLabel.Size = new Size(67, 15);
            trialNameLabel.TabIndex = 0;
            trialNameLabel.Text = "NameLabel";
            // 
            // trialSkillLabel
            // 
            trialSkillLabel.AutoSize = true;
            trialSkillLabel.Location = new Point(33, 118);
            trialSkillLabel.Name = "trialSkillLabel";
            trialSkillLabel.Size = new Size(56, 15);
            trialSkillLabel.TabIndex = 1;
            trialSkillLabel.Text = "SkillLabel";
            // 
            // trialIndicatorLabel
            // 
            trialIndicatorLabel.AutoSize = true;
            trialIndicatorLabel.Location = new Point(33, 157);
            trialIndicatorLabel.Name = "trialIndicatorLabel";
            trialIndicatorLabel.Size = new Size(82, 15);
            trialIndicatorLabel.TabIndex = 2;
            trialIndicatorLabel.Text = "IndicatorLabel";
            // 
            // trialSkillLevelLabel
            // 
            trialSkillLevelLabel.AutoSize = true;
            trialSkillLevelLabel.Location = new Point(112, 118);
            trialSkillLevelLabel.Name = "trialSkillLevelLabel";
            trialSkillLevelLabel.Size = new Size(83, 15);
            trialSkillLevelLabel.TabIndex = 3;
            trialSkillLevelLabel.Text = "SkillLevelLabel";
            // 
            // trialIndicatorLevelLabel
            // 
            trialIndicatorLevelLabel.AutoSize = true;
            trialIndicatorLevelLabel.Location = new Point(131, 157);
            trialIndicatorLevelLabel.Name = "trialIndicatorLevelLabel";
            trialIndicatorLevelLabel.Size = new Size(109, 15);
            trialIndicatorLevelLabel.TabIndex = 4;
            trialIndicatorLevelLabel.Text = "IndicatorLevelLabel";
            // 
            // trialDifficultyLabel
            // 
            trialDifficultyLabel.AutoSize = true;
            trialDifficultyLabel.Location = new Point(33, 309);
            trialDifficultyLabel.Name = "trialDifficultyLabel";
            trialDifficultyLabel.Size = new Size(83, 15);
            trialDifficultyLabel.TabIndex = 5;
            trialDifficultyLabel.Text = "DifficultyLabel";
            // 
            // trialStartButton
            // 
            trialStartButton.Location = new Point(474, 241);
            trialStartButton.Name = "trialStartButton";
            trialStartButton.Size = new Size(75, 23);
            trialStartButton.TabIndex = 7;
            trialStartButton.Text = "Start";
            trialStartButton.UseVisualStyleBackColor = true;
            trialStartButton.Click += TrialStartButton_Click;
            // 
            // trialCloseButton
            // 
            trialCloseButton.DialogResult = DialogResult.Cancel;
            trialCloseButton.Location = new Point(474, 270);
            trialCloseButton.Name = "trialCloseButton";
            trialCloseButton.Size = new Size(75, 23);
            trialCloseButton.TabIndex = 8;
            trialCloseButton.Text = "Close";
            trialCloseButton.UseVisualStyleBackColor = true;
            // 
            // numberOfTrials
            // 
            numberOfTrials.AutoSize = true;
            numberOfTrials.Location = new Point(474, 145);
            numberOfTrials.Name = "numberOfTrials";
            numberOfTrials.Size = new Size(111, 15);
            numberOfTrials.TabIndex = 9;
            numberOfTrials.Text = "Nombre d'épreuves";
            // 
            // numericUDNumberOfTrial
            // 
            numericUDNumberOfTrial.Location = new Point(474, 163);
            numericUDNumberOfTrial.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericUDNumberOfTrial.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUDNumberOfTrial.Name = "numericUDNumberOfTrial";
            numericUDNumberOfTrial.Size = new Size(120, 23);
            numericUDNumberOfTrial.TabIndex = 10;
            numericUDNumberOfTrial.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // TrialView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(numericUDNumberOfTrial);
            Controls.Add(numberOfTrials);
            Controls.Add(trialCloseButton);
            Controls.Add(trialStartButton);
            Controls.Add(trialDifficultyLabel);
            Controls.Add(trialIndicatorLevelLabel);
            Controls.Add(trialSkillLevelLabel);
            Controls.Add(trialIndicatorLabel);
            Controls.Add(trialSkillLabel);
            Controls.Add(trialNameLabel);
            Name = "TrialView";
            Text = "Trial";
            ((System.ComponentModel.ISupportInitialize)numericUDNumberOfTrial).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label trialNameLabel;
        private Label trialSkillLabel;
        private Label trialIndicatorLabel;
        private Label trialSkillLevelLabel;
        private Label trialIndicatorLevelLabel;
        private Label trialDifficultyLabel;
        private Button trialStartButton;
        private Button trialCloseButton;
        private Label numberOfTrials;
        private NumericUpDown numericUDNumberOfTrial;
    }
}