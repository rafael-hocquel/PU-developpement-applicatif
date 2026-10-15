using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButopiaMysteries.Logic
{
    /// <summary>
    /// A class stub for trials - dice rolls
    /// </summary>
    public static class Trial
    {
        private static readonly Random random = new Random();
        public static int NumericResult(List<int>? list, int skill=0)
        {
            if (skill == 0 || list == null || list.Count == 0)
            {
                return 0;
            }
            int result = 0;
            foreach (int item in list)
            {
                result += UpdatedDiceResults(item, skill);
            }

            // Bonus for skill level
            result += Skill_Operations.BonusFromSkillLevel(skill);

            return result;
        }

        /// <summary>
        /// Returns the dice modificators
        /// </summary>
        /// <param name="number">The number rolled</param>
        /// <param name="skill">The skill level</param>
        /// <returns>The dice modificators</returns>
        private static int UpdatedDiceResults(int number, int skill)
        {
            return skill switch
            {
                1 when number == 1 => 0,
                3 when number == 6 => 10,
                4 when number >= 5 => 10,
                5 when number >= 4 => 10,
                6 when number >= 4 => 20,
                _ => number
            };
        }

        /// <summary>
        /// Casts diceLauch times a 6 faced dice
        /// </summary>
        /// <param name="diceLaunch">The amount of dices to cast</param>
        /// <returns>A list of each number rolled</returns>
        public static List<int> Cast(int diceLaunch)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < diceLaunch; i++)
            {
                list.Add(random.Next(1, 7));
            }
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="skill"></param>
        /// <returns></returns>
        private static (int validLevel, bool apply2LevelPenalty) GetValidSkillLevel(MysterySheet sheet, Skill skill)
        {
            // If already correct
            if (sheet.Skills.ContainsKey(skill) && sheet.Skills[skill] > 0)
            {
                return (sheet.Skills[skill], false);
            }

            // If indicator is incorrect
            Indicator? indicator = skill.GetIndicator();
            if (indicator == null)
            {
                return (0, false);
            }

            int highestLevel = 0;
            foreach(Skill temp in Skill_Operations.AllSkillsSuchAs(_ => true))
            {
                if (skill != temp && sheet.Skills.ContainsKey(temp) && sheet.Skills[temp] > highestLevel)
                {
                    highestLevel = sheet.Skills[temp];
                }
            }

            if (highestLevel > 0)
            {
                return (highestLevel, true  );
            }

            return (0, false);



        }

        /// <summary>
        /// Runs an open trial, gives the maximum difficulty a character rollrd
        /// </summary>
        /// <param name="sheet">The character going through the trial</param>
        /// <param name="skill">The required skill</param>
        /// <param name="testList">A list containing pre-roled dices to do tests</param>
        /// <returns>The maximum difficulty the character rolled</returns>
        public static Difficulty OpenTrial(MysterySheet sheet, Skill skill, List<int>? testList = null)
        {
            Indicator? indicator = Skill_Operations.GetIndicator(skill);
            if (indicator  == null)
            {
                return Difficulty.None;
            }

            int indicatorValue = sheet.Indicators[indicator.Value];
            List<int> castList;
            if (testList == null)
            {
                castList = Cast(indicatorValue);
            }
            else
            {
                castList = testList;
            }

            (int validLevel, bool penalty) = Trial.GetValidSkillLevel(sheet, skill);

            int score = NumericResult(castList, validLevel);

            Difficulty res = Difficulty_Operations.DifficultyFromScore(score);

            if (penalty)
            {
                res = Difficulty_Operations.GetDifficultyAfterPenalty(res);
            }

            return res;
        }

        /// <summary>
        /// Runs a closed trial, returns true if a character overcomes a trial at a set difficulty
        /// </summary>
        /// <param name="sheet">The character going through the trial</param>
        /// <param name="skill">The requiered skill</param>
        /// <param name="targetDifficulty">The targeted difficulty</param>
        /// <param name="testList">A list containing pre-roled dices to do tests</param>
        /// <returns>True if the character passed the trial, false if he fails</returns>
        public static bool ClosedTrial(MysterySheet sheet, Skill skill, Difficulty targetDifficulty, List<int>? testList = null)
        {
            if (sheet.Skills.ContainsKey(skill))
            {
                bool? automaticResult = Difficulty_Operations.ClosedTrialAutomaticResult(sheet.Skills[skill], targetDifficulty);

                if (automaticResult != null)
                {
                    if (automaticResult.Value == true)
                    {
                        sheet.Experience++;
                    }
                    return automaticResult.Value;
                }
            }

            bool res = OpenTrial(sheet, skill, testList) >= targetDifficulty;
            if (res)
            {
                sheet.Experience++;
            }
            return res;
        }
    }
}
