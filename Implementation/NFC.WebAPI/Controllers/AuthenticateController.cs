using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NFC.Application.Contracts;
using NFC.Common.Constants;
using NFC.Persistence.Services;
using System.Threading.Tasks;

namespace NFC.WebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthenticateController : AbstractController
    {
        private readonly IAuthenticateService authenticateService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authenticateService"></param>
        /// <param name="mapper"></param>
        public AuthenticateController(IAuthenticateService authenticateService, IMapper mapper) : base(mapper)
        {
            this.authenticateService = authenticateService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route(ApiConst.Authenticate)]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateRequest request)
        {
            var result = await ExecuteAction(() => this.authenticateService.Authenticate(request.Email, request.Password));
            return CreatedAtAction(nameof(Authenticate), result);
        }


    }
}
