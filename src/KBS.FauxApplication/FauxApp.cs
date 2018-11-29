using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KBS.Messages;
using MassTransit;

namespace KBS.FauxApplication
{
    public class FauxApp : SingleBusControl
    {
        private readonly Random rnd = new Random();

        /// <summary>
        /// Publish an array of random bytes
        /// </summary>
        /// <param name="n">Size of the array to publish</param>
        public Task PublishRandomBytes(uint n)
        {
            byte[] bytes = new byte[n];
            rnd.NextBytes(bytes);
            return BusControl.Publish<IFauxMessage>(new { B = bytes });
        }

        public Task PublishLike() => BusControl.Publish<ILiked>(new { });
    }
}
