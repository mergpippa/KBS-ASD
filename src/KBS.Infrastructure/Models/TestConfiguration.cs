using System;

namespace KBS.Infrastructure.Models
{
    public struct TestConfiguration
    {
        public string Name { get; set; }
        public int Frequency { get; set; }
        public int Size { get; set; }
        public DateTime EndingAtUTC { get; set; }
        public int BatchSize { get; set; }
    }
}
