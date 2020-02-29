namespace NFC.Application.Shared
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISeoMetadata
    {
        /// <summary>
        /// Gets or sets the seo page title.
        /// </summary>
        /// <value>
        /// The seo page title.
        /// </value>
        string SeoPageTitle { get; set; }

        /// <summary>
        /// Gets or sets the seo alias.
        /// </summary>
        /// <value>
        /// The seo alias.
        /// </value>
        string SeoAlias { get; set; }

        /// <summary>
        /// Gets or sets the seo keywords.
        /// </summary>
        /// <value>
        /// The seo keywords.
        /// </value>
        string SeoKeywords { get; set; }

        /// <summary>
        /// Gets or sets the seo description.
        /// </summary>
        /// <value>
        /// The seo description.
        /// </value>
        string SeoDescription { get; set; }
    }
}