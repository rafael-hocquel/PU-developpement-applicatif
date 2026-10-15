namespace ButopiaMysteries.GraphicsUserInterface
{
    partial class PreferenceDialog
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
            backgroundColorLabel = new Label();
            characterColorLabel = new Label();
            defaultCharacterMumber = new Label();
            backgroundColor = new Label();
            characterColor = new Label();
            numericUDCharacterCount = new NumericUpDown();
            applyButton = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUDCharacterCount).BeginInit();
            SuspendLayout();
            // 
            // backgroundColorLabel
            // 
            backgroundColorLabel.AutoSize = true;
            backgroundColorLabel.Location = new Point(64, 49);
            backgroundColorLabel.Name = "backgroundColorLabel";
            backgroundColorLabel.Size = new Size(95, 15);
            backgroundColorLabel.TabIndex = 0;
            backgroundColorLabel.Text = "Couleur de Fond";
            // 
            // characterColorLabel
            // 
            characterColorLabel.AutoSize = true;
            characterColorLabel.Location = new Point(64, 87);
            characterColorLabel.Name = "characterColorLabel";
            characterColorLabel.Size = new Size(140, 15);
            characterColorLabel.TabIndex = 1;
            characterColorLabel.Text = "Couleur des Personnages";
            // 
            // defaultCharacterMumber
            // 
            defaultCharacterMumber.AutoSize = true;
            defaultCharacterMumber.Location = new Point(60, 126);
            defaultCharacterMumber.Name = "defaultCharacterMumber";
            defaultCharacterMumber.Size = new Size(194, 15);
            defaultCharacterMumber.TabIndex = 2;
            defaultCharacterMumber.Text = "Nombre de personnages par defaut";
            // 
            // backgroundColor
            // 
            backgroundColor.AutoSize = true;
            backgroundColor.BorderStyle = BorderStyle.FixedSingle;
            backgroundColor.Location = new Point(184, 49);
            backgroundColor.Name = "backgroundColor";
            backgroundColor.Size = new Size(24, 17);
            backgroundColor.TabIndex = 3;
            backgroundColor.Text = "     ";
            backgroundColor.Click += BackgroundColor_Click;
            // 
            // characterColor
            // 
            characterColor.AutoSize = true;
            characterColor.BorderStyle = BorderStyle.FixedSingle;
            characterColor.Location = new Point(220, 87);
            characterColor.Name = "characterColor";
            characterColor.Size = new Size(24, 17);
            characterColor.TabIndex = 4;
            characterColor.Text = "     ";
            characterColor.Click += CharacterColor_Click;
            // 
            // numericUDCharacterCount
            // 
            numericUDCharacterCount.Location = new Point(288, 126);
            numericUDCharacterCount.Name = "numericUDCharacterCount";
            numericUDCharacterCount.Size = new Size(120, 23);
            numericUDCharacterCount.TabIndex = 5;
            // 
            // applyButton
            // 
            applyButton.DialogResult = DialogResult.OK;
            applyButton.Location = new Point(691, 415);
            applyButton.Name = "applyButton";
            applyButton.Size = new Size(75, 23);
            applyButton.TabIndex = 6;
            applyButton.Text = "OK";
            applyButton.UseVisualStyleBackColor = true;
            applyButton.Click += ApplyButton_Click;
            // 
            // PreferenceDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(applyButton);
            Controls.Add(numericUDCharacterCount);
            Controls.Add(characterColor);
            Controls.Add(backgroundColor);
            Controls.Add(defaultCharacterMumber);
            Controls.Add(characterColorLabel);
            Controls.Add(backgroundColorLabel);
            Name = "PreferenceDialog";
            Text = "Préférences";
            ((System.ComponentModel.ISupportInitialize)numericUDCharacterCount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label backgroundColorLabel;
        private Label characterColorLabel;
        private Label defaultCharacterMumber;
        private Label backgroundColor;
        private Label characterColor;
        private NumericUpDown numericUDCharacterCount;
        private Button applyButton;
    }
}