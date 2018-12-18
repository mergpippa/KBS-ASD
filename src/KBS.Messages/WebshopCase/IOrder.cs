namespace KBS.Messages.WebshopCase
{
    /// <summary>
    /// The order message as made by a buyer
    /// </summary>
    public interface IOrder
    {
        /// <summary>
        /// Unique name of the item
        /// </summary>
        string ItemName { get; }

        /// <summary>
        /// Number of ordered items
        /// </summary>
        int Quantity { get; }

        /// <summary>
        /// Bank information from buyer
        /// </summary>
        ITransaction Purchase { get; }
    }
}
