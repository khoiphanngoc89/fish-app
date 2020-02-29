using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using NFC.Application.Contracts;
using NFC.Common.Constants;
using NFC.Persistence.Services;
using System;
using System.Threading.Tasks;

namespace NFC.WebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route(ApiConst.RootRoute)]
    public class IdentityController : AbstractController
    {
        private readonly IAuthenticateService authenticateService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authenticateService"></param>
        /// <param name="mapper"></param>
        public IdentityController(IAuthenticateService authenticateService, IMapper mapper) : base(mapper)
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
        public async Task<IActionResult> Authenticate()
        {

            var request = this.GetLoginInfo();
            var result = await ExecuteAction(() => this.authenticateService.Authenticate(request.Item1, request.Item2));
            return CreatedAtAction(nameof(Authenticate), result);
        }


        private Tuple<string, string> GetLoginInfo()
        {
            Request.Headers.TryGetValue("email", out StringValues email);
            Request.Headers.TryGetValue("pass", out StringValues pass);
            return new Tuple<string, string>(email, pass);
        }

    }
}
