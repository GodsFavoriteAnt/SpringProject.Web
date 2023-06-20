using Microsoft.AspNetCore.Mvc;
using SpringProject.Web.Models.ViewModels;
using SpringProject.Web.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using SpringProject.Web.Models.Domain;
using System.Linq.Expressions;

namespace SpringProject.Web.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IProductImageRepository productImageRepository;
        private readonly IArticleRepository articleRepository;

        public ArticlesController(IProductImageRepository productImageRepository, IArticleRepository articleRepository)
        {
            this.productImageRepository = productImageRepository;
            this.articleRepository = articleRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var images = await productImageRepository.GetAllAsync();

            var model = new AddArticleRequest
            {
                ProductImages = images.Select(x => new SelectListItem {Text = x.ImageTitle, Value = x.ImageId.ToString() })
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddArticleRequest request)
        {
            var selectedImages = new List<ProductImage>();

            var article = new Article
            {
                ArticleTitle = request.ArticleTitle,
                ArticleHeading = request.ArticleHeading,
                ArticleContent = request.ArticleContent,
                Summary = request.Summary,
                Author = request.Author,
                Visible = request.Visible,
                DatePublished = request.DatePublished
            };

            foreach (var selectedImageId in request.SelectedImages)
            {
                var selectedImageGuid = Guid.Parse(selectedImageId);
                var selectedImage = await productImageRepository.GetAsync(selectedImageGuid);

                if (selectedImage != null) 
                {
                    selectedImages.Add(selectedImage);
                }
            }

            article.ProductImages = selectedImages;

            await articleRepository.AddAsync(article);

            return RedirectToAction("Add");
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var articles = await articleRepository.GetAllAsync();

            return View(articles);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var article = await articleRepository.GetAsync(id);
            var images = await productImageRepository.GetAllAsync();

            if (article != null)
            {
                var model = new EditArticleRequest
                {
                    ArticleID = article.ArticleID,
                    ArticleTitle = article.ArticleTitle,
                    ArticleHeading = article.ArticleHeading,
                    ArticleContent = article.ArticleContent,
                    Summary = article.Summary,
                    Author = article.Author,
                    Visible = article.Visible,
                    DatePublished = article.DatePublished,
                    ProductImages = images.Select(x => new SelectListItem
                    {
                        Text = x.ImageTitle,
                        Value = x.ImageId.ToString()
                    })
                };

                return View(model);
            }

            return View(null);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditArticleRequest request)
        {
            var article = new Article
            {
                ArticleID = request.ArticleID,
                ArticleTitle = request.ArticleTitle,
                ArticleHeading = request.ArticleHeading,
                ArticleContent = request.ArticleContent,
                Summary = request.Summary,
                Author = request.Author,
                Visible = request.Visible,
                DatePublished = request.DatePublished
            };

            var selectedImages = new List<ProductImage>();
            foreach (var selectedImage in request.SelectedImages)
            {
                if(Guid.TryParse(selectedImage, out var imageId))
                {
                    var foundImage = await productImageRepository.GetAsync(imageId);

                    if(foundImage != null) 
                    {
                        selectedImages.Add(foundImage);
                    }
                }
            }

            article.ProductImages = selectedImages;
            var updatedArticle = await articleRepository.UpdateAsync(article);

            if(updatedArticle != null) 
            {
                return RedirectToAction("Edit");
            }

            return RedirectToAction("Edit");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(EditArticleRequest request)
        {
            var deletedArticle = await articleRepository.DeleteAsync(request.ArticleID);

            if(deletedArticle != null) 
            {
                return RedirectToAction("List");
            }

            return RedirectToAction("Edit", new { id = request.ArticleID });
        }
    }
}
