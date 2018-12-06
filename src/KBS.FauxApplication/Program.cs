using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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
                var la = new LikeAppClient(Task.CurrentId);
                for (int i = 0; i < 4; i++)
                    la.PublishLike();
                Thread.Sleep(5000);
                la.StopBusControl();
            }

            List<Task> likers = new List<Task>();

            for (int i = 0; i < 2; i++)
                likers.Add(new Task(seperateLiker));

            likers.ForEach(liker => Console.WriteLine($"Liker [{liker.Id}] status: {liker.Status}"));

            likers.ForEach(liker => liker.Start());

            likers.ForEach(liker => Console.WriteLine($"Liker [{liker.Id}] status: {liker.Status}"));

            Console.WriteLine(">>>>>> Waiting to receive... >>>>>>");
            Console.Read();
            likeCounter.StopBusControl();
        }
    }
}
