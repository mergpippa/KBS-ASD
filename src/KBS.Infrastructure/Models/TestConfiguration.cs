namespace KBS.Infrastructure.Models
{
    public class TestConfiguration : ITestConfiguration
    {
        public string Name { get; }
        public int Frequency { get; }
        public int Size { get; }
        public int TestDuration { get; }
        public int BatchSize { get; }
        public string Protocol { get; }
    }
}
