namespace Conferences_projet.service
{
    using Conferences_projet.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEntrepriseService
    {
        Task<List<Entreprise>> GetAllEntreprisesAsync();
        Task<Entreprise> GetEntrepriseByIdAsync(int id);
        Task<Entreprise> CreateEntrepriseAsync(Entreprise entreprise);
        Task UpdateEntrepriseAsync(Entreprise entreprise);
        Task DeleteEntrepriseAsync(int id);
    }

}
