using Conferences_projet.Data;
using Conferences_projet.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conferences_projet.service
{

public class ArticleService : IArticleService
    {
        private readonly ApplicationDbContext _context;

        public ArticleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Article>> GetAllArticlesAsync()
        {
            return await _context.Articles
                .Include(a => a.Auteur)
                .Include(a => a.Conference)
                .Include(a => a.Evaluations)
                .ToListAsync();
        }

        public async Task<Article> GetArticleByIdAsync(int id)
        {
            return await _context.Articles.FindAsync(id);
        }

        public async Task<Article> CreateArticleAsync(Article article)
        {
            _context.Articles.Add(article);
            await _context.SaveChangesAsync();
            return article;
        }

        public async Task UpdateArticleAsync(Article article)
        {
            _context.Entry(article).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteArticleAsync(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            if (article != null)
            {
                _context.Articles.Remove(article);
                await _context.SaveChangesAsync();
            }
        }
    }

}

