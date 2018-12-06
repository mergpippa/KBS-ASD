using System;

namespace KBS.Infrastructure.Models
{
    public interface ITestConfiguration
    {
        string Name { get; }
        int Frequency { get; }
        int Size { get; }
        DateTime EndingAtUTC { get; }
        int BatchSize { get; }
        string Protocol { get; }
    }
}
