namespace Conferences_projet.service
{
    using Conferences_projet.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUniversiteService
    {
        Task<List<Universite>> GetAllUniversitesAsync();
        Task<Universite> GetUniversiteByIdAsync(int id);
        Task<Universite> CreateUniversiteAsync(Universite universite);
        Task UpdateUniversiteAsync(Universite universite);
        Task DeleteUniversiteAsync(int id);
    }

}
