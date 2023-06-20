using Microsoft.AspNetCore.Mvc.Rendering;
using SpringProject.Web.Models.Domain;

namespace SpringProject.Web.Models.ViewModels
{
    public class AddArticleRequest
    {
        public string ArticleTitle { get; set; }
        public string ArticleHeading { get; set; }
        public string ArticleContent { get; set; }
        public string Summary { get; set; }
        public string Author { get; set; }
        public bool Visible { get; set; }
        public DateTime DatePublished { get; set; }

        public IEnumerable<SelectListItem> ProductImages { get; set; }
        public string[] SelectedImages { get; set; } = Array.Empty<string>();
    }
}
