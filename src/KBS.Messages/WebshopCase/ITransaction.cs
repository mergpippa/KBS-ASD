namespace KBS.Messages.WebshopCase
{
    /// <summary>
    /// Bank information from buyer
    /// </summary>
    public interface ITransaction
    {
        /// <summary>
        /// Account ID number
        /// </summary>
        uint AccountID { get; }

        /// <summary>
        /// Amount to withdraw, negative for a refund
        /// </summary>
        int Withdrawal { get; }
    }

    /// <summary>
    /// Transaction validation topic/interface
    /// </summary>
    public interface ITransactionValidation
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
