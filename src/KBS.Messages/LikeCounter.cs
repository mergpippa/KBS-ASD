using System;
using System.Collections.Generic;
using System.Text;

namespace KBS.Messages
{
    public static class ILikeCounter
    {
        private static volatile int likes;
        public static int Likes { get => ++likes; }
    }

    public interface ILiked { }
}
