namespace NFC.Application.Contracts
{
    /// <summary>
    /// Defines the paging request.
    /// </summary>
    public class PagingRequest
    {
        /// <summary>
        /// Gets or sets the page number.
        /// </summary>
        /// <value>
        /// The page number.
        /// </value>
        public int PageNumber { get; set; }

        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [get lastest].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [get lastest]; otherwise, <c>false</c>.
        /// </value>
        public bool GetLastest { get; set; }
    }
}
