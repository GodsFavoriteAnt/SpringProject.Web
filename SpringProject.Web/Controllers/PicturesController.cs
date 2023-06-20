using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpringProject.Web.Repositories;
using System.Net;

namespace SpringProject.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        private readonly IPictureRepository imageRepository;

        public PicturesController(IPictureRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        [HttpPost]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            var imageUrl = await imageRepository.UploadAsync(file);

            if(imageUrl == null) 
            {
                return Problem("Well, that didn't go as expected.", null, (int)HttpStatusCode.InternalServerError);
            }

            return new JsonResult(new { link = imageUrl });
        }
    }
}
