using ButopiaMysteries.GraphicsUserInterface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButopiaMysteries.Logic
{
    /// <summary>
    /// Class for a character sheet.
    /// </summary>
    public class MysterySheet
    {   
        /// <summary>
        /// The state of the character
        /// </summary>
        public CharacterState State { get; set; } = CharacterState.Creation;

        /// <summary>
        /// The character's plan
        /// </summary>
        public Plan Plan { get; set; } = Plan.Thinkers;

        /// <summary>
        /// The character's sphere
        /// </summary>
        public Sphere Sphere { get; set; } = Sphere.Algebra;

        /// <summary>
        /// The character's experience
        /// </summary>
        public int Experience { get; set; } = 0;

        /// <summary>
        /// Random object
        /// </summary>
        private readonly Random random = new();
        /// <summary>
        /// The name of the character.
        /// </summary>
        public string Name { get; init; }
        /// <summary>
        /// Mapping: indicators to numeric level.
        /// </summary>
        public Dictionary<Indicator, int> Indicators { get; init; }
        /// <summary>
        /// Mapping: skills to numeric level.
        /// </summary>
        public Dictionary<Skill, int> Skills { get; init; }
        /// <summary>
        /// Parametered constructor.
        /// </summary>
        /// <param name="name">The name of the new character.</param>
        public MysterySheet(string name)
        {
            Name = name;
            Indicators = [];
            Skills = [];
        }
        /// <summary>
        /// Generate the indicator and skill levels randomly.
        /// </summary>
        /// <param name="rules">The set of rules used for rng (default: full random)</param>
        public void RandomGeneration(Rules rules=Rules.None)
        {
            switch (rules)
            {
                case Rules.None:
                    {
                        Indicators.Add(Indicator.Body, GenRandNum(1, 5));
                        Indicators.Add(Indicator.Mind, GenRandNum(1, 5));
                        Indicators.Add(Indicator.Sense, GenRandNum(1, 5));
                        Indicators.Add(Indicator.Maximum, Math.Max(
                            Math.Max(Indicators[Indicator.Body], Indicators[Indicator.Mind]),
                            Indicators[Indicator.Sense]));
                        foreach (Skill skill in Skill_Operations.AllCharacterSkills(Plan, Sphere))
                        {
                            Skills.Add(skill, GenRandNum(0, 4));
                        }

                        break;
                    }
                case Rules.Fixed:
                    {
                        Indicators.Add(Indicator.Body, Indicator_Operations.BasicValue);
                        Indicators.Add(Indicator.Mind, Indicator_Operations.BasicValue);
                        Indicators.Add(Indicator.Sense, Indicator_Operations.BasicValue);
                        Indicators.Add(Indicator.Maximum, Indicator_Operations.BasicValue);

                        foreach (Skill skill in Skill_Operations.AllCharacterSkills(Plan, Sphere))
                        {
                            Skills.Add(skill, Skill_Operations.BasicValue);
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// Generates a random integer between a set minumum and maximum
        /// </summary>
        /// <param name="min">The lower bound, set on 0 if undefined</param>
        /// <param name="max">The upper bound, set on 6 if undefined</param>
        /// <returns>A random integer between minumum and maximum</returns>
        private int GenRandNum(int min = 0, int max=6)
        {
            return random.Next(min, max+1);
        }
    }
}