using NFC.Application.Shared;

namespace NFC.Domain.Entities
{
    /// <summary>
    /// Defines the bill.
    /// </summary>
    public class Bill : DomainEntity<long>, IActiveMetadata
    {
        /// <summary>
        /// Gets or sets the bill number.
        /// </summary>
        /// <value>
        /// The bill number.
        /// </value>
        public string BillNumber { get; set; }

        /// <summary>
        /// Gets or sets the member identifier.
        /// </summary>
        /// <value>
        /// The member identifier.
        /// </value>
        public long? MemberId { get; set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>
        /// The total.
        /// </value>
        public double Total { get; set; }

        /// <summary>
        /// Gets or sets the member.
        /// </summary>
        /// <value>
        /// The member.
        /// </value>
        public virtual Member Member { get; set; }

        /// <summary>
        /// Gets or sets the bill detail.
        /// </summary>
        /// <value>
        /// The bill detail.
        /// </value>
        public virtual BillDetail BillDetail { get; set; }

        /// <summary>
        /// Gets or sets the bill detail.
        /// </summary>
        /// <value>
        /// The bill detail.
        /// </value>
        public bool IsActive { get; set; }
    }
}
