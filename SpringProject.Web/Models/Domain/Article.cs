namespace SpringProject.Web.Models.Domain
{
    public class Article
    {
        public Guid ArticleID { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleHeading { get; set; }
        public string ArticleContent { get; set; }
        public string Summary { get; set; }
        public string Author { get; set; }
        public bool Visible { get; set; }
        public DateTime DatePublished { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
    }
}
