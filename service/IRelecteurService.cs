namespace Conferences_projet.service
{
    using Conferences_projet.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    
        public interface IRelecteurService
        {
            Task<List<Relecteur>> GetAllRelecteursAsync();
            Task<List<Relecteur>> SearchRelecteursAsync(string searchTerm);
            Task<Relecteur> GetRelecteurByIdAsync(int id);
            Task<Relecteur> CreateRelecteurAsync(Relecteur relecteur);
            Task UpdateRelecteurAsync(Relecteur relecteur);
            Task DeleteRelecteurAsync(int id);

             Task<Evaluation?> GetEvaluationByIdAsync(int evaluationId);
             Task<bool> UpdateEvaluationAsync(Evaluation evaluation);
             Task<bool> DeleteEvaluationAsync(int evaluationId);
             Task<List<Evaluation>> GetAllEvaluationsAsync();
    }
    

}
