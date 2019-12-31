using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NFC.Common.Constants;
using NFC.Persistence.Services;
using System.Threading.Tasks;

namespace NFC.WebAPI.Controllers
{
    [ApiController]
    [Route(ApiConst.RootRoute)]
    public class MenuController : AbstractController
    {
        /// <summary>
        /// The mnenu service
        /// </summary>
        private readonly IMenuService mnenuService;


        /// <summary>
        /// Initializes a new instance of the <see cref="MenuController"/> class.
        /// </summary>
        /// <param name="mnenuService">The mnenu service.</param>
        /// <param name="mapper">The mapper.</param>
        public MenuController(IMenuService mnenuService, IMapper mapper) : base(mapper)
        {
            this.mnenuService = mnenuService;
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
            var result = await ExecuteAction(() => this.mnenuService.GetAll());
            return CreatedAtAction(nameof(GetAll), result);
        }
    }
}
