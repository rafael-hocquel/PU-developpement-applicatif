using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButopiaMysteries.Logic
{
    /// <summary>
    /// Enumeration for all the spheres
    /// </summary>
    public enum Sphere
    {
        Algebra,
        Verbs,
        Transition,
        Creation,
        Valuation
    }

    /// <summary>
    /// Companion class for the Sphere enum above
    /// </summary>
    public static class Sphere_Operations
    {
        /// <summary>
        /// Returns the name of the skill based on the given sphere.
        /// </summary>
        /// <param name="sphere">The sphere we want to get the name of</param>
        /// <returns></returns>
        public static string Name(this Sphere sphere)
        {
            return sphere switch
            {
                Sphere.Algebra => "Algèbre",
                Sphere.Verbs => "Verbe",
                Sphere.Transition => "Transition",
                Sphere.Creation => "Création",
                Sphere.Valuation => "Valorisation",
                _ => string.Empty
            };
        }

        /// <summary>
        /// Returns the list of available skills from a given sphere
        /// </summary>
        /// <param name="sphere">A sphere</param>
        /// <returns>The list of skills accessible from the given sphere</returns>
        public static List<Skill> SkillsFromSphere(this Sphere sphere)
        {
            return sphere switch
            {
                Sphere.Algebra => new List<Skill>
                {
                    Skill.AlgebraSphere_Junction,
                    Skill.AlgebraSphere_Induction,
                    Skill.AlgebraSphere_Equation,
                    Skill.AlgebraSphere_Functional,
                },
                Sphere.Verbs => new List<Skill>
                {
                    Skill.VerbsSphere_Injuction,
                    Skill.VerbsSphere_Formulation,
                    Skill.VerbsSphere_Poetics,
                    Skill.VerbsSphere_Subject,
                },
                Sphere.Transition => new List<Skill>
                {
                    Skill.TransitionSphere_Deconstruction,
                    Skill.TransitionSphere_Anticipation,
                    Skill.TransitionSphere_Argumentation,
                    Skill.TransitionSphere_Optimisation,
                },
                Sphere.Creation => new List<Skill>
                {
                    Skill.CreationSphere_Adjustement,
                    Skill.CreationSphere_Design,
                    Skill.CreationSphere_Narration,
                    Skill.CreationSphere_Data,
                },
                Sphere.Valuation => new List<Skill>
                {
                    Skill.ValuationSphere_Destructuration,
                    Skill.ValuationSphere_Logistics,
                    Skill.ValuationSphere_Conviction,
                    Skill.ValuationSphere_Tests,
                },
                _ => new List<Skill>()
            };
        }
    }
}
