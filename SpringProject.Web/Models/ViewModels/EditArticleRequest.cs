using Microsoft.AspNetCore.Mvc.Rendering;

namespace SpringProject.Web.Models.ViewModels
{
    public class EditArticleRequest
    {
        public Guid ArticleID { get; set; }
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
