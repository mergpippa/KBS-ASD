using System;

namespace KBS.Topics
{
    public interface IMessageDiagnostics
    {
        /// <summary>
        /// The id of the message that is being sent
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Test case type used to identify with what test case the message was sent
        /// </summary>
        Type TestCase { get; set; }

        /// <summary>
        /// A filler of byte to increase the size of a message
        /// </summary>
        byte[] Filler { get; }
    }
}
