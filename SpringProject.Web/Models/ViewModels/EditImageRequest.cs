namespace SpringProject.Web.Models.ViewModels
{
    public class EditImageRequest
    {
        
        public Guid ImageId { get; set; }
        public string ImageTitle { get; set; }
        public string ImageDescription { get; set; }
        public string? ImageUrl { get; set; }
    }
}
