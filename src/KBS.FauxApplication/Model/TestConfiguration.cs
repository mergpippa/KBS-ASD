using System;

namespace KBS.FauxApplication.Model
{
    public struct TestConfiguration
    {
        public int Frequency { get; set; }

        public int Size { get; set; }

        public int BatchSize { get; set; }

        public string Protocol { get; set; }

        /// <summary>
        /// Time duration of a test case
        /// </summary>
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// Configure whether the test case uses user input, defaults to false
        /// </summary>
        public bool UserInput { get => _userInput ?? false; set => _userInput = value; }

        private bool? _userInput;
    }
}
