using NFC.Application.Shared;
using System;

namespace NFC.Domain.Entities
{
    /// <summary>
    /// Defines application log.
    /// </summary>
    /// <seealso cref="NFC.Application.Shared.IAudiEntity" />
    public class Log : DomainEntity<long>, IAudiEntity
    {
        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public string Content { get; set; }

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
