using NFC.Application.Shared;

namespace NFC.Persistence.Contracts
{
    public class ProductDTO : DomainEntity<long>, IActiveMetadata, ISeoMetadata
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public double Price { get; set; }

        /// <summary>
        /// Gets or sets the promotion price.
        /// </summary>
        /// <value>
        /// The promotion price.
        /// </value>
        public double PromotionPrice { get; set; }

        /// <summary>
        /// Gets or sets the quality.
        /// </summary>
        /// <value>
        /// The quality.
        /// </value>
        public int Quality { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the seo page title.
        /// </summary>
        /// <value>
        /// The seo page title.
        /// </value>
        public string SeoPageTitle { get; set; }

        /// <summary>
        /// Gets or sets the seo alias.
        /// </summary>
        /// <value>
        /// The seo alias.
        /// </value>
        public string SeoAlias { get; set; }

        /// <summary>
        /// Gets or sets the seo keywords.
        /// </summary>
        /// <value>
        /// The seo keywords.
        /// </value>
        public string SeoKeywords { get; set; }

        /// <summary>
        /// Gets or sets the seo description.
        /// </summary>
        /// <value>
        /// The seo description.
        /// </value>
        public string SeoDescription { get; set; }

        /// <summary>
        /// Gets or sets the image identifier
        /// .</summary>
        /// <value>
        /// The image identifier.
        /// </value>
        public string ImageInfo { get; set; }

        /// <summary>
        /// Gets or sets the category identifier.
        /// </summary>
        /// <value>
        /// The category identifier.
        /// </value>
        public long? CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the product category.
        /// </summary>
        /// <value>
        /// The product category.
        /// </value>
        public ProductCategoryDTO ProductCategory { get; set; }
    }
}
