namespace KBS.Messages.WebshopCase
{
    /// <summary>
    /// Error message topic/interface
    /// </summary>
    public interface ITransactionError
    {
        /// <summary>
        /// Error code for fast checking
        /// </summary>
        short ErrorCode { get; }

        /// <summary>
        /// Explanation of error
        /// </summary>
        string ErrorMessage { get; }
    }
}
