namespace NFC.Application.Shared
{
    /// <summary>
    /// Defines active metadata.
    /// </summary>
    public interface IActiveMetadata
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }
    }
}