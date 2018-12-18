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
        uint AccountId { get; }

        /// <summary>
        /// Amount to withdraw, negative for a refund
        /// </summary>
        int Withdrawal { get; }
    }
}
