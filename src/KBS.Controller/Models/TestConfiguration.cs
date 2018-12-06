using KBS.Infrastructure.Models;

namespace KBS.Controller.Models
{
    public class TestConfiguration : ITestConfiguration
    {
        public int Frequency { get; }
        public int Size { get; }
        public int TestDuration { get; }
        public int BatchSize { get; }
        public string Protocol { get; }
        public string Name { get; }
    }
}
