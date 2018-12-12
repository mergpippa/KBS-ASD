namespace KBS.Messages.WebshopCase
{
    /// <summary>
    /// The order message as made by a buyer
    /// </summary>
    public interface IOrder
    {
        string ItemName { get; }

        int Quantity { get; }

        /// <summary>
        /// Bank information from buyer
        /// </summary>
        ITransaction Purchase { get; }
    }
}
