using NFC.Application.Shared;
using System;

namespace NFC.Application.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="NFC.Application.Shared.IAudiEntity" />
    public class UploadFileRequest : IAudiEntity
    {
        /// <summary>
        /// Gets or sets the content of the file.
        /// </summary>
        /// <value>
        /// The content of the file.
        /// </value>
        public byte[] FileContent { get; set; }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        public string FileName { get; set; }

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
