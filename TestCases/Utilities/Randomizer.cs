using System;

namespace KBS.TestCases.Utilities
{
    internal class Randomizer
    {
        /// <summary>
        /// Random number generator
        /// </summary>
        private readonly Random _random;

        /// <summary>
        /// Previously generated noise value, needed to generate next value
        /// </summary>
        private double _noiseValue;

        /// <summary>
        /// The randomizer for generating noise or other random values for simulation
        /// </summary>
        /// <param name="lowerLimit">
        /// Inclusive lower limit of random value
        /// </param>
        /// <param name="upperLimit">
        /// Exclusive upper limit of random value
        /// </param>
        /// <param name="smoothness">
        /// Rate of change in generated noise, higher smoothness means lower rate of change
        /// </param>
        public Randomizer(int lowerLimit, int upperLimit, double smoothness)
        {
            LowerLimit = lowerLimit;
            UpperLimit = upperLimit;
            Smoothness = smoothness;
            _random = new Random();
            _noiseValue = NextDouble;
        }

        /// <summary>
        /// The randomizer for generating noise or other random values for simulation
        /// </summary>
        /// <param name="lowerLimit">
        /// Inclusive lower limit of random value
        /// </param>
        /// <param name="upperLimit">
        /// Exclusive upper limit of random value
        /// </param>
        /// <param name="smoothness">
        /// Rate of change in generated noise, higher smoothness means lower rate of change
        /// </param>
        /// <param name="seed">
        /// Seed for random generator
        /// </param>
        public Randomizer(int lowerLimit, int upperLimit, double smoothness, int seed) : this(lowerLimit, upperLimit, smoothness)
        {
            _random = new Random(seed);
            _noiseValue = NextDouble;
        }

        /// <summary>
        /// Get next noise value within the limits given in the contructor
        /// </summary>
        /// <returns>
        /// Next noise value rounded to an integer
        /// </returns>
        public int GetNextNoiseInt()
        {
            var next = _random.NextDouble() / Smoothness - (0.5 / Smoothness);
            
            if (_noiseValue + next > UpperLimit || _noiseValue + next < LowerLimit)
                _noiseValue -= next;
            else
                _noiseValue += next;
            return (int)_noiseValue;
        }

        /// <summary>
        /// Inclusive lower limit of random value
        /// </summary>
        private int LowerLimit { get; }

        /// <summary>
        /// Exclusive upper limit of random value
        /// </summary>
        private int UpperLimit { get; }

        /// <summary>
        /// Rate of change in generated noise, higher smoothness means lower rate of change
        /// </summary>
        private double Smoothness { get; }

        /// <summary>
        /// Random double within the limits given in the contructor, this is NO noise!
        /// </summary>
        private double NextDouble { get => _random.NextDouble() * (UpperLimit - LowerLimit) + LowerLimit; }
    }
}
