using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NFC.Common.Constants;
using NFC.Persistence.Services;
using System.Threading.Tasks;

namespace NFC.WebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="NFC.WebAPI.Controllers.AbstractController" />
    [ApiController]
    [Route(ApiConst.RootRoute)]
    public class MenuController : AbstractController
    {
        /// <summary>
        /// The mnenu service
        /// </summary>
        private readonly IMenuService menuService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuController"/> class.
        /// </summary>
        /// <param name="menuService">The menu service.</param>
        /// <param name="mapper">The mapper.</param>
        public MenuController(IMenuService menuService, IMapper mapper) : base(mapper)
        {
            this.menuService = menuService;
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
            var result = await ExecuteAction(() => this.menuService.GetAll());
            return CreatedAtAction(nameof(GetAll), result);
        }
    }
}
