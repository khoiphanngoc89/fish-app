namespace NFC.Infrastructure.Context
{
    /// <summary>
    /// 
    /// </summary>
    public class PagingContext
    {
        /// <summary>
        /// Gets or sets the page number.
        /// </summary>
        /// <value>
        /// The page number.
        /// </value>
        public int PageNumber { get; set; }

        /// <summary>
        /// Gets or sets the page size.
        /// </summary>
        /// <value>
        /// The page size.
        /// </value>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the get latest.
        /// </summary>
        /// <value>
        /// The get latest.
        /// </value>
        public bool GetLatest { get; set; }
    }
}
