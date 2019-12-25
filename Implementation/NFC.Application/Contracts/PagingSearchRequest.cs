namespace NFC.Application.Contracts
{
    /// <summary>
    /// Defines the paging search request.
    /// </summary>
    /// <seealso cref="NFC.Application.Contracts.PagingRequest" />
    public class PagingSearchRequest : PagingRequest
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}
