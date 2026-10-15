using ButopiaMysteries.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButopiaMysteries_Test
{
    /// <summary>
    /// Test for the Skill class
    /// </summary>
    public class SkillTests
    {
        /// <summary>
        /// Verifies that MinValue is equal to 0.
        /// </summary>
        [Test]
        public void MinValue_Tests()
        {
            Assert.That(Skill_Operations.MinValue, Is.EqualTo(0));
        }

        /// <summary>
        /// Verifies that MaxValue is equal to 6.
        /// </summary>
        [Test]
        public void MaxValue_Tests()
        {
            Assert.That(Skill_Operations.MaxValue, Is.EqualTo(6));
        }

        /// <summary>
        /// Verifies that CreationThreshold is equal to 4.
        /// </summary>
        [Test]
        public void CreationThreshold_Tests()
        {
            Assert.That(Skill_Operations.CreationThreshold, Is.EqualTo(4));
        }

        /// <summary>
        /// Verifies that BasicValue is equal to 2.
        /// </summary>
        [Test]
        public void BasicValue_Tests()
        {
            Assert.That(Skill_Operations.BasicValue, Is.EqualTo(2));
        }

        /// <summary>
        /// Verifies that SkillPointsAtLevel returns the level itself for various inputs.
        /// </summary>
        [Test]
        public void SkillPointsAtLevel_Tests()
        {
            Assert.That(Skill_Operations.SkillPointsAtLevel(0), Is.EqualTo(0));
            Assert.That(Skill_Operations.SkillPointsAtLevel(1), Is.EqualTo(1));
            Assert.That(Skill_Operations.SkillPointsAtLevel(3), Is.EqualTo(3));
            Assert.That(Skill_Operations.SkillPointsAtLevel(6), Is.EqualTo(6));
            Assert.That(Skill_Operations.SkillPointsAtLevel(-1), Is.EqualTo(-1));
        }

        /// <summary>
        /// Verifies that DefaultSkills returns exactly the eight global skills.
        /// </summary>
        [Test]
        public void DefaultSkills_Tests()
        {
            Assert.That(Skill_Operations.DefaultSkills(), Is.EqualTo(new List<Skill>
            {
                Skill.Feat,
                Skill.Dodge,
                Skill.Design,
                Skill.Synthesis,
                Skill.Analysis,
                Skill.Expression,
                Skill.Survival,
                Skill.Seduction,
            }));
        }

        /// <summary>
        /// Verifies that BonusFromSkillLevel returns the correct bonus for each level.
        /// </summary>
        [Test]
        public void BonusFromSkillLevel_Tests()
        {
            Assert.That(Skill_Operations.BonusFromSkillLevel(0), Is.EqualTo(0));
            Assert.That(Skill_Operations.BonusFromSkillLevel(1), Is.EqualTo(0));
            Assert.That(Skill_Operations.BonusFromSkillLevel(2), Is.EqualTo(5));
            Assert.That(Skill_Operations.BonusFromSkillLevel(3), Is.EqualTo(5));
            Assert.That(Skill_Operations.BonusFromSkillLevel(4), Is.EqualTo(10));
            Assert.That(Skill_Operations.BonusFromSkillLevel(5), Is.EqualTo(15));
            Assert.That(Skill_Operations.BonusFromSkillLevel(6), Is.EqualTo(20));
            Assert.That(Skill_Operations.BonusFromSkillLevel(-1), Is.EqualTo(0));
            Assert.That(Skill_Operations.BonusFromSkillLevel(99), Is.EqualTo(0));
        }

        /// <summary>
        /// Verifies that AllCharacterSkills returns the correct values.
        /// </summary>
        [Test]
        public void AllCharacterSkills_Tests()
        {
            List<Skill> expected = new List<Skill>
            {
                // Default skills
                Skill.Feat,
                Skill.Dodge,
                Skill.Design,
                Skill.Synthesis,
                Skill.Analysis,
                Skill.Expression,
                Skill.Survival,
                Skill.Seduction,
                // Thinkers plan skills
                Skill.ThinkersPlan_Concentration,
                Skill.ThinkersPlan_Abstraction,
                Skill.ThinkersPlan_Visualization,
                Skill.ThinkersPlan_Modelization,
                // Algebra sphere skills
                Skill.AlgebraSphere_Junction,
                Skill.AlgebraSphere_Induction,
                Skill.AlgebraSphere_Equation,
                Skill.AlgebraSphere_Functional,
            };

            Assert.That(Skill_Operations.AllCharacterSkills(Plan.Thinkers, Sphere.Algebra), Is.EqualTo(expected));
        }

        /// <summary>
        /// Verifies that GetIndicator returns the correct indicator for each skill category.
        /// </summary>
        [Test]
        public void GetIndicator_Tests()
        {
            // Global skills
            Assert.That(Skill.Feat.GetIndicator(), Is.EqualTo(Indicator.Body));
            Assert.That(Skill.Dodge.GetIndicator(), Is.EqualTo(Indicator.Body));
            Assert.That(Skill.Design.GetIndicator(), Is.EqualTo(Indicator.Mind));
            Assert.That(Skill.Synthesis.GetIndicator(), Is.EqualTo(Indicator.Mind));
            Assert.That(Skill.Analysis.GetIndicator(), Is.EqualTo(Indicator.Sense));
            Assert.That(Skill.Expression.GetIndicator(), Is.EqualTo(Indicator.Sense));
            Assert.That(Skill.Survival.GetIndicator(), Is.EqualTo(Indicator.Maximum));
            Assert.That(Skill.Seduction.GetIndicator(), Is.EqualTo(Indicator.Maximum));

            // Thinkers plan
            Assert.That(Skill.ThinkersPlan_Concentration.GetIndicator(), Is.EqualTo(Indicator.Mind));
            Assert.That(Skill.ThinkersPlan_Modelization.GetIndicator(), Is.EqualTo(Indicator.Mind));

            // Legates plan
            Assert.That(Skill.LegatesPlan_Sustainability.GetIndicator(), Is.EqualTo(Indicator.Sense));
            Assert.That(Skill.LegatesPlan_Memorialisation.GetIndicator(), Is.EqualTo(Indicator.Sense));

            // Makers plan
            Assert.That(Skill.MakersPlan_Skill.GetIndicator(), Is.EqualTo(Indicator.Body));
            Assert.That(Skill.MakersPlan_Reification.GetIndicator(), Is.EqualTo(Indicator.Body));

            // Integrators plan
            Assert.That(Skill.IntegratorsPlan_Proprioception.GetIndicator(), Is.EqualTo(Indicator.Maximum));
            Assert.That(Skill.IntegratorsPlan_Compilation.GetIndicator(), Is.EqualTo(Indicator.Maximum));

            // Retailers plan
            Assert.That(Skill.RetailersPlan_Endurance.GetIndicator(), Is.EqualTo(Indicator.Sense));
            Assert.That(Skill.RetailersPlan_Communication.GetIndicator(), Is.EqualTo(Indicator.Sense));

            // Algebra sphere
            Assert.That(Skill.AlgebraSphere_Junction.GetIndicator(), Is.EqualTo(Indicator.Mind));
            Assert.That(Skill.AlgebraSphere_Functional.GetIndicator(), Is.EqualTo(Indicator.Mind));

            // Verbs sphere
            Assert.That(Skill.VerbsSphere_Injuction.GetIndicator(), Is.EqualTo(Indicator.Sense));
            Assert.That(Skill.VerbsSphere_Subject.GetIndicator(), Is.EqualTo(Indicator.Sense));

            // Transition sphere
            Assert.That(Skill.TransitionSphere_Deconstruction.GetIndicator(), Is.EqualTo(Indicator.Maximum));
            Assert.That(Skill.TransitionSphere_Optimisation.GetIndicator(), Is.EqualTo(Indicator.Maximum));

            // Creation sphere
            Assert.That(Skill.CreationSphere_Adjustement.GetIndicator(), Is.EqualTo(Indicator.Body));
            Assert.That(Skill.CreationSphere_Data.GetIndicator(), Is.EqualTo(Indicator.Body));

            // Valuation sphere
            Assert.That(Skill.ValuationSphere_Destructuration.GetIndicator(), Is.EqualTo(Indicator.Maximum));
            Assert.That(Skill.ValuationSphere_Tests.GetIndicator(), Is.EqualTo(Indicator.Maximum));

            // Default case
            Assert.That(Skill.None.GetIndicator(), Is.Null);
        }

        /// <summary>
        /// Verifies that AllSkillsSuchAs correctly filters the global skill list.
        /// </summary>
        [Test]
        public void AllSkillsSuchAs_Tests()
        {
            // Always true : all eight default skills are returned
            Assert.That(Skill_Operations.AllSkillsSuchAs(_ => true), Is.EqualTo(new List<Skill>
            {
                Skill.Feat,
                Skill.Dodge,
                Skill.Design,
                Skill.Synthesis,
                Skill.Analysis,
                Skill.Expression,
                Skill.Survival,
                Skill.Seduction,
            }));

            // empty list
            Assert.That(Skill_Operations.AllSkillsSuchAs(_ => false), Is.Empty);

            // Only Body skills
            Assert.That(
                Skill_Operations.AllSkillsSuchAs(s => s.GetIndicator() == Indicator.Body),
                Is.EqualTo(new List<Skill> { Skill.Feat, Skill.Dodge }));

            // Only Mind skills
            Assert.That(
                Skill_Operations.AllSkillsSuchAs(s => s.GetIndicator() == Indicator.Mind),
                Is.EqualTo(new List<Skill> { Skill.Design, Skill.Synthesis }));

            // Only Sense skills
            Assert.That(
                Skill_Operations.AllSkillsSuchAs(s => s.GetIndicator() == Indicator.Sense),
                Is.EqualTo(new List<Skill> { Skill.Analysis, Skill.Expression }));

            // Only Maximum skills
            Assert.That(
                Skill_Operations.AllSkillsSuchAs(s => s.GetIndicator() == Indicator.Maximum),
                Is.EqualTo(new List<Skill> { Skill.Survival, Skill.Seduction }));
        }
    }
}
