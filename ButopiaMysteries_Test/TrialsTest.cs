using ButopiaMysteries.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButopiaMysteries_Test
{
    /// <summary>
    /// Test class for Trial class
    /// </summary>
    public class TrialsTest
    {
        [Test]
        public void NumericalResult_Test()
        {
            List<int> list = null;
            NumericalResult_TestMethod(list);
            list = [];
            NumericalResult_TestMethod(list);
            list = [5, 6, 67];
            NumericalResult_TestMethod(list);
            NumericalResult_TestMethod(list, 10, 78);
        }
        private void NumericalResult_TestMethod(List<int> list, int skill=0, int sum = 0)
        {
            if (list == null) // Case: null list
            {
                Assert.That(Trial.NumericResult(list, skill), Is.EqualTo(0));
                return;
            }
            if (list.Count == 0) // Case: empty list
            {
                Assert.That(Trial.NumericResult(list, skill), Is.EqualTo(0));
                return;
            }
            if (skill == 0) // Case: void skill
            {
                Assert.That(Trial.NumericResult(list, skill), Is.EqualTo(0));
                return;
            }
            // Nominal case
            Assert.That(Trial.NumericResult(list, skill), Is.EqualTo(sum));
        }

        /// <summary>
        /// Test for open trial that verifies that a sheet with given skills and rolls gets the right difficulty.
        /// </summary>
        [Test]
        public void OpenTrial_Test()
        {
            MysterySheet sheet = new("Test");
            sheet.Indicators.Add(Indicator.Body, 3);
            sheet.Indicators.Add(Indicator.Mind, 1);
            sheet.Indicators.Add(Indicator.Sense, 1);
            sheet.Indicators.Add(Indicator.Maximum, 3);
            sheet.Skills.Add(Skill.Feat, 2);

            // Test avec liste custom (1+2+3 = 6 donc Easy avec pénalité)
            Assert.That(Trial.OpenTrial(sheet, Skill.Feat, new List<int>{1, 2, 3}), Is.EqualTo(Difficulty.Easy));
            Assert.That(Trial.ClosedTrial(sheet, Skill.Feat, Difficulty.Trivial, new List<int>{1, 2, 3 }), Is.True);
            Assert.That(Trial.ClosedTrial(sheet, Skill.Feat, Difficulty.Easy, new List<int>{1, 2, 3}), Is.True);

            // Liste de test Vide
            Assert.That(Trial.OpenTrial(sheet, Skill.Feat, new List<int>{}), Is.EqualTo(Difficulty.None));

            // Skill à 0
            sheet.Skills[Skill.Feat] = 0;
            Assert.That(Trial.OpenTrial(sheet, Skill.Feat, new List<int>{1, 2, 3}), Is.EqualTo(Difficulty.None));
        }
    }
}