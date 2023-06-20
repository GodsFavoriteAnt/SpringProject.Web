using Microsoft.AspNetCore.Mvc;
using SpringProject.Web.Models;
using SpringProject.Web.Repositories;
using System.Diagnostics;

namespace SpringProject.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleRepository articleRepository;

        public HomeController(ILogger<HomeController> logger, IArticleRepository articleRepository)
        {
            _logger = logger;
            this.articleRepository = articleRepository;
        }

        public async Task<IActionResult> Index()
        {
            var postedArticles = await articleRepository.GetAllAsync();
            return View(postedArticles);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}