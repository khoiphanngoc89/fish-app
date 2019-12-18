using AutoMapper;
using NFC.Common.Utility;
using NFC.Domain.Entities;
using NFC.Infrastructure.Repositories;
using NFC.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFC.Persistence.Services
{
    public interface IProductService : IService<long, ProductDTO>
    {
        IEnumerable<ProductDTO> GetHighlight();
    }

    public class ProductService : ServiceBase, IProductService
    {
        private readonly IProductRepository productRepository;
        public ProductService(IProductRepository productRepository, IMapper mapper) : base(mapper)
        {
            this.productRepository = productRepository;
        }

        public long Add(ProductDTO model)
        {
            return OnServiceExecute(() =>
            {
                var product = this.mapper.Map<ProductDTO, Product>(model);
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

        public IEnumerable<ProductDTO> GetAll()
        {
                var products = this.productRepository.GetAll();
                return products.Select(product => this.mapper.Map<Product, ProductDTO>(product));
        }

        public IEnumerable<ProductDTO> GetAllPaging(int pageNumber = 1, int pageSize = 30, bool getLastest = false)
        {
           
                var products = this.productRepository.GetAllByPaging(pageNumber, pageSize, getLastest);
                return products.Select(product => this.mapper.Map<Product, ProductDTO>(product));
           
        }

        public ProductDTO GetById(long key)
        {
            var product = this.productRepository.GetSingleById(key);
            return this.mapper.Map<Product, ProductDTO>(product);
        }

        public IEnumerable<ProductDTO> GetHighlight()
        {
            var products = this.productRepository.GetHighLight();
            return products.Select(product => this.mapper.Map<Product, ProductDTO>(product));
        }

        public void Update(long key, ProductDTO model)
        {
            OnServiceExecute(() =>
            {
                var original = this.productRepository.GetSingleById(key);
                Preconditions.CheckNull(original, "Product");
                var product = this.mapper.Map<ProductDTO, Product>(model);
                this.productRepository.Update(key, product);
            });
        }
    }
}
