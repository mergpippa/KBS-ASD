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

            void seperateLiker()
            {
                var client = new LikeAppClient();
                for (int i = 0; i < 4; i++)
                    client.PublishLike();
                client.StopBusControl();
            }

            List<Thread> likers = new List<Thread>();

            for (int i = 0; i < 2; i++)
                likers.Add(new Thread(seperateLiker));

            likers.ForEach(liker => Console.WriteLine($"Liker [{liker.ManagedThreadId}] status: {liker.ThreadState}"));

            likers.ForEach(liker => liker.Start());

            likers.ForEach(liker => Console.WriteLine($"Liker [{liker.ManagedThreadId}] status: {liker.ThreadState}"));

            Console.WriteLine(">>>>>> Waiting to receive... >>>>>>");
            Console.Read();
            likeCounter.StopBusControl();
        }
    }
}
