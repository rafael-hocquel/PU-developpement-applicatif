namespace ButopiaMysteries
{
    partial class BetterEditDialog
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
            itemEdited = new Label();
            currentValueLabel = new Label();
            remainingPoints = new Label();
            upgradeCostLabel = new Label();
            downgradeCostLabel = new Label();
            label6 = new Label();
            minusButton = new Button();
            plusButton = new Button();
            resetButton = new Button();
            cancelButton = new Button();
            applyButton = new Button();
            SuspendLayout();
            // 
            // itemEdited
            // 
            itemEdited.AutoSize = true;
            itemEdited.Location = new Point(46, 41);
            itemEdited.Name = "itemEdited";
            itemEdited.Size = new Size(56, 15);
            itemEdited.TabIndex = 0;
            itemEdited.Text = "Element: ";
            // 
            // currentValueLabel
            // 
            currentValueLabel.AutoSize = true;
            currentValueLabel.Location = new Point(46, 93);
            currentValueLabel.Name = "currentValueLabel";
            currentValueLabel.Size = new Size(91, 15);
            currentValueLabel.TabIndex = 1;
            currentValueLabel.Text = "Valeur Actuelle: ";
            // 
            // remainingPoints
            // 
            remainingPoints.AutoSize = true;
            remainingPoints.Location = new Point(46, 124);
            remainingPoints.Name = "remainingPoints";
            remainingPoints.Size = new Size(93, 15);
            remainingPoints.TabIndex = 2;
            remainingPoints.Text = "Points Restants: ";
            // 
            // upgradeCostLabel
            // 
            upgradeCostLabel.AutoSize = true;
            upgradeCostLabel.Location = new Point(46, 180);
            upgradeCostLabel.Name = "upgradeCostLabel";
            upgradeCostLabel.Size = new Size(121, 15);
            upgradeCostLabel.TabIndex = 3;
            upgradeCostLabel.Text = "Cout d'Amélioration: ";
            // 
            // downgradeCostLabel
            // 
            downgradeCostLabel.AutoSize = true;
            downgradeCostLabel.Location = new Point(46, 212);
            downgradeCostLabel.Name = "downgradeCostLabel";
            downgradeCostLabel.Size = new Size(135, 15);
            downgradeCostLabel.TabIndex = 4;
            downgradeCostLabel.Text = "Gain de Decrementation";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(381, 218);
            label6.Name = "label6";
            label6.Size = new Size(0, 15);
            label6.TabIndex = 5;
            // 
            // minusButton
            // 
            minusButton.Location = new Point(217, 289);
            minusButton.Name = "minusButton";
            minusButton.Size = new Size(75, 23);
            minusButton.TabIndex = 6;
            minusButton.Text = "-";
            minusButton.UseVisualStyleBackColor = true;
            minusButton.Click += MinusButton_Click;
            // 
            // plusButton
            // 
            plusButton.Location = new Point(333, 289);
            plusButton.Name = "plusButton";
            plusButton.Size = new Size(75, 23);
            plusButton.TabIndex = 7;
            plusButton.Text = "+";
            plusButton.UseVisualStyleBackColor = true;
            plusButton.Click += PlusButton_Click;
            // 
            // resetButton
            // 
            resetButton.Location = new Point(269, 334);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(75, 23);
            resetButton.TabIndex = 8;
            resetButton.Text = "Rénitialiser";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += ResetButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Location = new Point(517, 415);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 9;
            cancelButton.Text = "Annuler";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // applyButton
            // 
            applyButton.DialogResult = DialogResult.OK;
            applyButton.Location = new Point(598, 415);
            applyButton.Name = "applyButton";
            applyButton.Size = new Size(75, 23);
            applyButton.TabIndex = 10;
            applyButton.Text = "Appliquer";
            applyButton.UseVisualStyleBackColor = true;
            // 
            // BetterEditDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(applyButton);
            Controls.Add(cancelButton);
            Controls.Add(resetButton);
            Controls.Add(plusButton);
            Controls.Add(minusButton);
            Controls.Add(label6);
            Controls.Add(downgradeCostLabel);
            Controls.Add(upgradeCostLabel);
            Controls.Add(remainingPoints);
            Controls.Add(currentValueLabel);
            Controls.Add(itemEdited);
            Name = "BetterEditDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label itemEdited;
        private Label currentValueLabel;
        private Label remainingPoints;
        private Label upgradeCostLabel;
        private Label downgradeCostLabel;
        private Label label6;
        private Button minusButton;
        private Button plusButton;
        private Button resetButton;
        private Button cancelButton;
        private Button applyButton;
    }
}