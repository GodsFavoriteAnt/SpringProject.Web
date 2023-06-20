using SpringProject.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using SpringProject.Web.Data;
using System.Reflection;
using SpringProject.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;
using SpringProject.Web.Repositories;

namespace SpringProject.Web.Controllers
{
    public class ImagesController : Controller
    {
        public IProductImageRepository imageRepository { get; }

        public ImagesController(IProductImageRepository imagerepository)
        {
            imageRepository = imagerepository;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost, ActionName("Add")]
        public async Task<IActionResult> Add(AddImageRequest addImageRequest)
        {
            var image = new ProductImage
            {
                ImageTitle = addImageRequest.Title,
                ImageDescription = addImageRequest.Description,
                ImageUrl = addImageRequest.ImageUrl
            };

            await imageRepository.AddAsync(image);

            return RedirectToAction("List");
        }
        [HttpGet, ActionName("List")]
        public async Task<IActionResult> List() 
        {
            var images = await imageRepository.GetAllAsync();

            return View(images);
        }
        [HttpGet, ActionName("Edit")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var image = await imageRepository.GetAsync(id);

            if (image != null)
            {
                var editImageRequest = new EditImageRequest
                {
                    ImageId = image.ImageId,
                    ImageTitle = image.ImageTitle,
                    ImageDescription = image.ImageDescription,
                    ImageUrl = image.ImageUrl
                };

                return View(editImageRequest);
            }

            return View(null);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditImageRequest editImageRequest)
        {
            ProductImage image = new ProductImage
            {
                ImageId =editImageRequest.ImageId,
                ImageTitle = editImageRequest.ImageTitle,
                ImageDescription = editImageRequest.ImageDescription,
                ImageUrl = editImageRequest.ImageUrl
            };

            var updatedImage = await imageRepository.UpdateAsync(image);

            if(updatedImage != null) 
            {
                
            }
            else
            {

            }
            return RedirectToAction("Edit", new { id = editImageRequest.ImageId });
        }
        [HttpPost]
        public async Task<IActionResult> Delete(EditImageRequest editImageRequest) 
        { 
            var deletedImage = await imageRepository.DeleteAsync(editImageRequest.ImageId);

            if(deletedImage != null) 
            {
                return RedirectToAction("List");
            }

            return RedirectToAction("Edit", new { id = editImageRequest.ImageId });
        }
    }
}
