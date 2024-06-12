namespace Conferences_projet.service
{
    using Conferences_projet.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAuteurService
    {
        Task<IEnumerable<Auteur>> GetAllAuteursAsync();
        Task<Auteur> GetAuteurByIdAsync(int id);
        Task<Auteur> CreateAuteurAsync(Auteur auteur);
        Task UpdateAuteurAsync(Auteur auteur);
        Task DeleteAuteurAsync(int id);
    }

}
