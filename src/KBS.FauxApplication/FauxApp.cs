using System;
using System.Threading.Tasks;
using KBS.Messages;

namespace KBS.FauxApplication
{
    public class FauxApp : SingleBusControl
    {
        private readonly Random random = new Random();

        /// <summary>
        /// Publish an array of random bytes
        /// </summary>
        /// <param name="arraySize">Size of the array to publish</param>
        public Task PublishRandomBytes(uint arraySize)
        {
            byte[] bytes = new byte[arraySize];
            random.NextBytes(bytes);
            return BusControl.Publish<IFauxMessage>(new { ByteArray = bytes });
        }

        public Task PublishLike() => BusControl.Publish<ILiked>(new { });
    }
}
