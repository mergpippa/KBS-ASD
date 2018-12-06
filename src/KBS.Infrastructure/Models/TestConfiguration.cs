using System;

namespace KBS.Infrastructure.Models
{
    public class TestConfiguration : ITestConfiguration
    {
        public string Name { get; set; }
        public int Frequency { get; set; }
        public int Size { get; set; }
        public DateTime EndingAtUTC { get; set; }
        public int BatchSize { get; set; }
        public string Protocol { get; set; }
    }
}
