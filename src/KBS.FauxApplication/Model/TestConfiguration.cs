using System;

namespace KBS.FauxApplication.Model
{
    public struct TestConfiguration
    {
        public int Frequency { get; set; }

        public int Size { get; set; }

        public int BatchSize { get; set; }

        public string Protocol { get; set; }

        public TimeSpan Duration { get; set; }
    }
}
