using KBS.Configuration;

namespace KBS.FauxApplication
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            BaseConfiguration.SetCommandLineArgsConfiguration(args[0]);

            new Benchmark.Benchmark().Run().Wait();
        }
    }
}
