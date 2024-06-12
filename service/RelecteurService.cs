namespace Conferences_projet.service
{
    using Conferences_projet.Data;
    using Conferences_projet.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class RelecteurService : IRelecteurService
    {
        private readonly ApplicationDbContext _context;

        public RelecteurService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Relecteur>> GetAllRelecteursAsync()
        {
            return await _context.Relecteurs
                .Include(r => r.Affectations)
                .Include(r => r.Evaluations)
                .ToListAsync();
        }

        public async Task<Relecteur> GetRelecteurByIdAsync(int id)
        {
            // Correction de la comparaison : On compare l'ID du relecteur, pas la collection
            return await _context.Relecteurs
                .Include(r => r.Affectations)
                .Include(r => r.Evaluations)
                .FirstOrDefaultAsync(r => r.Id == id); // Utilisation de RelecteurId
        }

        public async Task<Relecteur> CreateRelecteurAsync(Relecteur relecteur)
        {
            _context.Relecteurs.Add(relecteur);
            await _context.SaveChangesAsync();
            return relecteur;
        }

        public async Task UpdateRelecteurAsync(Relecteur relecteur)
        {
            _context.Entry(relecteur).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRelecteurAsync(int id)
        {
            var relecteur = await _context.Relecteurs.FindAsync(id);
            if (relecteur != null)
            {
                _context.Relecteurs.Remove(relecteur);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Relecteur>> SearchRelecteursAsync(string searchTerm)
        {
            return await _context.Relecteurs
                .Where(r => r.Nom.Contains(searchTerm) || r.Prenom.Contains(searchTerm))
                .ToListAsync();
        }

        public async Task<Evaluation> GetEvaluationByIdAsync(int id)
        {
            return await _context.Evaluations
                .Include(e => e.Article)
                .Include(e => e.Relecteur)
                .FirstOrDefaultAsync(e => e.EvaluationId == id);
        }

        public async Task<List<Evaluation>> GetAllEvaluationsAsync()
        {
            return await _context.Evaluations.ToListAsync();
        }

        public async Task<bool> UpdateEvaluationAsync(Evaluation evaluation)
        {
            _context.Entry(evaluation).State = EntityState.Modified;
            var changes = await _context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> DeleteEvaluationAsync(int id)
        {
            var evaluation = await _context.Evaluations.FindAsync(id);
            if (evaluation != null)
            {
                _context.Evaluations.Remove(evaluation);
                var changes = await _context.SaveChangesAsync();
                return changes > 0;
            }
            return false;
        }
    }
}
