namespace NFC.Application.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="NFC.Application.Contracts.PagingRequest" />
    public class ProductPagingRequest : PagingRequest
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
