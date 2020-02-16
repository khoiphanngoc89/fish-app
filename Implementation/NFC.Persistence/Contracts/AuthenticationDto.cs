using System;
using System.Collections.Generic;
using System.Text;

namespace NFC.Persistence.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthenticationDto
    {
        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        public string Token { get; set; }
    }
}
