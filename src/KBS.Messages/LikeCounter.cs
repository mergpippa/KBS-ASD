using System;
using System.Collections.Generic;
using System.Text;

namespace KBS.Messages
{
    /// <summary>
    /// Very temporary example of a simple like counter
    /// </summary>
    public static class ILikeCounter
    {
        private static volatile int likes;
        public static int Likes { get => ++likes; }
    }

    public interface ILiked { }
}
