namespace Conferences_projet.service
{
    using Conferences_projet.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IParticipantService
    {
        Task<IEnumerable<Participant>> GetAllParticipantsAsync();
        Task<Participant> GetParticipantByIdAsync(int id);
        Task<Participant> CreateParticipantAsync(Participant participant);
        Task UpdateParticipantAsync(Participant participant);
        Task DeleteParticipantAsync(int id);
    }

}
