using KBS.FauxApplication;

namespace KBS.Controller.Models
{
    public class TestConfiguration : ITestConfiguration
    {
        public int Frequency { get; set; }
        public int Size { get; set; }
        public int TestDuration { get; set; }
        public int BatchSize { get; set; }
        public string Protocol { get; set; }
    }
}
