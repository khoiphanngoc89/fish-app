using System;
using System.Collections.Generic;
using System.Text;

namespace NFC.Application.Contracts
{
    public class AuthenticateRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; }
    }
}
