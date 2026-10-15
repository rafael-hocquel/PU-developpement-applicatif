using ButopiaMysteries.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButopiaMysteries_Test
{
    /// <summary>
    /// Test for the plan class.
    /// </summary>
    public class PlanTests
    {
        /// <summary>
        /// Verifies that SkillsFromPlan returns the correct list of skills for each plan.
        /// </summary>
        [Test]
        public void SkillsFromPlan_Tests()
        {
            // Thinkers
            Assert.That(Plan.Thinkers.SkillsFromPlan(), Is.EqualTo(new List<Skill>
            {
                Skill.ThinkersPlan_Concentration,
                Skill.ThinkersPlan_Abstraction,
                Skill.ThinkersPlan_Visualization,
                Skill.ThinkersPlan_Modelization,
            }));

            // Legates
            Assert.That(Plan.Legates.SkillsFromPlan(), Is.EqualTo(new List<Skill>
            {
                Skill.LegatesPlan_Sustainability,
                Skill.LegatesPlan_Perception,
                Skill.LegatesPlan_Details,
                Skill.LegatesPlan_Memorialisation,
            }));

            // Makers
            Assert.That(Plan.Makers.SkillsFromPlan(), Is.EqualTo(new List<Skill>
            {
                Skill.MakersPlan_Skill,
                Skill.MakersPlan_Architecture,
                Skill.MakersPlan_Organization,
                Skill.MakersPlan_Reification,
            }));

            // Integrators
            Assert.That(Plan.Integrators.SkillsFromPlan(), Is.EqualTo(new List<Skill>
            {
                Skill.IntegratorsPlan_Proprioception,
                Skill.IntegratorsPlan_Connection,
                Skill.IntegratorsPlan_Synesthesia,
                Skill.IntegratorsPlan_Compilation,
            }));

            // Retailers
            Assert.That(Plan.Retailers.SkillsFromPlan(), Is.EqualTo(new List<Skill>
            {
                Skill.RetailersPlan_Endurance,
                Skill.RetailersPlan_Finance,
                Skill.RetailersPlan_Expertise,
                Skill.RetailersPlan_Communication,
            }));
        }
    }
}
