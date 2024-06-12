using Conferences_projet.Data;
using Conferences_projet.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conferences_projet.service
{
    public class EntrepriseService : IEntrepriseService, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public EntrepriseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Entreprise>> GetAllEntreprisesAsync()
        {
            return await _context.Entreprises.ToListAsync();
        }

        public async Task<Entreprise> GetEntrepriseByIdAsync(int id)
        {
            return await _context.Entreprises.FindAsync(id);
        }

        public async Task<Entreprise> CreateEntrepriseAsync(Entreprise entreprise)
        {
            _context.Entreprises.Add(entreprise);
            await _context.SaveChangesAsync();
            return entreprise;
        }

        public async Task UpdateEntrepriseAsync(Entreprise entreprise)
        {
            _context.Entry(entreprise).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEntrepriseAsync(int id)
        {
            var entreprise = await _context.Entreprises.FindAsync(id);
            if (entreprise != null)
            {
                _context.Entreprises.Remove(entreprise);
                await _context.SaveChangesAsync();
            }
        }

         public void Dispose()
        {
            _context.Dispose();
        }
    }
}
