using System;
using System.Text;
using KBS.Configuration;

namespace KBS.FauxApplication
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var byteArray = Convert.FromBase64String(args[0]);
            var jsonString = Encoding.UTF8.GetString(byteArray);

            Console.WriteLine($"Configuration: {jsonString}");

            BaseConfiguration.SetCommandLineArgsConfiguration(jsonString);

            new Benchmark
                .Benchmark()
                .Run()
                .Wait();
        }
    }
}
