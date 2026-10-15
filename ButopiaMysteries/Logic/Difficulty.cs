using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.DataFormats;

namespace ButopiaMysteries.Logic
{
    /// <summary>
    /// Enumeration of difficulties
    /// </summary>
    public enum Difficulty
    {
        None = 0,
        Trivial = 5,
        Easy = 10,
        Normal = 15,
        Complex = 20,
        Delicate = 25,
        Challenge = 30,
        Exploit = 50,
        Superhuman = 70,
        Impossible = 100
    }

    /// <summary>
    /// Operations on Difficulty enumeration
    /// </summary>
    public static class Difficulty_Operations
    {
        /// <summary>
        /// Retruns the name of a difficulty
        /// </summary>
        /// <param name="difficulty">A difficulty</param>
        /// <returns>The difficulty's name</returns>
        public static string Name(this Difficulty difficulty)
        {
            return difficulty switch
            {
                Difficulty.None => "Rien",
                Difficulty.Trivial => "Trivial",
                Difficulty.Easy => "Facile",
                Difficulty.Normal => "Normal",
                Difficulty.Complex => "Complexe",
                Difficulty.Delicate => "Délicat",
                Difficulty.Challenge => "Défi",
                Difficulty.Exploit => "Exploit",
                Difficulty.Superhuman => "Surhumain",
                Difficulty.Impossible => "Impossible",
                _ => string.Empty
            };
        }

        /// <summary>
        /// Returns true if the closed trial will always be completed, false else
        /// </summary>
        /// <param name="level">Skill level</param>
        /// <param name="difficulty">Selected difficulty</param>
        /// <returns>True if the closed trial will always be completed, false else</returns>
        public static bool? ClosedTrialAutomaticResult(int level, Difficulty difficulty)
        {
            // Syntaxe du switch avec when trouvee sur stackoverflow: https://stackoverflow.com/questions/44096614/c-sharp-7-switch-case-using-when-the-way-its-not-meant-to-be-used

            // Returs true on success and false otherwize or null if ze need to launch dices
            return level switch
            {
                0 => false,

                1 when difficulty >= Difficulty.Exploit => false,
                2 when difficulty == Difficulty.Trivial => true,
                2 when difficulty >= Difficulty.Superhuman => false,
                3 when difficulty == Difficulty.Trivial => true,
                3 when difficulty == Difficulty.Impossible => false,
                4 when difficulty <= Difficulty.Easy => true,
                5 when difficulty <= Difficulty.Normal => true,
                6 when difficulty <= Difficulty.Complex => true,
                _ => null
            };
        }

        /// <summary>
        /// Returns the difficulty from a numbered score
        /// </summary>
        /// <param name="score">Score</param>
        /// <returns>Difficulty from the numbered score</returns>
        public static Difficulty DifficultyFromScore(int score)
        {
            if (score >= (int)Difficulty.Impossible) return Difficulty.Impossible;
            if (score >= (int)Difficulty.Superhuman) return Difficulty.Superhuman;
            if (score >= (int)Difficulty.Exploit) return Difficulty.Exploit;
            if (score >= (int)Difficulty.Challenge) return Difficulty.Challenge;
            if (score >= (int)Difficulty.Delicate) return Difficulty.Delicate;
            if (score >= (int)Difficulty.Complex) return Difficulty.Complex;
            if (score >= (int)Difficulty.Normal) return Difficulty.Normal;
            if (score >= (int)Difficulty.Easy) return Difficulty.Easy;
            if (score >= (int)Difficulty.Trivial) return Difficulty.Trivial;
            return Difficulty.None;
        }

        /// <summary>
        /// Returns a difficulty which got downgraded by two grades
        /// </summary>
        /// <param name="difficulty">A difficulty</param>
        /// <returns>The two grades inferior difficulty</returns>
        public static Difficulty GetDifficultyAfterPenalty(Difficulty difficulty)
        {
            List<Difficulty> difficulties = new()
                {
                    Difficulty.None,
                    Difficulty.Trivial,
                    Difficulty.Easy,
                    Difficulty.Normal,
                    Difficulty.Complex,
                    Difficulty.Delicate,
                    Difficulty.Challenge,
                    Difficulty.Exploit,
                    Difficulty.Superhuman,
                    Difficulty.Impossible
                };
            int value = difficulties.IndexOf(difficulty);
            int newIndex = value - 2 >= 0 ? value - 2 : 0;
            return difficulties[newIndex];
        }
    }
}