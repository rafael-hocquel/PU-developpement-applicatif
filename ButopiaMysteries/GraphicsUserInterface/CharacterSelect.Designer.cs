namespace ButopiaMysteries.GraphicsUserInterface
{
    partial class CharacterSelect
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            createButton = new Button();
            quitButton = new Button();
            difficultyComboBox = new ComboBox();
            skillComboBox = new ComboBox();
            SuspendLayout();
            // 
            // createButton
            // 
            createButton.Location = new Point(652, 12);
            createButton.Name = "createButton";
            createButton.Size = new Size(136, 23);
            createButton.TabIndex = 1;
            createButton.Text = "Nouveau mystère...";
            createButton.UseVisualStyleBackColor = true;
            createButton.Click += CreateButton_Click;
            // 
            // quitButton
            // 
            quitButton.Location = new Point(713, 402);
            quitButton.Name = "quitButton";
            quitButton.Size = new Size(75, 23);
            quitButton.TabIndex = 2;
            quitButton.Text = "Quitter";
            quitButton.UseVisualStyleBackColor = true;
            quitButton.Click += QuitButton_Click;
            // 
            // difficultyComboBox
            // 
            difficultyComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            difficultyComboBox.FormattingEnabled = true;
            difficultyComboBox.Location = new Point(576, 402);
            difficultyComboBox.Name = "difficultyComboBox";
            difficultyComboBox.Size = new Size(121, 23);
            difficultyComboBox.TabIndex = 4;
            // 
            // skillComboBox
            // 
            skillComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            skillComboBox.FormattingEnabled = true;
            skillComboBox.Location = new Point(449, 402);
            skillComboBox.Name = "skillComboBox";
            skillComboBox.Size = new Size(121, 23);
            skillComboBox.TabIndex = 5;
            // 
            // CharacterSelect
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(skillComboBox);
            Controls.Add(difficultyComboBox);
            Controls.Add(quitButton);
            Controls.Add(createButton);
            DoubleBuffered = true;
            Name = "CharacterSelect";
            Text = "Sélection";
            Paint += CharacterSelect_Paint;
            MouseDoubleClick += CharacterSelect_MouseDoubleClick;
            MouseDown += CharacterSelect_MouseDown;
            MouseMove += CharacterSelect_MouseMove;
            MouseUp += CharacterSelect_MouseUp;
            ResumeLayout(false);
        }

        #endregion
        private Button createButton;
        private Button quitButton;
        private ComboBox difficultyComboBox;
        private ComboBox skillComboBox;
    }
}
