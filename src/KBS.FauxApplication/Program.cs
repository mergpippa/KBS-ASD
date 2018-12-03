using System;
using System.Threading;

namespace KBS.FauxApplication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // TODO: Configurable setup
            FauxApp fauxApp = new FauxApp();

            Randomizer randomizer = new Randomizer(1, 40, 4, 66);

            for (int i = 0; i < 10; i++)
            {
                //fauxApp.PublishRandomBytes(1048576);
                fauxApp.PublishLike();
                Thread.Sleep(randomizer.GetNextNoiseInt());
            }

            Console.Read();
            fauxApp.StopBusControl();
        }
    }
}
