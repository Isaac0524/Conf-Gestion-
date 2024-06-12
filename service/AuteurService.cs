using Conferences_projet.Data;
using Conferences_projet.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Conferences_projet.service
{
       
public class AuteurService : IAuteurService
    {
        private readonly ApplicationDbContext _context;

        public AuteurService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Auteur>> GetAllAuteursAsync()
        {
            return await _context.Auteurs.ToListAsync();
        }

        public async Task<Auteur> GetAuteurByIdAsync(int id)
        {
            return await _context.Auteurs.FindAsync(id);
        }

        public async Task<Auteur> CreateAuteurAsync(Auteur auteur)
        {
            _context.Auteurs.Add(auteur);
            await _context.SaveChangesAsync();
            return auteur;
        }

        public async Task UpdateAuteurAsync(Auteur auteur)
        {
            _context.Entry(auteur).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAuteurAsync(int id)
        {
            var auteur = await _context.Auteurs.FindAsync(id);
            if (auteur != null)
            {
                _context.Auteurs.Remove(auteur);
                await _context.SaveChangesAsync();
            }
        }
    }

}

