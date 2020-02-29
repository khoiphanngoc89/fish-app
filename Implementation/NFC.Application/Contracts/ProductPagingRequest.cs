namespace NFC.Application.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="NFC.Application.Contracts.PagingRequest" />
    public class ProductPagingRequest : PagingRequest
    {
        /// <summary>
        /// Gets or sets the input.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Input { get; set; }
    }
}
