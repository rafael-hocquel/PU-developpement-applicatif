using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButopiaMysteries.Logic
{
 /// <summary>
 /// Enumeration for all plans.
 /// </summary>
    public enum Plan
    {
        Thinkers,
        Legates,
        Makers,
        Integrators,
        Retailers
    }

    /// <summary>
    /// Companion class for the Plan enumeration
    /// </summary>
    public static class Plan_Operations
    {
        /// <summary>
        /// Returns the name of the give plan.
        /// </summary>
        /// <param name="plan">The plan we want to have the name</param>
        /// <returns>The name of the given plan</returns>
        public static string Name(this Plan plan)
        {
            return plan switch
            {
                Plan.Thinkers => "Penseurs",
                Plan.Legates => "Légats",
                Plan.Makers => "Faiseurs",
                Plan.Integrators => "Intégrateurs",
                Plan.Retailers => "Commerçants",
                _ => string.Empty
            };
        }

        /// <summary>
        /// Returns the list of all the available skills from a certain plan.
        /// </summary>
        /// <param name="plan">A plan</param>
        /// <returns>The list of skills accessible from the given plan</returns>
        public static List<Skill> SkillsFromPlan(this Plan plan)
        {
            return plan switch
            {
                Plan.Thinkers => new List<Skill>
                {
                    Skill.ThinkersPlan_Concentration,
                    Skill.ThinkersPlan_Abstraction,
                    Skill.ThinkersPlan_Visualization,
                    Skill.ThinkersPlan_Modelization,
                },
                Plan.Legates => new List<Skill>
                {
                    Skill.LegatesPlan_Sustainability,
                    Skill.LegatesPlan_Perception,
                    Skill.LegatesPlan_Details,
                    Skill.LegatesPlan_Memorialisation,
                },
                Plan.Makers => new List<Skill>
                {
                    Skill.MakersPlan_Skill,
                    Skill.MakersPlan_Architecture,
                    Skill.MakersPlan_Organization,
                    Skill.MakersPlan_Reification,
                },
                Plan.Integrators => new List<Skill>
                {
                    Skill.IntegratorsPlan_Proprioception,
                    Skill.IntegratorsPlan_Connection,
                    Skill.IntegratorsPlan_Synesthesia,
                    Skill.IntegratorsPlan_Compilation,
                },
                Plan.Retailers => new List<Skill>
                {
                    Skill.RetailersPlan_Endurance,
                    Skill.RetailersPlan_Finance,
                    Skill.RetailersPlan_Expertise,
                    Skill.RetailersPlan_Communication,
                },
                _ => new List<Skill>()
            };
        }

    }
}
