using Blogging.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Blogging.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("This is a Get Image API Request");
        }

        [HttpPost]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            //call a repository
            var imageUrl = await imageRepository.UploadAsync(file);
            if (imageUrl == null)
            {
                return Problem("Something went wrong!", null, (int)HttpStatusCode.InternalServerError);
            }
            return new JsonResult(new { link = imageUrl });
        }
    }
}
