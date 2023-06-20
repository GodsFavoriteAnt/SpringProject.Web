using Microsoft.EntityFrameworkCore;
using SpringProject.Web.Data;
using SpringProject.Web.Models.Domain;

namespace SpringProject.Web.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly SPDbContext context;

        public ArticleRepository(SPDbContext context)
        {
            this.context = context;
        }

        public async Task<Article> AddAsync(Article article)
        {
            await context.AddAsync(article);
            await context.SaveChangesAsync();
            return article;
        }

        public async Task<Article?> DeleteAsync(Guid id)
        {
            var existingArticle = await context.Articles.FindAsync(id);

            if (existingArticle != null) 
            {
                context.Articles.Remove(existingArticle);
                await context.SaveChangesAsync();
                return existingArticle;
            }

            return null;
        }

        public async Task<IEnumerable<Article>> GetAllAsync()
        {
            return await context.Articles.Include(x => x.ProductImages).ToListAsync();
        }

        public async Task<Article?> GetAsync(Guid id)
        {
            return await context.Articles.Include(x => x.ProductImages).FirstOrDefaultAsync(x => x.ArticleID == id);
        }

        public async Task<Article?> UpdateAsync(Article article)
        {
            var existingArticles = await context.Articles.Include(x => x.ProductImages).FirstOrDefaultAsync(x => x.ArticleID ==  article.ArticleID);

            if (existingArticles != null) 
            {
                existingArticles.ArticleID = article.ArticleID;
                existingArticles.ArticleContent = article.ArticleContent;
                existingArticles.ArticleHeading = article.ArticleHeading;
                existingArticles.ArticleTitle = article.ArticleTitle;
                existingArticles.Author = article.Author;
                existingArticles.Summary = article.Summary;
                existingArticles.DatePublished = article.DatePublished;
                existingArticles.Visible = article.Visible;
                existingArticles.ProductImages = article.ProductImages;

                await context.SaveChangesAsync();

                return existingArticles;
            }

            return null;
        }
    }
}
