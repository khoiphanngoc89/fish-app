using NFC.Application.Shared;

namespace NFC.Domain.Entities
{
    /// <summary>
    /// Defines product info.
    /// </summary>
    /// <seealso cref="NFC.Domain.Entities.Product" />
    /// <seealso cref="NFC.Common.Shared.IDomainEntity{System.Int64}" />
    public class ProductInfo : Product, IDomainEntity<long>
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
