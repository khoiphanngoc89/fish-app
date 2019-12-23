using NFC.Application.Shared;

namespace NFC.Domain.Entities
{
    /// <summary>
    /// Defines the sub menu.
    /// </summary>
    /// <seealso cref="NFC.Common.Shared.DomainEntity{System.Int32}" />
    public class SubMenu : DomainEntity<int>, IActiveMetadata
    {
        /// <summary>
        /// Gets or sets the parent id.
        /// </summary>
        /// <value>
        /// The parent id.
        /// </value>
        public int ParentId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the url.
        /// </summary>
        /// <value>
        /// The url.
        /// </value>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

    }
}
