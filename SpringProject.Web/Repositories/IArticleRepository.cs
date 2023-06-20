using SpringProject.Web.Models.Domain;

namespace SpringProject.Web.Repositories
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> GetAllAsync();
        Task<Article?> GetAsync(Guid id);
        Task<Article> AddAsync(Article article);
        Task<Article?> UpdateAsync(Article article);
        Task<Article?> DeleteAsync(Guid id);
    }
}
