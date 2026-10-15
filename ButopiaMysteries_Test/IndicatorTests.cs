using ButopiaMysteries.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButopiaMysteries_Test
{
    /// <summary>
    /// Unit tests for the Indicator_Operations class
    /// </summary>
    public class IndicatorTests
    {
        /// <summary>
        /// Verifies that MinValue is equal to 1.
        /// </summary>
        [Test]
        public void MinValue_Test()
        {
            Assert.That(Indicator_Operations.MinValue, Is.EqualTo(1));
        }

        /// <summary>
        /// Verifies that MaxValue is equal to 7.
        /// </summary>
        [Test]
        public void MaxValue_Test()
        {
            Assert.That(Indicator_Operations.MaxValue, Is.EqualTo(7));
        }

        /// <summary>
        /// Verifies that CreationThreshold is equal to 5.
        /// </summary>
        [Test]
        public void CreationThreshold_Test()
        {
            Assert.That(Indicator_Operations.CreationThreshold, Is.EqualTo(5));
        }

        /// <summary>
        /// Verifies that BasicValue is equal to 3.
        /// </summary>
        [Test]
        public void BasicValue_Test()
        {
            Assert.That(Indicator_Operations.BasicValue, Is.EqualTo(3));
        }

        /// <summary>
        /// Verifies that IndicatorPointsAtLevel returns level * 2.
        /// </summary>
        [Test]
        public void IndicatorPointsAtLevel_Tests()
        {
            // Level 0
            Assert.That(Indicator_Operations.IndicatorPointsAtLevel(0), Is.EqualTo(0));

            // Nominal cases
            Assert.That(Indicator_Operations.IndicatorPointsAtLevel(1), Is.EqualTo(2));
            Assert.That(Indicator_Operations.IndicatorPointsAtLevel(2), Is.EqualTo(4));
            Assert.That(Indicator_Operations.IndicatorPointsAtLevel(3), Is.EqualTo(6));
            Assert.That(Indicator_Operations.IndicatorPointsAtLevel(5), Is.EqualTo(10));
            Assert.That(Indicator_Operations.IndicatorPointsAtLevel(7), Is.EqualTo(14));

            // Negative levels
            Assert.That(Indicator_Operations.IndicatorPointsAtLevel(-1), Is.EqualTo(-2));
            Assert.That(Indicator_Operations.IndicatorPointsAtLevel(-3), Is.EqualTo(-6));
        }
    }
    
}
