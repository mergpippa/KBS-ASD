using System;

namespace KBS.Infrastructure.Models
{
    public class TestEnviroment : ITestEnviroment
    {
        public string Name { get; set; }

        public string Status { get; set; }

        public DateTime StartTime { get; set; }
    }
}
