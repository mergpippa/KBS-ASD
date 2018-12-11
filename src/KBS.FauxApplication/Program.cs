using System;
using System.Collections.Generic;
using System.Threading;

namespace KBS.FauxApplication
{
    internal static class Program
    {
        public static string KEY;

        private static void Main(string[] args)
        {
            KEY = args[0];

            // TODO: Configurable setup
            var likeCounter = new LikeAppCounter();
            var randomizer = new Randomizer(1, 40, 4, 66);

            void seperateLiker(LikeAppClient client)
            {
                for (int i = 0; i < 4; i++)
                    client.PublishLike();

                Thread.Sleep(5000);

                client.StopBusControl();
            }

            List<Thread> likers = new List<Thread>();

            for (int i = 0; i < 2; i++)
            {
                var c = new LikeAppClient();
                likers.Add(new Thread(() => seperateLiker(c)));
            }

            likers.ForEach(liker => Console.WriteLine($"Liker [{liker.ManagedThreadId}] status: {liker.ThreadState}"));

            Console.WriteLine("<<<<<< Ready to send messages <<<<<<");
            Console.ReadKey();

            likers.ForEach(liker => liker.Start());

            likers.ForEach(liker => Console.WriteLine($"Liker [{liker.ManagedThreadId}] status: {liker.ThreadState}"));

            Console.WriteLine(">>>>>> Waiting to receive... >>>>>>");
            Console.ReadKey();
            likeCounter.StopBusControl();
        }
    }
}
