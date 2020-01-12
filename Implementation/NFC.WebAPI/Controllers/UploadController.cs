
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NFC.Common.Constants;
using NFC.Persistence.Services;

namespace NFC.WebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="NFC.WebAPI.Controllers.AbstractController" />
    [ApiController]
    [Route(ApiConst.RootRoute)]
    public class UploadController : AbstractController
    {
        /// <summary>
        /// The product service
        /// </summary>
        private readonly IFireBaseService firebaseService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="firebaseService">The fire base service.</param>
        public UploadController(IMapper mapper, IFireBaseService firebaseService) : base(mapper)
        {
            this.firebaseService = firebaseService;
        }
    }
}
