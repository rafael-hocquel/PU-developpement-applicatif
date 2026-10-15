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
    public partial class TrainingView : Form
    {
        /// <summary>
        /// The mystery sheet of the character to train.
        /// </summary>
        private readonly MysterySheet sheet;

        /// <summary>
        /// The constructor for the training dialog.
        /// </summary>
        /// <param name="sheet"></param>
        public TrainingView(MysterySheet sheet)
        {
            InitializeComponent();
            this.sheet = sheet;
            characterNameLabel.Text = "Personnage: " + sheet.Name;
            stateLabel.Text = "Etat: " + sheet.State;

            // Fill indicator and skill combo boxes
            indicatorComboBox.DataSource = Enum.GetValues(typeof(Indicator));
            skillComboBox.DataSource = Enum.GetValues(typeof(Skill));

            UpdateLabels();
        }

        /// <summary>
        /// Updates the indicator, experience and skill labels.
        /// </summary>
        private void UpdateLabels()
        {
            if (indicatorComboBox.SelectedItem is Indicator indicator && indicator != Indicator.None)
            {
                int indicatorLevel = sheet.Indicators[indicator];
                currentIndicatorLevelLabel.Text = "Niveau Actuel: " + indicatorLevel;
                indicatorUpgradeCost.Text = "Cout Prochain Niveau" + Indicator_Operations.IndicatorPointsAtLevel(indicatorLevel + 1) + "EXP";
            }


            experienceLabel.Text = "Experience: " + sheet.Experience;


            if (skillComboBox.SelectedItem is Skill skill && skill != Skill.None)
            {
                int skillLevel = sheet.Skills[skill];
                currentSkillLevelLabel.Text = "Niveau Actuel: " + skillLevel;
                skillUpgradeCostLabel.Text = "Cout Prochain Niveau" + Skill_Operations.SkillPointsAtLevel(skillLevel + 1) + "EXP";
            }

        }

        /// <summary>
        /// Trains the selected indicator if the character has enough exp.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IndicatorTrainButton_Click(object sender, EventArgs e)
        {
            Indicator indicator = (Indicator)indicatorComboBox.SelectedItem;

            if (sheet.Indicators.ContainsKey(indicator) == false)
            {
                MessageBox.Show("Selectionnez en indicateur");
                return;
            }

            if (indicator == Indicator.Maximum)
            {
                return;
            }

            int value = sheet.Indicators[indicator];
            int cost = Indicator_Operations.IndicatorPointsAtLevel(value + 1);

            // Updrade indicator if enough free exp
            if (sheet.Experience >= cost)
            {
                sheet.Experience -= cost;
                sheet.Indicators[indicator]++;
                int bodyValue = sheet.Indicators[Indicator.Body];
                int mindValue = sheet.Indicators[Indicator.Mind];
                int senseValue = sheet.Indicators[Indicator.Sense];
                sheet.Indicators[Indicator.Maximum] = Math.Max(Math.Max(bodyValue, mindValue), senseValue);
                UpdateLabels();
            }
            else
            {
                MessageBox.Show("Par assez d'exp");
            }

        }

        /// <summary>
        /// Trains the selected skill if the character has enough exp.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SkillTrainButton_Click(object sender, EventArgs e)
        {
            Skill skill = (Skill)skillComboBox.SelectedItem;

            if (sheet.Skills.ContainsKey(skill) == false)
            {
                MessageBox.Show("Selectionnez en skill");
                return;
            }

            int value = sheet.Skills[skill];
            int cost = Skill_Operations.SkillPointsAtLevel(value + 1);

            // Updrade indicator if enough free exp
            if (sheet.Experience >= cost)
            {
                sheet.Experience -= cost;
                sheet.Skills[skill]++;
                UpdateLabels();
            }
            else
            {
                MessageBox.Show("Par assez d'exp");
            }
        }

        /// <summary>
        /// Update the labels when the selected indicator has changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IndicatorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLabels();
        }

        /// <summary>
        /// Update the labels when the selected skill has changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SkillComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLabels();
        }
    }
}
