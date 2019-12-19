using NFC.Application.Shared;

namespace NFC.Domain.Entities
{
    /// <summary>
    /// Defines the bill detail.
    /// </summary>
    public class BillDetail : DomainEntity<long>
    {
        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        public long ProductId { get; set; }

        /// <summary>
        /// Gets or sets the quality.
        /// </summary>
        /// <value>
        /// The quality.
        /// </value>
        public int Quality { get; set; }

        public double Price { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is return.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is return; otherwise, <c>false</c>.
        /// </value>
        public bool IsReturn { get; set; }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>
        /// The product.
        /// </value>
        public virtual Product Product { get; set; }

        /// <summary>
        /// Gets or sets the bill.
        /// </summary>
        /// <value>
        /// The bill.
        /// </value>
        public virtual Bill Bill { get; set; }
    }
}
