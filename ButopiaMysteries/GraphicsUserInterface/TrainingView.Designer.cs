namespace ButopiaMysteries.GraphicsUserInterface
{
    partial class TrainingView
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
            characterNameLabel = new Label();
            experienceLabel = new Label();
            stateLabel = new Label();
            indicatorLabel = new Label();
            currentIndicatorLevel = new Label();
            indicatorUpgradeCost = new Label();
            skillLabel = new Label();
            currentSkillLevelLabel = new Label();
            skillUpgradeCostLabel = new Label();
            skillTrainButton = new Button();
            quitButton = new Button();
            indicatorTrainButton = new Button();
            currentIndicatorLevelLabel = new Label();
            indicatorComboBox = new ComboBox();
            skillComboBox = new ComboBox();
            SuspendLayout();
            // 
            // characterNameLabel
            // 
            characterNameLabel.AutoSize = true;
            characterNameLabel.Location = new Point(53, 59);
            characterNameLabel.Name = "characterNameLabel";
            characterNameLabel.Size = new Size(69, 15);
            characterNameLabel.TabIndex = 0;
            characterNameLabel.Text = "Personnage";
            // 
            // experienceLabel
            // 
            experienceLabel.AutoSize = true;
            experienceLabel.Location = new Point(53, 104);
            experienceLabel.Name = "experienceLabel";
            experienceLabel.Size = new Size(63, 15);
            experienceLabel.TabIndex = 1;
            experienceLabel.Text = "Experience";
            // 
            // stateLabel
            // 
            stateLabel.AutoSize = true;
            stateLabel.Location = new Point(53, 148);
            stateLabel.Name = "stateLabel";
            stateLabel.Size = new Size(27, 15);
            stateLabel.TabIndex = 2;
            stateLabel.Text = "Etat";
            // 
            // indicatorLabel
            // 
            indicatorLabel.AutoSize = true;
            indicatorLabel.Location = new Point(53, 207);
            indicatorLabel.Name = "indicatorLabel";
            indicatorLabel.Size = new Size(60, 15);
            indicatorLabel.TabIndex = 3;
            indicatorLabel.Text = "Indicateur";
            // 
            // currentIndicatorLevel
            // 
            currentIndicatorLevel.AutoSize = true;
            currentIndicatorLevel.Location = new Point(53, 244);
            currentIndicatorLevel.Name = "currentIndicatorLevel";
            currentIndicatorLevel.Size = new Size(0, 15);
            currentIndicatorLevel.TabIndex = 4;
            // 
            // indicatorUpgradeCost
            // 
            indicatorUpgradeCost.AutoSize = true;
            indicatorUpgradeCost.Location = new Point(53, 281);
            indicatorUpgradeCost.Name = "indicatorUpgradeCost";
            indicatorUpgradeCost.Size = new Size(121, 15);
            indicatorUpgradeCost.TabIndex = 5;
            indicatorUpgradeCost.Text = "Cout prochain niveau";
            // 
            // skillLabel
            // 
            skillLabel.AutoSize = true;
            skillLabel.Location = new Point(53, 328);
            skillLabel.Name = "skillLabel";
            skillLabel.Size = new Size(75, 15);
            skillLabel.TabIndex = 6;
            skillLabel.Text = "Competence";
            // 
            // currentSkillLevelLabel
            // 
            currentSkillLevelLabel.AutoSize = true;
            currentSkillLevelLabel.Location = new Point(53, 364);
            currentSkillLevelLabel.Name = "currentSkillLevelLabel";
            currentSkillLevelLabel.Size = new Size(44, 15);
            currentSkillLevelLabel.TabIndex = 7;
            currentSkillLevelLabel.Text = "Niveau";
            // 
            // skillUpgradeCostLabel
            // 
            skillUpgradeCostLabel.AutoSize = true;
            skillUpgradeCostLabel.Location = new Point(53, 402);
            skillUpgradeCostLabel.Name = "skillUpgradeCostLabel";
            skillUpgradeCostLabel.Size = new Size(121, 15);
            skillUpgradeCostLabel.TabIndex = 8;
            skillUpgradeCostLabel.Text = "Cout prochain niveau";
            // 
            // skillTrainButton
            // 
            skillTrainButton.Location = new Point(534, 356);
            skillTrainButton.Name = "skillTrainButton";
            skillTrainButton.Size = new Size(75, 23);
            skillTrainButton.TabIndex = 9;
            skillTrainButton.Text = "Entrainer";
            skillTrainButton.UseVisualStyleBackColor = true;
            skillTrainButton.Click += SkillTrainButton_Click;
            // 
            // quitButton
            // 
            quitButton.DialogResult = DialogResult.OK;
            quitButton.Location = new Point(676, 399);
            quitButton.Name = "quitButton";
            quitButton.Size = new Size(75, 23);
            quitButton.TabIndex = 10;
            quitButton.Text = "Fermer";
            quitButton.UseVisualStyleBackColor = true;
            // 
            // indicatorTrainButton
            // 
            indicatorTrainButton.Location = new Point(534, 240);
            indicatorTrainButton.Name = "indicatorTrainButton";
            indicatorTrainButton.Size = new Size(75, 23);
            indicatorTrainButton.TabIndex = 11;
            indicatorTrainButton.Text = "Entrainer";
            indicatorTrainButton.UseVisualStyleBackColor = true;
            indicatorTrainButton.Click += IndicatorTrainButton_Click;
            // 
            // currentIndicatorLevelLabel
            // 
            currentIndicatorLevelLabel.AutoSize = true;
            currentIndicatorLevelLabel.Location = new Point(53, 244);
            currentIndicatorLevelLabel.Name = "currentIndicatorLevelLabel";
            currentIndicatorLevelLabel.Size = new Size(44, 15);
            currentIndicatorLevelLabel.TabIndex = 12;
            currentIndicatorLevelLabel.Text = "Niveau";
            // 
            // indicatorComboBox
            // 
            indicatorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            indicatorComboBox.FormattingEnabled = true;
            indicatorComboBox.Location = new Point(151, 207);
            indicatorComboBox.Name = "indicatorComboBox";
            indicatorComboBox.Size = new Size(121, 23);
            indicatorComboBox.TabIndex = 13;
            indicatorComboBox.SelectedIndexChanged += IndicatorComboBox_SelectedIndexChanged;
            // 
            // skillComboBox
            // 
            skillComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            skillComboBox.FormattingEnabled = true;
            skillComboBox.Location = new Point(164, 328);
            skillComboBox.Name = "skillComboBox";
            skillComboBox.Size = new Size(121, 23);
            skillComboBox.TabIndex = 14;
            skillComboBox.SelectedIndexChanged += SkillComboBox_SelectedIndexChanged;
            // 
            // TrainingView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(skillComboBox);
            Controls.Add(indicatorComboBox);
            Controls.Add(currentIndicatorLevelLabel);
            Controls.Add(indicatorTrainButton);
            Controls.Add(quitButton);
            Controls.Add(skillTrainButton);
            Controls.Add(skillUpgradeCostLabel);
            Controls.Add(currentSkillLevelLabel);
            Controls.Add(skillLabel);
            Controls.Add(indicatorUpgradeCost);
            Controls.Add(currentIndicatorLevel);
            Controls.Add(indicatorLabel);
            Controls.Add(stateLabel);
            Controls.Add(experienceLabel);
            Controls.Add(characterNameLabel);
            Name = "TrainingView";
            Text = "Entrainement";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label characterNameLabel;
        private Label experienceLabel;
        private Label stateLabel;
        private Label indicatorLabel;
        private Label currentIndicatorLevel;
        private Label indicatorUpgradeCost;
        private Label skillLabel;
        private Label currentSkillLevelLabel;
        private Label skillUpgradeCostLabel;
        private Button skillTrainButton;
        private Button quitButton;
        private Button indicatorTrainButton;
        private Label currentIndicatorLevelLabel;
        private ComboBox indicatorComboBox;
        private ComboBox skillComboBox;
    }
}