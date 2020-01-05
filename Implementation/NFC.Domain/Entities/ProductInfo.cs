namespace NFC.Domain.Entities
{
    /// <summary>
    /// Defines product info.
    /// </summary>
    /// <seealso cref="NFC.Domain.Entities.Product" />
    public class ProductInfo : Product
    {
        /// <summary>
        /// Gets or sets the content of the image.
        /// </summary>
        /// <value>
        /// The content of the image.
        /// </value>
        public string ImageContent { get; set; }
    }
}
