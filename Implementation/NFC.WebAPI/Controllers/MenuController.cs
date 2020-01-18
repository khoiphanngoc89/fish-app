using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NFC.Application.Contracts;
using NFC.Common.Constants;
using NFC.Persistence.Contracts;
using NFC.Persistence.Services;
using System;
using System.IO;
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
        /// <param name="fireBaseService">The fire base service.</param>
        /// <param name="mapper">The mapper.</param>
        public MenuController(IMenuService menuService, IFireBaseService fireBaseService, IMapper mapper) : base(fireBaseService, mapper)
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

        [HttpGet]
        [Route("Upload")]
        [AllowAnonymous]
        public async Task<IActionResult> Upload()
        {


            var request = new UploadFileDto
            {
                FileContent = GetByte(),
                FileName = "NSwitch_DoraemonStoryOfSeasons_03.jpg",
            };
            await firebaseService.UploadFile(request);
            return CreatedAtAction(nameof(GetAll), new { } );

        }

        private byte[] GetByte()
        {
            var filename = @"D:\NSwitch_DoraemonStoryOfSeasons_03.jpg";

            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                // Create a byte array of file stream length
                byte[] bytes = System.IO.File.ReadAllBytes(filename);
                //Read block of bytes from stream into the byte array
                fs.Read(bytes, 0, System.Convert.ToInt32(fs.Length));
                //Close the File Stream
                fs.Close();

                return bytes;
            }
        }
    }
}
