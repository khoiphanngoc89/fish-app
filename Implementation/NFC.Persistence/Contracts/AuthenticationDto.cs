namespace NFC.Persistence.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthenticationDto
    {
        /// <summary>
        /// 
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// Gets the authencation success
        /// </summary>
        public bool IsAuthentication => string.IsNullOrWhiteSpace(this.FirstName) || string.IsNullOrWhiteSpace(this.LastName);
    }
}
