using NFC.Application.Shared;
using NFC.Domain.Entities;
using NFC.Infrastructure.SharedKernel;

namespace NFC.Infrastructure.Repositories
{
    /// <summary>
    /// Defines the product category repository.
    /// </summary>
    public interface IProductCategoryRepository : IGenericRepository<long, Category>
    {
    }

    /// <summary>
    /// Provides product repository methods.
    /// </summary>
    /// <seealso cref="IProductCategoryRepository" />
    public class ProductCategoryRepository : GenericRepositoryBase<long, Category>, IProductCategoryRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCategoryRepository"/> class.
        /// </summary>
        /// <param name="repository">The data access object.</param>
        /// <param name="builder">The builder.</param>
        public ProductCategoryRepository(IRepository repository, IParamsBuilder builder) : base(repository, builder)
        {
        }
    }
}
