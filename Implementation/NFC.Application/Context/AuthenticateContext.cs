using System;
using System.Collections.Generic;
using System.Text;

namespace NFC.Application.Context
{
    /// <summary>
    /// Defines the authentication context.
    /// </summary>
    public class AuthenticateContext
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }
    }
}
