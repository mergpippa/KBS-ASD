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
            var likeApp = new LikeAppClient();
            var randomizer = new Randomizer(1, 40, 4, 66);

            LikeAppCounter likeCounter = new LikeAppCounter();

            for (var i = 0; i < 10; i++)
            {
                //likeApp.PublishRandomBytes(1048576);
                likeApp.PublishLike();
                //Thread.Sleep(randomizer.GetNextNoiseInt());
            }

            Console.Read();
            likeApp.StopBusControl();
        }
    }
}
