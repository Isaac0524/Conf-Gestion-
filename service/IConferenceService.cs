namespace Conferences_projet.service
{
    using Conferences_projet.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IConferenceService
    {
        Task<List<Conference>> GetAllConferencesAsync();
        Task<Conference> GetConferenceByIdAsync(int id);
        Task CreateConferenceAsync(Conference conference);
        Task UpdateConferenceAsync(Conference conference);
        Task DeleteConferenceAsync(int id);
        Task<List<Conference>> SearchConferencesAsync(string searchTerm);
    }

}
