using System;
using System.Text;
using KBS.Configuration;

namespace KBS.FauxApplication
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var byteArray = Convert.FromBase64String(args[0]);
            var jsonString = Encoding.UTF8.GetString(byteArray);

            BaseConfiguration.SetCommandLineArgsConfiguration(jsonString);

            new Benchmark
                .Benchmark()
                .Run()
                .Wait();
        }
    }

    public class SimpleBenchmarkConfiguration
    {
        public TimeSpan Timeout { get; set; }
    }
}
