using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class RepresentativeRepository: IRepresentativeRepository
{
    private readonly AIRegisterDBContext _context;

    public RepresentativeRepository(AIRegisterDBContext context)
    {
        _context = context;
    }

    public async Task<List<AuthorisedRepresentativesEntity>> GetRepresentatives()
    {
        try
        {
            List<AuthorisedRepresentativesEntity> representatives = await _context.AuthorisedRepresentatives
                .Include(a => a.Provider)
                .ToListAsync();

            return representatives;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<AuthorisedRepresentativesEntity> GetRepresentativeById(Guid id)
    {
        try
        {
            AuthorisedRepresentativesEntity representative = await _context.AuthorisedRepresentatives
                .Include(a => a.Provider)
                .Where(a => a.Id == id).FirstAsync();

            return representative;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<AuthorisedRepresentativesEntity> AddRepresentative(AuthorisedRepresentativesEntity representative)
    {
        await _context.AddAsync(representative);
        await _context.SaveChangesAsync();
        return representative;
    }

    public async Task<AuthorisedRepresentativesEntity> UpdateRepresentative(AuthorisedRepresentativesEntity representative)
    {
        AuthorisedRepresentativesEntity authorisedRepresentativesEntityEntityToUpdate = await _context.AuthorisedRepresentatives.FirstAsync(p => p.Id == representative.Id);
        if (authorisedRepresentativesEntityEntityToUpdate != null)
        {
            authorisedRepresentativesEntityEntityToUpdate.Name = representative.Name ?? authorisedRepresentativesEntityEntityToUpdate.Name;
            authorisedRepresentativesEntityEntityToUpdate.PhoneNumber = representative.PhoneNumber ?? authorisedRepresentativesEntityEntityToUpdate.PhoneNumber;
            authorisedRepresentativesEntityEntityToUpdate.Email = representative.Email ?? authorisedRepresentativesEntityEntityToUpdate.Email;
        }

        _context.SaveChanges();
        return authorisedRepresentativesEntityEntityToUpdate;
    }

    public async Task DeleteRepresentative(Guid id)
    {
        AuthorisedRepresentativesEntity representativeToDelete = _context.AuthorisedRepresentatives.First(a => a.Id == id);
        _context.Remove(representativeToDelete);
        await _context.SaveChangesAsync();
    }
}