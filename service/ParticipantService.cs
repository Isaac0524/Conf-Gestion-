namespace Conferences_projet.service
{
    using Conferences_projet.Data;
    using Conferences_projet.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ParticipantService : IParticipantService
    {
        private readonly ApplicationDbContext _context;

        public ParticipantService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Participant>> GetAllParticipantsAsync()
        {
            return await _context.Participants.ToListAsync();
        }

        public async Task<Participant> GetParticipantByIdAsync(int id)
        {
            return await _context.Participants.FindAsync(id);
        }

        public async Task<Participant> CreateParticipantAsync(Participant participant)
        {
            _context.Participants.Add(participant);
            await _context.SaveChangesAsync();
            return participant;
        }

        public async Task UpdateParticipantAsync(Participant participant)
        {
            _context.Entry(participant).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteParticipantAsync(int id)
        {
            var participant = await _context.Participants.FindAsync(id);
            if (participant != null)
            {
                _context.Participants.Remove(participant);
                await _context.SaveChangesAsync();
            }
        }
    }

}
