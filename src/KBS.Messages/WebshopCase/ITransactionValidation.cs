namespace KBS.Topics.WebshopCase
{
    /// <summary>
    /// Transaction validation topic/interface
    /// </summary>
    public interface ITransactionValidation : IMessageDiagnostics
    {
        /// <summary>
        /// Bank information from buyer that has now been checked
        /// </summary>
        ITransaction Transaction { get; }

        /// <summary>
        /// Is this transaction valid?
        /// </summary>
        bool IsValid { get; }
    }
}
