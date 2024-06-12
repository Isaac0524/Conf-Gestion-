namespace Conferences_projet.service
{
    using Conferences_projet.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IArticleService
    {
        public Task<List<Article>> GetAllArticlesAsync();
        public Task<Article> GetArticleByIdAsync(int id);
        public Task<Article> CreateArticleAsync(Article article);
        public Task UpdateArticleAsync(Article article);
        public Task DeleteArticleAsync(int id);
    }

}
