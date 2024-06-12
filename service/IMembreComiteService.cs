namespace Conferences_projet.service
{
    using Conferences_projet.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMembreComiteService
    {
        Task<IEnumerable<MembreComite>> GetAllMembreComiteMembersAsync();
        Task<MembreComite> GetMembreComiteMemberByIdAsync(int id);
        Task<MembreComite> CreateMembreComiteMemberAsync(MembreComite commiteMember);
        Task UpdateMembreComiteMemberAsync(MembreComite commiteMember);
        Task DeleteMembreComiteMemberAsync(int id);
    }

}
