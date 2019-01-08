namespace KBS.FauxApplication
{
    internal static class Program
    {
        private static void Main()
        {
            new Benchmark.Benchmark().Run().Wait();
        }
    }
}
