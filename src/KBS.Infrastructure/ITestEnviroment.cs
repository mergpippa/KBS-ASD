using System;

namespace KBS.Infrastructure
{
    public interface ITestEnviroment
    {
        string Name { get; set; }
        string Status { get; set; }
        DateTime StartTime { get; set; }
    }
}
