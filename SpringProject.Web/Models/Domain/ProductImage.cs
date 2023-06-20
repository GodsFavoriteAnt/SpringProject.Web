using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpringProject.Web.Models.Domain
{
    public class ProductImage
    {
        [Key]
        public Guid ImageId { get; set; }
        [ForeignKey("ArticleID")]
        public Guid ArticleId { get; set; }
        public string ImageTitle { get; set; }
        public string ImageDescription { get; set; }
        public string? ImageUrl { get; set; }
    }
}
