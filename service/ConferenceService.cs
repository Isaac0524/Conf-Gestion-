namespace Conferences_projet.service
{
    using Conferences_projet.Data;
    using Conferences_projet.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ConferenceService : IConferenceService
    {
        
            private readonly ApplicationDbContext _context;

            public ConferenceService(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<List<Conference>> GetAllConferencesAsync()
            {
                return await _context.Conferences.Include(c => c.Articles).ToListAsync();
            }

            public async Task<Conference> GetConferenceByIdAsync(int id)
            {
                return await _context.Conferences.Include(c => c.Articles)
                       .FirstOrDefaultAsync(c => c.ConferenceId == id);
            }

            public async Task CreateConferenceAsync(Conference conference)
            {
                _context.Conferences.Add(conference);
                await _context.SaveChangesAsync();
                
        }

            public async Task UpdateConferenceAsync(Conference conference)
            {
                _context.Entry(conference).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            public async Task DeleteConferenceAsync(int id)
            {
                var conference = await _context.Conferences.FindAsync(id);
                if (conference != null)
                {
                    _context.Conferences.Remove(conference);
                    await _context.SaveChangesAsync();
                }
            }

            public async Task<List<Conference>> SearchConferencesAsync(string searchTerm)
            {
                return await _context.Conferences
                    .Where(c => c.Nom.Contains(searchTerm) ||
                                c.Sigle.Contains(searchTerm) ||
                                c.Theme.Contains(searchTerm))
                    .ToListAsync();
            }
    }
}

