using System.Collections.Generic;

namespace KBS.Messages.WebshopCase
{
    /// <summary>
    /// Complete item list from the webshop, received by buyer
    /// </summary>
    public interface ICatalogueReply
    {
        /// <summary>
        /// String array of all available items
        /// </summary>
        Dictionary<string, int> Catalogue { get; }

        string Text { get; }
    }
}
