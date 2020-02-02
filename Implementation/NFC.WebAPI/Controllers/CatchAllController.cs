using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NFC.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFC.WebAPI.Controllers
{
    [ApiController]
    [Route(ApiConst.RootRoute)]
    public class CatchAllController : AbstractController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        public CatchAllController(IMapper mapper) : base(mapper)
        {
        }
    }
}
