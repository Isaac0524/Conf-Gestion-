// UniversiteService.cs
using Conferences_projet.Data;
using Conferences_projet.Models;
using Conferences_projet.service;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class UniversiteService : IUniversiteService
{
    private readonly ApplicationDbContext _context;

    public UniversiteService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Universite>> GetAllUniversitesAsync()
    {
        return await _context.Universites.ToListAsync();
    }

    public async Task<Universite> GetUniversiteByIdAsync(int id)
    {
        return await _context.Universites.FindAsync(id);
    }

    public async Task<Universite> CreateUniversiteAsync(Universite universite)
    {
        _context.Universites.Add(universite);
        await _context.SaveChangesAsync();
        return universite;
    }

    public async Task UpdateUniversiteAsync(Universite universite)
    {
        _context.Entry(universite).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUniversiteAsync(int id)
    {
        var universite = await _context.Universites.FindAsync(id);
        if (universite != null)
        {
            _context.Universites.Remove(universite);
            await _context.SaveChangesAsync();
        }
    }
}
