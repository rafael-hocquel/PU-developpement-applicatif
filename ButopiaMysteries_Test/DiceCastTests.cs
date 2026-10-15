using ButopiaMysteries.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButopiaMysteries_Test
{
    /// <summary>
    /// Test for the DiceCast class
    /// </summary>
    public class DiceCastTests
    {
        /// <summary>
        /// Verifies that the randomly generated numbers are comprised between 1 and 6, and that we generate the right number of numbers.
        /// </summary>
        [Test]
        public void DifficultyName_Tests()
        {
            Random rand = new Random();
            for (int i = 0; i < 100; i++)
            {
                int listSize = rand.Next(0, 30);
                List<int> list = Trial.Cast(listSize);
                Assert.That(list.Count, Is.EqualTo(listSize));
                for (int j = 0; j < list.Count; j++)
                {
                    Assert.That(list[j], Is.InRange(1, 6));
                }
            }
        }
    }
}
