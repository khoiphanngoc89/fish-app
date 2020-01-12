using System;
using System.Collections.Generic;
using System.Text;

namespace NFC.Persistence.Context
{
    public class FireBaseContext
    {
        /// <summary>
        /// Gets or sets the API key.
        /// </summary>
        /// <value>
        /// The API key.
        /// </value>
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets or sets the bucket.
        /// </summary>
        /// <value>
        /// The bucket.
        /// </value>
        public string Bucket { get; set; }

        /// <summary>
        /// Gets or sets the authentication scheme.
        /// </summary>
        /// <value>
        /// The authentication scheme.
        /// </value>
        public string AuthScheme { get; set; }
    }
}
