using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ButopiaMysteries.GraphicsUserInterface
{
    public partial class PreferenceDialog : Form
    {   
        /// <summary>
        /// Empty constructor
        /// </summary>
        public PreferenceDialog()
        {
            InitializeComponent();
            numericUDCharacterCount.Value = ViewSettings.DefaultCharacterNumber;
        }

        /// <summary>
        /// Sets s=the selected preferences
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApplyButton_Click(object sender, EventArgs e)
        {
            ViewSettings.BackgroundColor = backgroundColor.BackColor;
            ViewSettings.DefaultPawnColour = characterColor.BackColor;
            ViewSettings.DefaultCharacterNumber = (int)numericUDCharacterCount.Value;
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Opens the color dialog to change the background color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundColor_Click(object sender, EventArgs e)
        {
            ColorDialog col = new();
            if (col.ShowDialog() == DialogResult.OK)
            {
                backgroundColor.BackColor = col.Color;
            }
        }

        /// <summary>
        /// Opens the color dialog to change the character color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CharacterColor_Click(object sender, EventArgs e)
        {
            ColorDialog col = new();
            col.Color = ViewSettings.DefaultPawnColour;
            if (col.ShowDialog() == DialogResult.OK)
            {
                characterColor.BackColor = col.Color;
            }
        }
    }
}
