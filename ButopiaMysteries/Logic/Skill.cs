using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace ButopiaMysteries.Logic
{
    /// <summary>
    /// Enum for all skills.
    /// </summary>
    public enum Skill
    {

        // Global Skills
        None,
        Feat,
        Dodge,
        Design,
        Synthesis,
        Analysis,
        Expression,
        Survival,
        Seduction,

        // Thinker Plan
        ThinkersPlan_Concentration,
        ThinkersPlan_Abstraction,
        ThinkersPlan_Visualization,
        ThinkersPlan_Modelization,

        // Legates Plan
        LegatesPlan_Sustainability,
        LegatesPlan_Perception,
        LegatesPlan_Details,
        LegatesPlan_Memorialisation,

        // Makers Plan
        MakersPlan_Skill,
        MakersPlan_Architecture,
        MakersPlan_Organization,
        MakersPlan_Reification,

        // Integrators Plan
        IntegratorsPlan_Proprioception,
        IntegratorsPlan_Connection,
        IntegratorsPlan_Synesthesia,
        IntegratorsPlan_Compilation,

        // Retailers Plan
        RetailersPlan_Endurance,
        RetailersPlan_Finance,
        RetailersPlan_Expertise,
        RetailersPlan_Communication,

        // Algebra Sphere
        AlgebraSphere_Junction,
        AlgebraSphere_Induction,
        AlgebraSphere_Equation,
        AlgebraSphere_Functional,

        // Verbs Sphere
        VerbsSphere_Injuction,
        VerbsSphere_Formulation,
        VerbsSphere_Poetics,
        VerbsSphere_Subject,

        // Transition Sphere
        TransitionSphere_Deconstruction,
        TransitionSphere_Anticipation,
        TransitionSphere_Argumentation,
        TransitionSphere_Optimisation,

        // Creation Sphere
        CreationSphere_Adjustement,
        CreationSphere_Design,
        CreationSphere_Narration,
        CreationSphere_Data,

        //Valuation Sphere
        ValuationSphere_Destructuration,
        ValuationSphere_Logistics,
        ValuationSphere_Conviction,
        ValuationSphere_Tests,
    }
    /// <summary>
    /// Companion class for the enum above.
    /// </summary>
    public static class Skill_Operations
    {
        /// <summary>
        /// The Name associated to the skill.
        /// </summary>
        /// <param name="skill">skill to examine</param>
        /// <returns>the name (in French)</returns>
        public static string Name(this Skill skill)
        {
            return skill switch
            {
                Skill.Feat => "Prouesse",
                Skill.Dodge => "Esquive",
                Skill.Design => "Conception",
                Skill.Synthesis => "Synthèse",
                Skill.Analysis => "Analyse",
                Skill.Expression => "Expression",
                Skill.Survival => "Survie",
                Skill.Seduction => "Séduction",
                // Thinker Plan
                Skill.ThinkersPlan_Concentration => "Concentration",
                Skill.ThinkersPlan_Abstraction => "Abstraction",
                Skill.ThinkersPlan_Visualization => "Visualisation",
                Skill.ThinkersPlan_Modelization => "Modélisation",

                // Legates Plan
                Skill.LegatesPlan_Sustainability => "Pérennité",
                Skill.LegatesPlan_Perception => "Perception",
                Skill.LegatesPlan_Details => "Perception",
                Skill.LegatesPlan_Memorialisation => "Mémoïsation",

                // Makers Plan
                Skill.MakersPlan_Skill => "Habileté",
                Skill.MakersPlan_Architecture => "Architecture",
                Skill.MakersPlan_Organization => "Organisation",
                Skill.MakersPlan_Reification => "Réification",

                // Integrators Plan
                Skill.IntegratorsPlan_Proprioception => "Proprioception",
                Skill.IntegratorsPlan_Connection => "Liaison",
                Skill.IntegratorsPlan_Synesthesia => "Synesthésie",
                Skill.IntegratorsPlan_Compilation => "Compilation",

                // Retailers Plan
                Skill.RetailersPlan_Endurance => "Endurance",
                Skill.RetailersPlan_Finance => "Finance",
                Skill.RetailersPlan_Expertise => "Expertise",
                Skill.RetailersPlan_Communication => "Communication",

                // Algebra Sphere
                Skill.AlgebraSphere_Junction => "Jonction",
                Skill.AlgebraSphere_Induction => "Induction",
                Skill.AlgebraSphere_Equation => "Équation",
                Skill.AlgebraSphere_Functional => "Fonctionnel",

                // Verbs Sphere
                Skill.VerbsSphere_Injuction => "Injonction",
                Skill.VerbsSphere_Formulation => "Formulation",
                Skill.VerbsSphere_Poetics => "Poétique",
                Skill.VerbsSphere_Subject => "Objet",

                // Transition Sphere
                Skill.TransitionSphere_Deconstruction => "Déconstruction",
                Skill.TransitionSphere_Anticipation => "Anticipation",
                Skill.TransitionSphere_Argumentation => "Argumentation",
                Skill.TransitionSphere_Optimisation => "Optimisation",

                // Creation Sphere
                Skill.CreationSphere_Adjustement => "Ajustement",
                Skill.CreationSphere_Design => "Conception",
                Skill.CreationSphere_Narration => "Narration",
                Skill.CreationSphere_Data => "Données",

                //Valuation Sphere
                Skill.ValuationSphere_Destructuration => "Destruction",
                Skill.ValuationSphere_Logistics => "Intendance",
                Skill.ValuationSphere_Conviction => "Conviction",
                Skill.ValuationSphere_Tests => "Tests",
                _ => string.Empty
            };
        }

        /// <summary>
        /// Returns the description corresponding to the level
        /// </summary>
        /// <param name="level">The level of a statistic</param>
        /// <returns>The description corresponding to the level</returns>
        public static string LevelName(int level)
        {
            return level switch
            {
                0 => "Incompétent",
                1 => "Amateur",
                2 => "Apprenti",
                3 => "Compagnon",
                4 => "Maître",
                5 => "Agrégé",
                6 => "Ministre",
                _ => string.Empty,
            };
        }

        /// <summary>
        /// A list of all skills
        /// </summary>
        /// <returns>A list of all skills</returns>
        public static List<Skill> DefaultSkills()
        {
            return new List<Skill>()
            {
                Skill.Feat,
                Skill.Dodge,
                Skill.Design,
                Skill.Synthesis,
                Skill.Analysis,
                Skill.Expression,
                Skill.Survival,
                Skill.Seduction,
            };
        }

        /// <summary>
        /// Returns the cast bonus from the skill level
        /// </summary>
        /// <param name="level">The skill level</param>
        /// <returns>The cast bonus from the skill level</returns>
        public static int BonusFromSkillLevel(int level)
        {
            return level switch
            {
                2 => 5,
                3 => 5,
                4 => 10,
                5 => 15,
                6 => 20,
                _ => 0
            };
        }

        /// <summary>
        /// Returns all skills a character has with a sphere and a plan
        /// </summary>
        /// <param name="plan">A plan</param>
        /// <param name="sphere">A sphere</param>
        /// <returns>All skills a character has with a sphere and a plan</returns>
        public static List<Skill> AllCharacterSkills(Plan plan, Sphere sphere)
        {
            List<Skill> res = DefaultSkills();
            List<Skill> planSkills = Plan_Operations.SkillsFromPlan(plan);
            List<Skill> sphereSkills =  Sphere_Operations.SkillsFromSphere(sphere);
            res.AddRange(planSkills);
            res.AddRange(sphereSkills);
            return res;
        }

        /// <summary>
        /// The Indicator associated to the skill.
        /// </summary>
        /// <param name="skill">skill to examine</param>
        /// <returns>the indicator (or null)</returns>

        public static Indicator? GetIndicator(this Skill skill)
        {
            return skill switch
            {
                Skill.Feat => Indicator.Body,
                Skill.Dodge => Indicator.Body,
                Skill.Design => Indicator.Mind,
                Skill.Synthesis => Indicator.Mind,
                Skill.Analysis => Indicator.Sense,
                Skill.Expression => Indicator.Sense,
                Skill.Survival => Indicator.Maximum,
                Skill.Seduction => Indicator.Maximum,
                // Thinker Plan
                Skill.ThinkersPlan_Concentration => Indicator.Mind,
                Skill.ThinkersPlan_Abstraction => Indicator.Mind,
                Skill.ThinkersPlan_Visualization => Indicator.Mind,
                Skill.ThinkersPlan_Modelization => Indicator.Mind,

                // Legates Plan
                Skill.LegatesPlan_Sustainability => Indicator.Sense,
                Skill.LegatesPlan_Perception => Indicator.Sense,
                Skill.LegatesPlan_Details => Indicator.Sense,
                Skill.LegatesPlan_Memorialisation => Indicator.Sense,

                // Makers Plan
                Skill.MakersPlan_Skill => Indicator.Body,
                Skill.MakersPlan_Architecture => Indicator.Body,
                Skill.MakersPlan_Organization => Indicator.Body,
                Skill.MakersPlan_Reification => Indicator.Body,

                // Integrators Plan
                Skill.IntegratorsPlan_Proprioception => Indicator.Maximum,
                Skill.IntegratorsPlan_Connection => Indicator.Maximum,
                Skill.IntegratorsPlan_Synesthesia => Indicator.Maximum,
                Skill.IntegratorsPlan_Compilation => Indicator.Maximum,

                // Retailers Plan
                Skill.RetailersPlan_Endurance => Indicator.Sense,
                Skill.RetailersPlan_Finance => Indicator.Sense,
                Skill.RetailersPlan_Expertise => Indicator.Sense,
                Skill.RetailersPlan_Communication => Indicator.Sense,

                // Algebra Sphere
                Skill.AlgebraSphere_Junction => Indicator.Mind,
                Skill.AlgebraSphere_Induction => Indicator.Mind,
                Skill.AlgebraSphere_Equation => Indicator.Mind,
                Skill.AlgebraSphere_Functional => Indicator.Mind,

                // Verbs Sphere
                Skill.VerbsSphere_Injuction => Indicator.Sense,
                Skill.VerbsSphere_Formulation => Indicator.Sense,
                Skill.VerbsSphere_Poetics => Indicator.Sense,
                Skill.VerbsSphere_Subject => Indicator.Sense,

                // Transition Sphere
                Skill.TransitionSphere_Deconstruction => Indicator.Maximum,
                Skill.TransitionSphere_Anticipation => Indicator.Maximum,
                Skill.TransitionSphere_Argumentation => Indicator.Maximum,
                Skill.TransitionSphere_Optimisation => Indicator.Maximum,

                // Creation Sphere
                Skill.CreationSphere_Adjustement => Indicator.Body,
                Skill.CreationSphere_Design => Indicator.Body,
                Skill.CreationSphere_Narration => Indicator.Body,
                Skill.CreationSphere_Data => Indicator.Body,

                //Valuation Sphere
                Skill.ValuationSphere_Destructuration => Indicator.Maximum,
                Skill.ValuationSphere_Logistics => Indicator.Maximum,
                Skill.ValuationSphere_Conviction => Indicator.Maximum,
                Skill.ValuationSphere_Tests => Indicator.Maximum,
                _ => null,
            };
        }
        /// <summary>
        /// Gives all skills satisfying a specified condition.
        /// </summary>
        /// <param name="predicate">the predicate to check</param>
        /// <returns>the constructed list</returns>
        public static List<Skill> AllSkillsSuchAs(Predicate<Skill> predicate)
        {
            List<Skill> allSkills = [Skill.Feat, Skill.Dodge, Skill.Design, Skill.Synthesis,
                Skill.Analysis, Skill.Expression, Skill.Survival, Skill.Seduction];
            return allSkills.FindAll(predicate);
        }
        /// <summary>
        /// The absolute lower bound for skills.
        /// </summary>
        public static int MinValue { get; } = 0;
        /// <summary>
        /// The absolute upper bound for skills.
        /// </summary>
        public static int MaxValue { get; } = 6;
        /// <summary>
        /// The maximum value at creation for a skill.
        /// </summary>
        public static int CreationThreshold { get; } = 4;
        /// <summary>
        /// The basic value for fixed creation.
        /// </summary>
        public static int BasicValue { get; } = 2;
        /// <summary>
        /// A formula yielding the skill points necessary for a skill level.
        /// </summary>
        /// <param name="level">the target level</param>
        /// <returns>the corresponding skill points</returns>
        public static int SkillPointsAtLevel(int level) => level;
    }
}
