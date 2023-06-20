using Microsoft.EntityFrameworkCore;
using SpringProject.Web.Data;
using SpringProject.Web.Models.Domain;
using SpringProject.Web.Models.ViewModels;

namespace SpringProject.Web.Repositories
{
    public class ProductImageRepository : IProductImageRepository
    {
        private SPDbContext _dbcontext;
        public ProductImageRepository(SPDbContext context)
        {
            _dbcontext = context;
        }
        public async Task<ProductImage> AddAsync(ProductImage image)
        {
            await _dbcontext.ProductImages.AddAsync(image);
            await _dbcontext.SaveChangesAsync();

            return image;
        }

        public async Task<ProductImage?> DeleteAsync(Guid id)
        {
            var foundImage = await _dbcontext.ProductImages.FindAsync(id);

            if (foundImage != null)
            {
                _dbcontext.ProductImages.Remove(foundImage);
                await _dbcontext.SaveChangesAsync();

                return foundImage;
            }

            return null;
        }

        public async Task<IEnumerable<ProductImage>> GetAllAsync()
        {
            return await _dbcontext.ProductImages.ToListAsync();
        }

        public async Task<ProductImage?> GetAsync(Guid id)
        {
            return await _dbcontext.ProductImages.FirstOrDefaultAsync(x => x.ImageId == id);
        }

        public async Task<ProductImage?> UpdateAsync(ProductImage image)
        {
            var foundImage = await _dbcontext.ProductImages.FindAsync(image.ImageId);

            if (foundImage != null) 
            {
                foundImage.ImageTitle = image.ImageTitle;
                foundImage.ImageDescription = image.ImageDescription;
                foundImage.ImageUrl = image.ImageUrl;

                await _dbcontext.SaveChangesAsync();

                return foundImage;
            }

            return null;
        }
    }
}
