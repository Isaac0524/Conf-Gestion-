namespace Conferences_projet.service
{
    using Conferences_projet.Data;
    using Conferences_projet.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class MembreComiteService : IMembreComiteService
    {
        private readonly ApplicationDbContext _context;

        public MembreComiteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MembreComite>> GetAllMembreComiteMembersAsync()
        {
            return await _context.MembresComite.ToListAsync(); // Utilisez le nom correct ici
        }

        public async Task<MembreComite> GetMembreComiteMemberByIdAsync(int id)
        {
            return await _context.MembresComite.FindAsync(id); // Utilisez le nom correct ici
        }

        public async Task<MembreComite> CreateMembreComiteMemberAsync(MembreComite commiteMember)
        {
            _context.MembresComite.Add(commiteMember); // Utilisez le nom correct ici
            await _context.SaveChangesAsync();
            return commiteMember;
        }

        public async Task UpdateMembreComiteMemberAsync(MembreComite commiteMember)
        {
            _context.Entry(commiteMember).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMembreComiteMemberAsync(int id)
        {
            var commiteMember = await _context.MembresComite.FindAsync(id); // Utilisez le nom correct ici
            if (commiteMember != null)
            {
                _context.MembresComite.Remove(commiteMember); // Utilisez le nom correct ici
                await _context.SaveChangesAsync();
            }
        }
    }
}
