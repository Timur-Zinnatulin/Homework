using System;

namespace Test_1_Button
{
    /// <summary>
    /// Random position generator
    /// </summary>
    public class PositionRandomizer
    {
        public Random randomizer;

        /// <summary>
        /// Minimal distance from left/top borders
        /// </summary>
        const int minDistance = 12;

        public PositionRandomizer()
        {
            this.randomizer = new Random();
        }

        /// <summary>
        /// Generates a random location
        /// </summary>
        /// <param name="maxDistance">Max distance from left/top border</param>
        /// <returns>New random coordinate</returns>
        public int RandomLocation(int maxDistance)
        {
            return randomizer.Next(minDistance, maxDistance);
        }
    }
}
