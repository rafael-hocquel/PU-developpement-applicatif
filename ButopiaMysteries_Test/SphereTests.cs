using ButopiaMysteries.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButopiaMysteries_Test
{
    public class SphereTests
    {
        /// <summary>
        /// Verifies that SkillsFromSphere returns the correct list of skills for each sphere.
        /// </summary>
        [Test]
        public void SkillsFromSphere_Tests()
        {
            // Algebra
            Assert.That(Sphere.Algebra.SkillsFromSphere(), Is.EqualTo(new List<Skill>
            {
                Skill.AlgebraSphere_Junction,
                Skill.AlgebraSphere_Induction,
                Skill.AlgebraSphere_Equation,
                Skill.AlgebraSphere_Functional,
            }));

            // Verbs
            Assert.That(Sphere.Verbs.SkillsFromSphere(), Is.EqualTo(new List<Skill>
            {
                Skill.VerbsSphere_Injuction,
                Skill.VerbsSphere_Formulation,
                Skill.VerbsSphere_Poetics,
                Skill.VerbsSphere_Subject,
            }));

            // Transition
            Assert.That(Sphere.Transition.SkillsFromSphere(), Is.EqualTo(new List<Skill>
            {
                Skill.TransitionSphere_Deconstruction,
                Skill.TransitionSphere_Anticipation,
                Skill.TransitionSphere_Argumentation,
                Skill.TransitionSphere_Optimisation,
            }));

            // Creation
            Assert.That(Sphere.Creation.SkillsFromSphere(), Is.EqualTo(new List<Skill>
            {
                Skill.CreationSphere_Adjustement,
                Skill.CreationSphere_Design,
                Skill.CreationSphere_Narration,
                Skill.CreationSphere_Data,
            }));

            // Valuation
            Assert.That(Sphere.Valuation.SkillsFromSphere(), Is.EqualTo(new List<Skill>
            {
                Skill.ValuationSphere_Destructuration,
                Skill.ValuationSphere_Logistics,
                Skill.ValuationSphere_Conviction,
                Skill.ValuationSphere_Tests,
            }));
        }
    }
}
