using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NFC.Application.Contracts;
using NFC.Common.Constants;
using NFC.Persistence.Contracts;
using NFC.Persistence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFC.WebAPI.Controllers
{
    public class ProductController : AbstractController
    {
        /// <summary>
        /// The product service
        /// </summary>
        private readonly IProductService productService;

        public ProductController(IMapper mapper, IProductService productService) : base(mapper)
        {
            this.productService = productService;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(ApiConst.All)]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var result = await ExecuteAction(() => this.productService.GetAll());
            return CreatedAtAction(nameof(GetAll), result);
        }

        [HttpGet]
        [Route(ApiConst.All4Home)]
        public async Task<IActionResult> GetHighLight()
        {
            var result = await ExecuteAction(() => this.productService.GetHighlight());
            return CreatedAtAction(nameof(GetHighLight), result);
        }

        /// <summary>
        /// Creates the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        [Route(ApiConst.Create)]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] ProductRequest request)
        {
            var data = this.mapper.Map<ProductRequest, ProductDTO>(request);
            var result = await ExecuteAction(() => this.productService.Add(data));
            return CreatedAtAction(nameof(GetAll), result);
        }

        /// <summary>
        /// Updates the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPut]
        [Authorize]
        [Route(ApiConst.Update)]
        public async Task<IActionResult> Update(long id, [FromBody] ProductRequest request)
        {
            var data = this.mapper.Map<ProductRequest, ProductDTO>(request);
            var result = await ExecuteAction(() => this.productService.Update(id, data));
            return CreatedAtAction(nameof(GetAll), result);
        }

        /// <summary>
        /// Updates the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPut]
        [Authorize]
        [Route(ApiConst.Delete)]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await ExecuteAction(() => this.productService.Delete(id));
            return CreatedAtAction(nameof(GetAll), result);
        }
    }
}
