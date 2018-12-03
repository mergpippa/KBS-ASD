using System;
using System.Threading;

namespace KBS.FauxApplication
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            // TODO: Configurable setup
            var fauxApplication = new FauxApp();
            var randomizer = new Randomizer(1, 40, 4, 66);

            for (var i = 0; i < 10; i++)
            {
                //fauxApplication.PublishRandomBytes(1048576);
                fauxApplication.PublishLike();
                Thread.Sleep(randomizer.GetNextNoiseInt());
            }

            Console.Read();
            fauxApplication.StopBusControl();
        }
    }
}
