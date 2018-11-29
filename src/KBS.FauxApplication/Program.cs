using System;
using System.Threading;
using KBS.Messages;
using MassTransit;

namespace KBS.FauxApplication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            FauxApp fauxApp = new FauxApp();

            for (int i = 0; i < 10; i++)
            {
                fauxApp.PublishRandomBytes(1048576);
                fauxApp.PublishLike();
            }

            Console.Read();
        }
    }
}
