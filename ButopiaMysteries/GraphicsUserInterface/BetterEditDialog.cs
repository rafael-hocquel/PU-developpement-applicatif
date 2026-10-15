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

namespace ButopiaMysteries
{
    public partial class BetterEditDialog : Form
    {
        /// <summary>
        /// The value (start & end) = level.
        /// </summary>
        public int Value { get; private set; }
        /// <summary>
        /// The points available.
        /// </summary>
        public int Points { get; private set; }

        /// <summary>
        /// The value before edit
        /// </summary>
        private readonly int valueBeforeEdit;

        /// <summary>
        /// The points availlable before edit
        /// </summary>
        private readonly int pointsBeforeEdit;

        /// <summary>
        /// True if the user edits an Indicator, false if he edits a Skill
        /// </summary>
        private bool isIndicator;

        /// <summary>
        /// Constructor for editing an indicator
        /// </summary>
        /// <param name="indicator">The indicator to edit</param>
        /// <param name="currentValue">The value of said indicator</param>
        /// <param name="currentPoints">Currently available points</param>
        public BetterEditDialog(Indicator indicator, int currentValue, int currentPoints)
        {
            InitializeComponent();
            this.isIndicator = true;
            Points = currentPoints;
            this.pointsBeforeEdit = currentPoints;
            Value = currentValue;
            this.valueBeforeEdit = currentValue;
            
            itemEdited.Text = "Element Modifié: " + Indicator_Operations.Name(indicator);
            UpdateLabels();
        }

        /// <summary>
        /// Constructor for editing a skill
        /// </summary>
        /// <param name="skill">The skill to edit</param>
        /// <param name="currentValue">The value of said skill</param>
        /// <param name="currentPoints">Currently available points</param>
        public BetterEditDialog(Skill skill, int currentValue, int currentPoints)
        {
            InitializeComponent();
            this.isIndicator = false;
            Points = currentPoints;
            this.pointsBeforeEdit = currentPoints;
            Value = currentValue;
            this.valueBeforeEdit = currentValue;

            itemEdited.Text = "Element Modifié: " + Skill_Operations.Name(skill);
            UpdateLabels();
        }

        /// <summary>
        /// Adds 1 to available points, removes 1 to the value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MinusButton_Click(object sender, EventArgs e)
        {
            int minLevel = isIndicator ? Indicator_Operations.MinValue : Skill_Operations.MinValue;

            if (minLevel < Value)
            {
                int downgradeCost = isIndicator ? Indicator_Operations.IndicatorPointsAtLevel(Value - 1) : Skill_Operations.SkillPointsAtLevel(Value - 1);
                Points += downgradeCost;
                Value--;
            }
            UpdateLabels();
        }

        /// <summary>
        /// Adds 1 to the value, removes 1 to available points
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlusButton_Click(object sender, EventArgs e)
        {
            int upgradeCost = isIndicator ? Indicator_Operations.IndicatorPointsAtLevel(Value + 1) : Skill_Operations.SkillPointsAtLevel(Value + 1);
            if (upgradeCost <= Points)
            {
                Points -= upgradeCost;
                Value++;
            }
            UpdateLabels();
        }

        /// <summary>
        /// Resets all changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetButton_Click(object sender, EventArgs e)
        {
            Value = valueBeforeEdit;
            Points = pointsBeforeEdit;
            UpdateLabels();
        }

        /// <summary>
        /// Updates the labels to show changes made by the user
        /// </summary>
        private void UpdateLabels()
        {
            currentValueLabel.Text = "Valeur Actuelle: " + Value;
            remainingPoints.Text = "Points Restants: " + Points;

            int upgradeCost = isIndicator ? Indicator_Operations.IndicatorPointsAtLevel(Value + 1) : Skill_Operations.SkillPointsAtLevel(Value + 1);
            int downgradeCost = isIndicator ? Indicator_Operations.IndicatorPointsAtLevel(Value - 1) : Skill_Operations.SkillPointsAtLevel(Value - 1);
            upgradeCostLabel.Text = "Cout d'améioration: " + upgradeCost;
            downgradeCostLabel.Text = "Cout de décrémentation: " + downgradeCost;
        }
    }
}
