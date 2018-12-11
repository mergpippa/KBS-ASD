using System.Collections.Generic;

namespace KBS.Messages.WebshopCase
{
    /// <summary>
    /// The order message as made by a buyer
    /// </summary>
    public interface IOrder
    {
        /// <summary>
        /// All items with unique names and quantity
        /// </summary>
        Dictionary<string, int> Items { get; }

        /// <summary>
        /// Bank information from buyer
        /// </summary>
        ITransaction Purchase { get; }
    }
}
