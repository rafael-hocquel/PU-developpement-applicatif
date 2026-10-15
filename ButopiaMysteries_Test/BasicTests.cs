using ButopiaMysteries.Logic;

namespace ButopiaMysteries_Test
{
    /// <summary>
    /// A basic test class.
    /// </summary>
    public class Tests
    {
        /// <summary>
        /// Test for MysterySheet Constructor.
        /// </summary>
        [Test]
        public void MysterySheet_Constructor()
        {
            MysterySheet sheet = new("Test");
            Assert.That(sheet, Is.Not.Null);
            Assert.That(sheet.Name, Is.EqualTo("Test"));
        }

        /// <summary>
        /// General tests for skill.
        /// </summary>
        [Test]
        public void Indicator_Tests()
        {
            Indicator? indicator = Indicator.Body;
            Assert.That(indicator, Is.Not.Null);
            Assert.That(indicator.Name(), Is.EqualTo("Corps"));
            Assert.That(Indicator_Operations.IndicatorPointsAtLevel(1), Is.EqualTo(2));
            Assert.That(Indicator_Operations.IndicatorPointsAtLevel(2), Is.EqualTo(4));
            Assert.That(Indicator_Operations.IndicatorPointsAtLevel(5), Is.EqualTo(10));
        }


        /// <summary>
        /// General tests for Skill.
        /// </summary>
        [Test]
        public void Skill_Tests()
        {
            Skill skill = Skill.Feat;
            Assert.NotNull(skill);
            Assert.That(skill.Name(), Is.EqualTo("Prouesse"));
            Assert.That(skill.GetIndicator(), Is.EqualTo(Indicator.Body));
            Assert.That(Skill_Operations.SkillPointsAtLevel(1), Is.EqualTo(1));
            Assert.That(Skill_Operations.SkillPointsAtLevel(2), Is.EqualTo(2));
            Assert.That(Skill_Operations.SkillPointsAtLevel(5), Is.EqualTo(5));
        }
    }
}