using System;

namespace KBS.FauxApplication
{
    public interface Configuration
    {
        int Frequency { get; set; }
         int Size { get; set; }
        int TestDuration { get; set; }
        int BatchSize { get; set; }
        string Protocol { get; set; }
    }
}
