using System;

namespace NFC.Application.Shared
{
    /// <summary>
    /// Defines the audi entity.
    /// </summary>
    public interface IAudiEntity
    {
        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>
        /// The creation date.
        /// </value>
        DateTime? CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the modified date.
        /// </summary>
        /// <value>
        /// The modified date.
        /// </value>
        DateTime? ModificationDate { get; set; }
    }
}
