using ButopiaMysteries.Logic;
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
    /// <summary>
    /// A basic dialog for character creation.
    /// </summary>
    public partial class NewCharacterDialog : Form
    {

        // Computed properties to have the latest combobox values 
        public Plan Plan => (Plan)planComboBox.SelectedItem;
        public Sphere Sphere => (Sphere)sphereComboBox.SelectedItem;

        /// <summary>
        /// The name of the character.
        /// </summary>
        public string CharacterName { get { return nameTextBox.Text; } }
        /// <summary>
        /// The fact that this character is randomly created or not.
        /// </summary>
        public bool RandomGeneration { get { return randomCreationCheckBox.Checked; } }
        /// <summary>
        /// Empty constructor.
        /// </summary>
        public NewCharacterDialog()
        {
            InitializeComponent();
            okButton.Enabled = true;

            // Plan and Sphere combobox
            planComboBox.DataSource = Enum.GetValues(typeof(Plan));
            sphereComboBox.DataSource = Enum.GetValues(typeof(Sphere));
        }

        /// <summary>
        /// Crates a random name if the text box is double clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NameTextBox_DoubleClick(object sender, EventArgs e)
        {
            nameTextBox.Text = Names.RandomName;
        }

        /// <summary>
        /// Enables the button to create the character if there is text in the text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            okButton.Enabled = nameTextBox.Text.Length > 0;
        }

        /// <summary>
        /// Enables the button to create the character if there is text in the text box, or if the random generation is enabled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void randomCreationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (randomCreationCheckBox.Checked)
            {
                okButton.Enabled = true;
            } else
            {
                okButton.Enabled = nameTextBox.Text.Length > 0;
            }

        }
    }
}