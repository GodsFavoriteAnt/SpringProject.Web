using Microsoft.Identity.Client;
using SpringProject.Web.Models.Domain;

namespace SpringProject.Web.Repositories
{
    public interface IProductImageRepository
    {
        Task<IEnumerable<ProductImage>> GetAllAsync();
        Task<ProductImage?> GetAsync(Guid id);
        Task<ProductImage> AddAsync(ProductImage image);
        Task<ProductImage?> UpdateAsync(ProductImage image);
        Task<ProductImage?> DeleteAsync(Guid id);
    }
}
