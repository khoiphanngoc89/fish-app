using NFC.Application.Shared;

namespace NFC.Domain.Entities
{
    /// <summary>
    /// Defines application log.
    /// </summary>
    /// <seealso cref="NFC.Common.Shared.DomainEntity{System.Int64}" />
    public class Log : DomainEntity<long>
    {
        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public string Content { get; set; }
    }
}
