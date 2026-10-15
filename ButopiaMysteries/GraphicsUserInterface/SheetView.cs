using ButopiaMysteries.Logic;

namespace ButopiaMysteries.GraphicsUserInterface
{
    /// <summary>
    /// A class to view/edit a Mystery Sheet
    /// </summary>
    public partial class SheetView : Form
    {   
        /// <summary>
        /// The selected character
        /// </summary>
        private MysterySheet Sheet { get; init; }
        /// <summary>
        /// The character's indicators
        /// </summary>
        private readonly Dictionary<Indicator, Label> indicatorLabels = [];
        /// <summary>
        /// The character's skills
        /// </summary>
        private readonly Dictionary<Skill, Label> skillLabels = [];
        /// <summary>
        /// True if on edit mode, false else
        /// </summary>
        private bool edit = false;
        /// <summary>
        /// Availlable indicator points
        /// </summary>
        private int indicatorPoints = 0;
        /// <summary>
        /// Availlable skill points
        /// </summary>
        private int skillPoints = 0;
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="mysterySheet">the sheet to display/edit</param>
        public SheetView(MysterySheet mysterySheet)
        {
            InitializeComponent();

            Sheet = mysterySheet;
            nameLabel.Text = Sheet.Name;
            indicatorLabels.Add(Indicator.Body, indicLabel1);
            indicatorLabels.Add(Indicator.Mind, indicLabel2);
            indicatorLabels.Add(Indicator.Sense, indicLabel3);
            indicatorLabels.Add(Indicator.Maximum, indicLabel4);

            List<Skill> skillList = Plan_Operations.SkillsFromPlan(Sheet.Plan);
            List<Skill> skillSphere = Sphere_Operations.SkillsFromSphere(Sheet.Sphere);

            // Default Skills
            skillLabels.Add(Skill.Feat, skillLabel1);
            skillLabels.Add(Skill.Design, skillLabel3);
            skillLabels.Add(Skill.Analysis, skillLabel5);
            skillLabels.Add(Skill.Survival, skillLabel7);
            skillLabels.Add(Skill.Dodge, skillLabel9);
            skillLabels.Add(Skill.Synthesis, skillLabel11);
            skillLabels.Add(Skill.Expression, skillLabel13);
            skillLabels.Add(Skill.Seduction, skillLabel15);

            // Plan & Sphere
            skillLabels.Add(skillList[0], skillLabel2);
            skillLabels.Add(skillList[1], skillLabel4);
            skillLabels.Add(skillList[2], skillLabel6);
            skillLabels.Add(skillList[3], skillLabel8);
            skillLabels.Add(skillSphere[0], skillLabel10);
            skillLabels.Add(skillSphere[1], skillLabel12);
            skillLabels.Add(skillSphere[2], skillLabel14);
            skillLabels.Add(skillSphere[3], skillLabel16);

            planLabel.Text = "Plan: " + Sheet.Plan.Name();
            sphereLabel.Text = "Sphere: " + Sheet.Sphere.Name();

            theToolStrip.Visible = true;
            validateCharacterCreationButton.Enabled = Sheet.State == CharacterState.Creation ? true : false;
            DisplayControls();
        }

        /// <summary>
        /// Displays
        /// </summary>
        private void DisplayControls()
        {
            if (edit)
            {
                modeToolStripButton.Text = "Edit Mode";
                indicatorPointsToolStripLabel.Visible = true;
                indicatorPointsToolStripLabel.Text = "PI: " + indicatorPoints;
                skillPointsToolStripLabel.Visible = true;
                skillPointsToolStripLabel.Text = "PC: " + skillPoints;
            }
            else
            {
                modeToolStripButton.Text = "View Mode";
                indicatorPointsToolStripLabel.Visible = false;
                skillPointsToolStripLabel.Visible = false;
            }
            foreach (Skill skill in skillLabels.Keys)
            {
                skillLabels[skill].Text = DisplaySkill(skill);
            }
            foreach (Indicator indicator in indicatorLabels.Keys)
            {
                indicatorLabels[indicator].Text = DisplayIndicator(indicator);
            }
            experienceLabel.Text = "Experience: " + Sheet.Experience;
        }
        private string DisplaySkill(Skill skill)
        {
            return skill.Name() + " : " + Skill_Operations.LevelName(Sheet.Skills[skill]);
        }

        private string DisplayIndicator(Indicator indicator)
        {
            return Indicator_Operations.Name(indicator) + " : " + Sheet.Indicators[indicator];
        }

        /// <summary>
        /// Closes the dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        /// <summary>
        /// Allows the user to toggle between edit and view mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModeToolStripButton_Click(object sender, EventArgs e)
        {
            if (Sheet.State == CharacterState.Training)
            {
                MessageBox.Show("Ce personnage est deja validé, vous ns pouvez plus le modifier", "Erreur", MessageBoxButtons.OK);
                return;
            }
            edit = !edit;
            DisplayControls();
        }

        /// <summary>
        /// Runs the code to edit a skill or an indicator
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_MouseClick(object sender, MouseEventArgs e)
        {
            if (!edit)
            {
                return;
            }
            if (sender is Label label)
            {
                Indicator indicator = indicatorLabels.Keys.FirstOrDefault(i => indicatorLabels[i].Equals(label), Indicator.None);
                if (indicator != Indicator.None)
                {
                    IndicatorEdit(indicator);
                }
                else
                {
                    Skill skill = skillLabels.Keys.FirstOrDefault(s => skillLabels[s].Equals(label), Skill.None);
                    if (skill != Skill.None)
                    {
                        SkillEdit(skill);
                    }
                }
            }
        }
        /// <summary>
        /// Opens the dialog to edit a skill
        /// </summary>
        /// <param name="skill">The skill to edit</param>
        private void SkillEdit(Skill skill)
        {
            BetterEditDialog dialog = new(skill, Sheet.Skills[skill], skillPoints);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                skillPoints = dialog.Points;
                Sheet.Skills[skill] = dialog.Value;
                DisplayControls();
            }
        }

        /// <summary>
        /// Updates the maximum indiactor if it needs to be changed
        /// </summary>
        private void UpdateMaximumIndicator()
        {
            int bodyValue = Sheet.Indicators[Indicator.Body];
            int mindValue = Sheet.Indicators[Indicator.Mind];
            int senseValue = Sheet.Indicators[Indicator.Sense];
            Sheet.Indicators[Indicator.Maximum] = Math.Max(Math.Max(bodyValue, mindValue), senseValue);
        }

        /// <summary>
        /// Opens the dialog to edit an indicator
        /// </summary>
        /// <param name="indicator">The indicator to edit</param>
        private void IndicatorEdit(Indicator indicator)
        {
            BetterEditDialog dialog = new(indicator, Sheet.Indicators[indicator], indicatorPoints);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                indicatorPoints = dialog.Points;
                Sheet.Indicators[indicator] = dialog.Value;
                UpdateMaximumIndicator();
                DisplayControls();
            }
        }

        /// <summary>
        /// Sets the character on training mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValidateCharacterCreationButton_Click(object sender, EventArgs e)
        {
            Sheet.State = CharacterState.Training;
            edit = false;
            validateCharacterCreationButton.Enabled = false;
            DisplayControls();
        }
    }
}
