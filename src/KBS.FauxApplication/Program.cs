using System;
using System.Threading;
using System.Threading.Tasks;

namespace KBS.FauxApplication
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            // TODO: Configurable setup
            var fauxApplication = new FauxAppClient();
            var randomizer = new Randomizer(1, 40, 4, 66);

            Task t = new Task((object obj) =>
            {
                Console.WriteLine("Task={0}, obj={1}, Thread={2}",
                Task.CurrentId, obj,
                Thread.CurrentThread.ManagedThreadId);
            }, "test");
            t.Start();

            for (var i = 0; i < 10; i++)
            {
                //fauxApplication.PublishRandomBytes(1048576);
                fauxApplication.PublishLike();
                //Thread.Sleep(randomizer.GetNextNoiseInt());
            }

            Console.Read();
            fauxApplication.StopBusControl();
        }
    }
}
