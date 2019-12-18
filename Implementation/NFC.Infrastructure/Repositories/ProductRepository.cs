using NFC.Domain.Entities;
using NFC.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace NFC.Infrastructure.Repositories
{
    /// <summary>
    /// Defines the product repository.
    /// </summary>
    /// <seealso cref="NFC.Infrastructure.SharedKernel.IGenericRepository{System.Int64, NFC.Domain.Entities.Product}" />
    public interface IProductRepository : IGenericRepository<long, Product>
    {
        IEnumerable<Product> GetHighLight(int pageNumber = 1, int pageSize = 30, bool getLastest= false);
    }

    /// <summary>
    /// Provides product category repository methods.
    /// </summary>
    /// <seealso cref="NFC.Infrastructure.SharedKernel.GenericRepositoryBase{System.Int64, NFC.Domain.Entities.Product}" />
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

        public IEnumerable<Product> GetHighLight(int pageNumber = 1, int pageSize = 30, bool getLastest = false)
        {
            return this.Select("GetProductHighlight", this.BuildPagingParams(pageNumber, pageSize, getLastest));
        }
    }

    
}
