using NFC.Domain.Entities;
using NFC.Infrastructure.SharedKernel;

namespace NFC.Infrastructure.Repositories
{
    /// <summary>
    /// Defines the product category repository.
    /// </summary>
    /// <seealso cref="NFC.Infrastructure.SharedKernel.IGenericRepository{System.Int64, NFC.Domain.Entities.Product}" />
    public interface IProductCategoryRepository : IGenericRepository<long, Category>
    { 
    }

    /// <summary>
    /// Provides product repository methods.
    /// </summary>
    /// <seealso cref="NFC.Infrastructure.SharedKernel.GenericRepositoryBase{System.Int64, NFC.Domain.Entities.Category}" />
    /// <seealso cref="IProductCategoryRepository" />
    public class ProductCategoryRepository : GenericRepositoryBase<long, Category>, IProductCategoryRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCategoryRepository"/> class.
        /// </summary>
        /// <param name="repository">The data access object.</param>
        public ProductCategoryRepository(IRepository repository) : base(repository)
        {
        }
    }
}
