namespace Conferences_projet.service
{
    using Conferences_projet.Data;
    using Conferences_projet.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class AdministrateurService : IAdministrateurService
    {
        private readonly ApplicationDbContext _context;

        public AdministrateurService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Administrateur>> GetAllAdministrateursAsync()
        {
            return await _context.Administrateurs.ToListAsync();
        }

        public async Task<Administrateur> GetAdministrateurByIdAsync(int id)
        {
            return await _context.Administrateurs.FindAsync(id);
        }

        public async Task<Administrateur> CreateAdministrateurAsync(Administrateur administrateur)
        {
            _context.Administrateurs.Add(administrateur);
            await _context.SaveChangesAsync();
            return administrateur;
        }

        public async Task UpdateAdministrateurAsync(Administrateur administrateur)
        {
            _context.Entry(administrateur).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAdministrateurAsync(int id)
        {
            var administrateur = await _context.Administrateurs.FindAsync(id);
            if (administrateur != null)
            {
                _context.Administrateurs.Remove(administrateur);
                await _context.SaveChangesAsync();
            }
        }
    }

}
