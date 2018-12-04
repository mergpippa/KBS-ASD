using System;
using KBS.FauxApplication;

namespace KBS.FauxApplication
{
    public class TestEnviroment: ITestEnviroment
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime StartTime { get; set; }
    }
}
