using System.Collections.Generic;

namespace KBS.Messages.WebshopCase
{
    /// <summary>
    /// Topic/interface to request the current item list from the webshop
    /// </summary>
    public interface ICatalogueRequest { }

    /// <summary>
    /// Complete item list from the webshop, received by buyer
    /// </summary>
    public interface ICatalogueReply
    {
        /// <summary>
        /// String array of all available items
        /// </summary>
        Dictionary<string, int> Catalog { get; }

        string Text { get; }
    }
}
