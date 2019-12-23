using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NFC.Common.Constants;
using NFC.Persistence.Services;
using System.Threading.Tasks;

namespace NFC.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : AbstractController
    {
        private readonly IMenuService mnenuService;

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
