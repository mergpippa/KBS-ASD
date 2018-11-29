using System;
using System.Collections.Generic;
using System.Text;

namespace KBS.Messages
{
    /// <summary>
    /// A messages interface of a meaningless message, filled with a byte array
    /// </summary>
    public interface IFauxMessage
    {
        /// <summary>
        /// A byte array used to bloat the message
        /// </summary>
        byte[] B { get; }
    }
}
