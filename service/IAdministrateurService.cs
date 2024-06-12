namespace Conferences_projet.service
{
    using Conferences_projet.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAdministrateurService
    {
        Task<IEnumerable<Administrateur>> GetAllAdministrateursAsync();
        Task<Administrateur> GetAdministrateurByIdAsync(int id);
        Task<Administrateur> CreateAdministrateurAsync(Administrateur administrateur);
        Task UpdateAdministrateurAsync(Administrateur administrateur);
        Task DeleteAdministrateurAsync(int id);
    }

}
