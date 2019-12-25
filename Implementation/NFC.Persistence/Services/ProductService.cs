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
        IEnumerable<ProductDto> GetHighlight();
    }

    public class ProductService : ServiceBase, IProductService
    {
        private readonly IProductRepository productRepository;
        public ProductService(IProductRepository productRepository, IMapper mapper) : base(mapper)
        {
            this.productRepository = productRepository;
        }

        public long Add(ProductDto model)
        {
            return OnServiceExecute(() =>
            {
                var product = this.mapper.Map<ProductDto, Product>(model);
                return this.productRepository.Add(product);
            });

        }

        public void Delete(long key)
        {
            OnServiceExecute(() =>
            {
                this.productRepository.Remove(key);
            });
        }

        public IEnumerable<ProductDto> GetAll()
        {
            var products = this.productRepository.GetAll();
            return products.Select(product => this.mapper.Map<Product, ProductDto>(product));
        }

        public IEnumerable<ProductDto> GetAllPaging(int pageNumber = 1, int pageSize = 30, bool getLastest = false)
        {
            var products = this.productRepository.GetAllByPaging(pageNumber, pageSize, getLastest);
            return products.Select(product => this.mapper.Map<Product, ProductDto>(product));
        }

        public ProductDto GetById(long key)
        {
            var product = this.productRepository.GetSingleById(key);
            return this.mapper.Map<Product, ProductDto>(product);
        }

        public IEnumerable<ProductDto> GetHighlight()
        {
            var products = this.productRepository.GetHighLight();
            return products.Select(product => this.mapper.Map<Product, ProductDto>(product));
        }

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
