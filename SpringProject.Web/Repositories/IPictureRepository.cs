namespace SpringProject.Web.Repositories
{
    public interface IPictureRepository
    {
        Task<string> UploadAsync(IFormFile file);
    }
}
