using ButopiaMysteries.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButopiaMysteries_Test
{
    /// <summary>
    /// Test class for the Difficulty class.
    /// </summary>
    public class DifficultyTests
    {
        /// <summary>
        /// Tests that we get the right french name for each Difficulties.
        /// </summary>
        [Test]
        public void DifficultyName_Tests()
        {
            Assert.That(Difficulty.None.Name(), Is.EqualTo("Rien"));
            Assert.That(Difficulty.Trivial.Name(), Is.EqualTo("Trivial"));
            Assert.That(Difficulty.Easy.Name(), Is.EqualTo("Facile"));
            Assert.That(Difficulty.Normal.Name(), Is.EqualTo("Normal"));
            Assert.That(Difficulty.Complex.Name(), Is.EqualTo("Complexe"));
            Assert.That(Difficulty.Delicate.Name(), Is.EqualTo("Délicat"));
            Assert.That(Difficulty.Challenge.Name(), Is.EqualTo("Défi"));
            Assert.That(Difficulty.Exploit.Name(), Is.EqualTo("Exploit"));
            Assert.That(Difficulty.Superhuman.Name(), Is.EqualTo("Surhumain"));
            Assert.That(Difficulty.Impossible.Name(), Is.EqualTo("Impossible"));
        }

        /// <summary>
        /// Checks that the function returns the right difficulty for a given score.
        /// </summary>
        [Test]
        public void DifficultyFromScore_Tests()
        {
            // En dessous du minimum (< 5)
            Assert.That(Difficulty_Operations.DifficultyFromScore(-1), Is.EqualTo(Difficulty.None));
            Assert.That(Difficulty_Operations.DifficultyFromScore(0), Is.EqualTo(Difficulty.None));
            Assert.That(Difficulty_Operations.DifficultyFromScore(4), Is.EqualTo(Difficulty.None));

            // Au dessus du max
            Assert.That(Difficulty_Operations.DifficultyFromScore(101), Is.EqualTo(Difficulty.Impossible));
            Assert.That(Difficulty_Operations.DifficultyFromScore(1000), Is.EqualTo(Difficulty.Impossible));

            // Palliers Piles
            Assert.That(Difficulty_Operations.DifficultyFromScore(0), Is.EqualTo(Difficulty.None));
            Assert.That(Difficulty_Operations.DifficultyFromScore(5), Is.EqualTo(Difficulty.Trivial));
            Assert.That(Difficulty_Operations.DifficultyFromScore(10), Is.EqualTo(Difficulty.Easy));
            Assert.That(Difficulty_Operations.DifficultyFromScore(15), Is.EqualTo(Difficulty.Normal));
            Assert.That(Difficulty_Operations.DifficultyFromScore(20), Is.EqualTo(Difficulty.Complex));
            Assert.That(Difficulty_Operations.DifficultyFromScore(25), Is.EqualTo(Difficulty.Delicate));
            Assert.That(Difficulty_Operations.DifficultyFromScore(30), Is.EqualTo(Difficulty.Challenge));
            Assert.That(Difficulty_Operations.DifficultyFromScore(50), Is.EqualTo(Difficulty.Exploit));
            Assert.That(Difficulty_Operations.DifficultyFromScore(70), Is.EqualTo(Difficulty.Superhuman));
            Assert.That(Difficulty_Operations.DifficultyFromScore(100), Is.EqualTo(Difficulty.Impossible));

            // Entre les palliers
            Assert.That(Difficulty_Operations.DifficultyFromScore(3), Is.EqualTo(Difficulty.None));
            Assert.That(Difficulty_Operations.DifficultyFromScore(6), Is.EqualTo(Difficulty.Trivial));
            Assert.That(Difficulty_Operations.DifficultyFromScore(11), Is.EqualTo(Difficulty.Easy));
            Assert.That(Difficulty_Operations.DifficultyFromScore(16), Is.EqualTo(Difficulty.Normal));
            Assert.That(Difficulty_Operations.DifficultyFromScore(24), Is.EqualTo(Difficulty.Complex));
            Assert.That(Difficulty_Operations.DifficultyFromScore(29), Is.EqualTo(Difficulty.Delicate));
            Assert.That(Difficulty_Operations.DifficultyFromScore(39), Is.EqualTo(Difficulty.Challenge));
            Assert.That(Difficulty_Operations.DifficultyFromScore(69), Is.EqualTo(Difficulty.Exploit));
            Assert.That(Difficulty_Operations.DifficultyFromScore(92), Is.EqualTo(Difficulty.Superhuman));
        }

        /// <summary>
        /// Verifies that ClosedTrialAutomaticResult returns the correct automatic result
        /// for every combination of level and difficulty (success or failure).
        /// </summary>
        [Test]
        public void ClosedTrialAutomaticResult_AllCases_ReturnExpectedResult()
        {
            // Level 0
            Assert.That(Difficulty_Operations.ClosedTrialAutomaticResult(0, Difficulty.None), Is.False);
            Assert.That(Difficulty_Operations.ClosedTrialAutomaticResult(0, Difficulty.Trivial), Is.False);
            Assert.That(Difficulty_Operations.ClosedTrialAutomaticResult(0, Difficulty.Impossible), Is.False);

            // Level 1
            Assert.That(Difficulty_Operations.ClosedTrialAutomaticResult(1, Difficulty.Exploit), Is.False);
            Assert.That(Difficulty_Operations.ClosedTrialAutomaticResult(1, Difficulty.Superhuman), Is.False);
            Assert.That(Difficulty_Operations.ClosedTrialAutomaticResult(1, Difficulty.Impossible), Is.False);
            Assert.That(Difficulty_Operations.ClosedTrialAutomaticResult(1, Difficulty.Challenge), Is.Null);
            Assert.That(Difficulty_Operations.ClosedTrialAutomaticResult(1, Difficulty.Normal), Is.Null);

            // Level 2
            Assert.That(Difficulty_Operations.ClosedTrialAutomaticResult(2, Difficulty.Trivial), Is.True);
            Assert.That(Difficulty_Operations.ClosedTrialAutomaticResult(2, Difficulty.Superhuman), Is.False);
            Assert.That(Difficulty_Operations.ClosedTrialAutomaticResult(2, Difficulty.Impossible), Is.False);
            Assert.That(Difficulty_Operations.ClosedTrialAutomaticResult(2, Difficulty.Easy), Is.Null);
            Assert.That(Difficulty_Operations.ClosedTrialAutomaticResult(2, Difficulty.Challenge), Is.Null);

            // Level 3
            Assert.That(Difficulty_Operations.ClosedTrialAutomaticResult(3, Difficulty.Trivial), Is.True);
            Assert.That(Difficulty_Operations.ClosedTrialAutomaticResult(3, Difficulty.Impossible), Is.False);
            Assert.That(Difficulty_Operations.ClosedTrialAutomaticResult(3, Difficulty.Normal), Is.Null);
            Assert.That(Difficulty_Operations.ClosedTrialAutomaticResult(3, Difficulty.Superhuman), Is.Null);

            // Level 4 
            Assert.That(Difficulty_Operations.ClosedTrialAutomaticResult(4, Difficulty.None), Is.True);
            Assert.That(Difficulty_Operations.ClosedTrialAutomaticResult(4, Difficulty.Trivial), Is.True);
            Assert.That(Difficulty_Operations.ClosedTrialAutomaticResult(4, Difficulty.Easy), Is.True);
            Assert.That(Difficulty_Operations.ClosedTrialAutomaticResult(4, Difficulty.Normal), Is.Null);
            Assert.That(Difficulty_Operations.ClosedTrialAutomaticResult(4, Difficulty.Impossible), Is.Null);

            // Level 5
            Assert.That(Difficulty_Operations.ClosedTrialAutomaticResult(5, Difficulty.None), Is.True);
            Assert.That(Difficulty_Operations.ClosedTrialAutomaticResult(5, Difficulty.Normal), Is.True);
            Assert.That(Difficulty_Operations.ClosedTrialAutomaticResult(5, Difficulty.Complex), Is.Null);
            Assert.That(Difficulty_Operations.ClosedTrialAutomaticResult(5, Difficulty.Impossible), Is.Null);

            // Level 6
            Assert.That(Difficulty_Operations.ClosedTrialAutomaticResult(6, Difficulty.None), Is.True);
            Assert.That(Difficulty_Operations.ClosedTrialAutomaticResult(6, Difficulty.Complex), Is.True);
            Assert.That(Difficulty_Operations.ClosedTrialAutomaticResult(6, Difficulty.Delicate), Is.Null);
            Assert.That(Difficulty_Operations.ClosedTrialAutomaticResult(6, Difficulty.Impossible), Is.Null);

            // Default Case
            Assert.That(Difficulty_Operations.ClosedTrialAutomaticResult(7, Difficulty.Normal), Is.Null);
            Assert.That(Difficulty_Operations.ClosedTrialAutomaticResult(99, Difficulty.Impossible), Is.Null);
        }

        /// <summary>
        /// Verifies that GetDifficultyAfterPenalty returns the difficulty
        /// two grades below the one provided, and that low edge cases
        /// (None and Trivial) are clamped to None.
        /// </summary>
        [Test]
        public void GetDifficultyAfterPenalty_AllDifficulties_ReturnTwoGradesLower()
        {
            // Low edge cases
            Assert.That(Difficulty_Operations.GetDifficultyAfterPenalty(Difficulty.None), Is.EqualTo(Difficulty.None));
            Assert.That(Difficulty_Operations.GetDifficultyAfterPenalty(Difficulty.Trivial), Is.EqualTo(Difficulty.None));

            // Boundary case
            Assert.That(Difficulty_Operations.GetDifficultyAfterPenalty(Difficulty.Easy), Is.EqualTo(Difficulty.None));

            // Nominal cases
            Assert.That(Difficulty_Operations.GetDifficultyAfterPenalty(Difficulty.Normal), Is.EqualTo(Difficulty.Trivial));
            Assert.That(Difficulty_Operations.GetDifficultyAfterPenalty(Difficulty.Complex), Is.EqualTo(Difficulty.Easy));
            Assert.That(Difficulty_Operations.GetDifficultyAfterPenalty(Difficulty.Delicate), Is.EqualTo(Difficulty.Normal));
            Assert.That(Difficulty_Operations.GetDifficultyAfterPenalty(Difficulty.Challenge), Is.EqualTo(Difficulty.Complex));
            Assert.That(Difficulty_Operations.GetDifficultyAfterPenalty(Difficulty.Exploit), Is.EqualTo(Difficulty.Delicate));
            Assert.That(Difficulty_Operations.GetDifficultyAfterPenalty(Difficulty.Superhuman), Is.EqualTo(Difficulty.Challenge));
            Assert.That(Difficulty_Operations.GetDifficultyAfterPenalty(Difficulty.Impossible), Is.EqualTo(Difficulty.Exploit));
        }
    }
   
}
