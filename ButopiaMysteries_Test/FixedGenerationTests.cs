using ButopiaMysteries.Logic;

namespace ButopiaMysteries_Test
{
    /// <summary>
    /// Test class for FixedGeneration Class
    /// </summary>
    public class FixedGenerationTests
    {
        /// <summary>
        /// Test that a mystery sheet is generated with the fixed values for each indicators and skills.
        /// </summary>
        [Test]
        public void MysterySheet_FixedGenerationTests()
        {
            MysterySheet sheet = new("Test");
            sheet.RandomGeneration(Rules.Fixed);
            // Indicators
            Assert.That(sheet.Indicators[Indicator.Body], Is.EqualTo(Indicator_Operations.BasicValue));
            Assert.That(sheet.Indicators[Indicator.Mind], Is.EqualTo(Indicator_Operations.BasicValue));
            Assert.That(sheet.Indicators[Indicator.Sense], Is.EqualTo(Indicator_Operations.BasicValue));
            Assert.That(sheet.Indicators[Indicator.Maximum], Is.EqualTo(Indicator_Operations.BasicValue));

            // Skills
            Assert.That(sheet.Skills[Skill.Feat], Is.EqualTo(Skill_Operations.BasicValue));
            Assert.That(sheet.Skills[Skill.Dodge], Is.EqualTo(Skill_Operations.BasicValue));
            Assert.That(sheet.Skills[Skill.Design], Is.EqualTo(Skill_Operations.BasicValue));
            Assert.That(sheet.Skills[Skill.Synthesis], Is.EqualTo(Skill_Operations.BasicValue));
            Assert.That(sheet.Skills[Skill.Analysis], Is.EqualTo(Skill_Operations.BasicValue));
            Assert.That(sheet.Skills[Skill.Expression], Is.EqualTo(Skill_Operations.BasicValue));
            Assert.That(sheet.Skills[Skill.Survival], Is.EqualTo(Skill_Operations.BasicValue));
            Assert.That(sheet.Skills[Skill.Seduction], Is.EqualTo(Skill_Operations.BasicValue));
        }

    }
}