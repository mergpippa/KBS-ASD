using System;
namespace KBS.FauxApplication
{
    public interface ITestEnviroment
    {
        string Name { get; set; }
        string Status { get; set; }
        DateTime StartTime { get; set; }
    }
}
