using AutoMapper;
using NFC.Common.Utility;
using NFC.Domain.Entities;
using NFC.Infrastructure.Repositories;
using NFC.Persistence.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace NFC.Persistence.Services
{
    public interface IProductService : IService<long, ProductDto>
    {
        /// <summary>
        /// Gets the highlight.
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProductDto> GetHighlight(int pageNumber = 1, int pageSize = 6, bool getLatest = false);
    }

    public class ProductService : ServiceBase, IProductService
    {
        /// <summary>
        /// The product repository
        /// </summary>
        private readonly IProductRepository productRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class.
        /// </summary>
        /// <param name="productRepository">The product repository.</param>
        /// <param name="mapper">The mapper.</param>
        public ProductService(IProductRepository productRepository, IMapper mapper) : base(mapper)
        {
            this.productRepository = productRepository;
        }

        /// <summary>
        /// Adds the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public long Add(ProductDto model)
        {
            return OnServiceExecute(() =>
            {
                var product = this.mapper.Map<ProductDto, Product>(model);
                return this.productRepository.Add(product);
            });

        }

        /// <summary>
        /// Deletes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        public void Delete(long key)
        {
            OnServiceExecute(() =>
            {
                this.productRepository.Remove(key);
            });
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductDto> GetAll()
        {
            var products = this.productRepository.GetAll();
            return products.Select(product => this.mapper.Map<Product, ProductDto>(product));
        }

        /// <summary>
        /// Gets all paging.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="getLatest">if set to <c>true</c> [get lastest].</param>
        /// <returns></returns>
        public IEnumerable<ProductDto> GetAllPaging(int pageNumber = 1, int pageSize = 30, bool getLatest = false)
        {
            var products = this.productRepository.GetAllByPaging(pageNumber, pageSize, getLatest);
            return products.Select(product => this.mapper.Map<Product, ProductDto>(product));
        }

        /// <summary>
        /// Gets all paging search.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="getLatest">if set to <c>true</c> [get latest].</param>
        /// <returns></returns>
        public IEnumerable<ProductDto> GetAllPagingSearch(string name, int pageNumber = 1, int pageSize = 30, bool getLatest = false)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public ProductDto GetById(long key)
        {
            var product = this.productRepository.GetSingleById(key);
            return this.mapper.Map<Product, ProductDto>(product);
        }

        /// <summary>
        /// Gets the highlight.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductDto> GetHighlight(int pageNumber = 1, int pageSize = 6, bool getLatest = false)
        {
            var products = this.productRepository.GetHighLight(pageNumber, pageSize, getLatest);
            return products.Select(product => this.mapper.Map<Product, ProductDto>(product));
        }

        /// <summary>
        /// Updates the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="model">The model.</param>
        public void Update(long key, ProductDto model)
        {
            OnServiceExecute(() =>
            {
                var original = this.productRepository.GetSingleById(key);
                Preconditions.CheckNull(original, "Product");
                var product = this.mapper.Map<ProductDto, Product>(model);
                this.productRepository.Update(key, product);
            });
        }
    }
}
