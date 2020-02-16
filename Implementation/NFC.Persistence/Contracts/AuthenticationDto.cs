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
        public string FirstName { get; set; }

        public string LastName { get; set; }

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
