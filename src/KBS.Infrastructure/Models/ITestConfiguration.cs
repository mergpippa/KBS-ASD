namespace KBS.Infrastructure.Models
{
    public interface ITestConfiguration
    {
        string Name { get; }
        int Frequency { get; }
        int Size { get; }
        int TestDuration { get; }
        int BatchSize { get; }
        string Protocol { get; }
    }
}
