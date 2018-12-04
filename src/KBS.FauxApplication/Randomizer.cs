using System;

namespace KBS.FauxApplication
{
    internal class Randomizer
    {
        /// <summary>
        /// Random number generator
        /// </summary>
        private readonly Random random;

        /// <summary>
        /// Previously generated noise value, needed to generate next value
        /// </summary>
        private double noiseValue;

        /// <summary>
        /// The randomizer for generating noise or other random values for simulation
        /// </summary>
        /// <param name="lowerLimt">Inclusive lower limit of random value</param>
        /// <param name="upperLimit">Exclusive upper limit of random value</param>
        /// <param name="smoothness">Rate of change in generated noise, higher smoothness means lower rate of change</param>
        public Randomizer(int lowerLimit, int upperLimit, double smoothness)
        {
            LowerLimit = lowerLimit;
            UpperLimit = upperLimit;
            Smoothness = smoothness;
            random = new Random();
            noiseValue = NextDouble;
        }

        /// <summary>
        /// The randomizer for generating noise or other random values for simulation
        /// </summary>
        /// <param name="lowerLimt">Inclusive lower limit of random value</param>
        /// <param name="upperLimit">Exclusive upper limit of random value</param>
        /// <param name="smoothness">Rate of change in generated noise, higher smoothness means lower rate of change</param>
        /// <param name="seed">Seed for random generator</param>
        public Randomizer(int lowerLimt, int upperLimit, double smoothness, int seed) : this(lowerLimt, upperLimit, smoothness)
        {
            random = new Random(seed);
            noiseValue = NextDouble;
        }

        /// <summary>
        /// Get next noise value within the limits given in the contructor
        /// </summary>
        /// <returns>Next noise value rounded to an integer</returns>
        public int GetNextNoiseInt()
        {
            double next = random.NextDouble() / Smoothness - (0.5 / Smoothness);
            if (noiseValue + next > UpperLimit || noiseValue + next < LowerLimit)
                noiseValue -= next;
            else
                noiseValue += next;
            return (int)noiseValue;
        }

        /// <summary>
        /// Inclusive lower limit of random value
        /// </summary>
        public int LowerLimit { get; }

        /// <summary>
        /// Exclusive upper limit of random value
        /// </summary>
        public int UpperLimit { get; }

        /// <summary>
        /// Rate of change in generated noise, higher smoothness means lower rate of change
        /// </summary>
        public double Smoothness { get; }

        /// <summary>
        /// Random double within the limits given in the contructor, this is NO noise!
        /// </summary>
        private double NextDouble { get => random.NextDouble() * (UpperLimit - LowerLimit) + LowerLimit; }
    }
}
