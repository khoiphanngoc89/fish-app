using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NFC.Application.Contracts;
using NFC.Common.Constants;
using NFC.Persistence.Contracts;
using NFC.Persistence.Services;
using System.Threading.Tasks;

namespace NFC.WebAPI.Controllers
{
    [ApiController]
    [Route(ApiConst.RootRoute)]
    public class ProductController : AbstractController
    {
        /// <summary>
        /// The product service
        /// </summary>
        private readonly IProductService productService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="productService">The product service.</param>
        public ProductController(IMapper mapper, IProductService productService) : base(mapper)
        {
            this.productService = productService;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route(ApiConst.All)]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllByPaing([FromBody] ProductPagingRequest request)
        {
            var result = await ExecuteAction(() => this.productService.GetAllPaging(request.PageNumber, request.PageSize, request.GetLastest));
            return CreatedAtAction(nameof(GetAllByPaing), result);
        }

        /// <summary>
        /// Gets the high light.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        [Route(ApiConst.All4Home)]
        public async Task<IActionResult> GetHighLight([FromBody] ProductPagingRequest request)
        {
            var result = await ExecuteAction(() => this.productService.GetHighlight(request.PageNumber, request.PageSize, request.GetLastest));
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
            var data = this.mapper.Map<ProductRequest, ProductDto>(request);
            var result = await ExecuteAction(() => this.productService.Add(data));
            return CreatedAtAction(nameof(Create), result);
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
            var data = this.mapper.Map<ProductRequest, ProductDto>(request);
            var result = await ExecuteAction(() => this.productService.Update(id, data));
            return CreatedAtAction(nameof(Update), result);
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
            return CreatedAtAction(nameof(Delete), result);
        }
    }
}
