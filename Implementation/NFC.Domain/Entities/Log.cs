using NFC.Application.Shared;

namespace NFC.Domain.Entities
{
    /// <summary>
    /// Defines application log.
    /// </summary>
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
