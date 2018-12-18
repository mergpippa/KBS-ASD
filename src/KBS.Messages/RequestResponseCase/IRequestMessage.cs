namespace KBS.Messages.RequestResponseCase
{
    public interface IRequestMessage
    {
        /// <summary>
        /// Amount of request left to be published
        /// </summary>
        int Count { get; }

        /// <summary>
        /// A filler of byte to increase the size of a message
        /// </summary>
        byte[] Filler { get; }
    }
}
