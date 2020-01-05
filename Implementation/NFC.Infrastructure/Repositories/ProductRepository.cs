using NFC.Domain.Entities;
using NFC.Infrastructure.SharedKernel;
using System.Collections.Generic;

namespace NFC.Infrastructure.Repositories
{
    /// <summary>
    /// Defines the product repository.
    /// </summary>
    public interface IProductRepository : IGenericRepository<long, Product>
    {
        /// <summary>
        /// Gets the high light.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Product> GetHighLight();
    }

    /// <summary>
    /// Provides product category repository methods.
    /// </summary>
    /// <seealso cref="IProductRepository" />
    public class ProductRepository : GenericRepositoryBase<long, Product>, IProductRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        /// <param name="repository">The data access object.</param>
        public ProductRepository(IRepository repository) : base(repository)
        {
        }

        /// <summary>
        /// Gets the high light.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetHighLight()
        {
            return this.Select("GetProductHighlight");
        }
    }


}
