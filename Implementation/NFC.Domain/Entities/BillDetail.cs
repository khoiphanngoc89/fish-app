using NFC.Application.Shared;
using System;

namespace NFC.Domain.Entities
{
    /// <summary>
    /// Defines the bill detail.
    /// </summary>
    /// <seealso cref="NFC.Application.Shared.IAudiEntity" />
    public class BillDetail : DomainEntity<long>, IAudiEntity
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

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
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

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>
        /// The creation date.
        /// </value>
        public DateTime? CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the modified date.
        /// </summary>
        /// <value>
        /// The modified date.
        /// </value>
        public DateTime? ModificationDate { get; set; }
    }
}
