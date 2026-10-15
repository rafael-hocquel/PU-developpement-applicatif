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
    public partial class TrialView : Form
    {   
        /// <summary>
        /// Character going through the trial.
        /// </summary>
        private readonly MysterySheet sheet;
        /// <summary>
        /// Skill used during the trial.
        /// </summary>
        private readonly Skill skill;
        /// <summary>
        /// The trial difficulty in a closed trial
        /// </summary>
        private readonly Difficulty? targetDifficulty;

        /// <summary>
        /// Constructor setting the initial label's text
        /// </summary>
        /// <param name="sheet">The character going through the trial</param>
        /// <param name="skill">The skill used during the trial</param>
        /// <param name="targetDifficulty">If it's a closed trial, the targeted difficulty</param>
        public TrialView(MysterySheet sheet, Skill skill, Difficulty? targetDifficulty = null)
        {
            InitializeComponent();
            this.sheet = sheet;
            this.skill = skill;
            this.targetDifficulty = targetDifficulty;

            // Texts and values
            trialNameLabel.Text = sheet.Name;

            trialSkillLabel.Text = Skill_Operations.Name(skill);
            trialSkillLevelLabel.Text = sheet.Skills.ContainsKey(skill) ? sheet.Skills[skill].ToString() : "0";


            Indicator? indicator = skill.GetIndicator();
            trialIndicatorLabel.Text = Indicator_Operations.Name(indicator);
            trialIndicatorLevelLabel.Text = indicator != null ? sheet.Indicators[indicator.Value].ToString() : "Pas d'indicateur";

            if (targetDifficulty != null)
            {
                trialDifficultyLabel.Text = Difficulty_Operations.Name(targetDifficulty.Value);
            }
            else
            {
                trialDifficultyLabel.Text = "Epreuve Ouverte";
            }

        }

        /// <summary>
        /// Button to start a trial
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrialStartButton_Click(object sender, EventArgs e)
        {
            if (sheet.State == CharacterState.Creation)
            {
                MessageBox.Show("Ce personnage est encore en cours de création, validez le pour lui faire passer des epreuves", "Erreur", MessageBoxButtons.OK);
                return;
            }
            int totalNumberOfTrials = (int)numericUDNumberOfTrial.Value;
            string results = "";
            for (int i = 1; i <= totalNumberOfTrials; i++)
            {
                if (targetDifficulty == null)
                {
                    Difficulty difficulty = Trial.OpenTrial(sheet, skill);
                    results += "Epreuve n°" + i + ": " + Difficulty_Operations.Name(difficulty) + Environment.NewLine;
                }
                else
                {
                    bool res = Trial.ClosedTrial(sheet, skill, targetDifficulty.Value);
                    results += "Epreuve n°" + i + ": " + (res ? "Succes" : "Echec") + Environment.NewLine;
                }
            }

            MessageBox.Show(results, "Resultats Epreuve");

        }
    }
}
