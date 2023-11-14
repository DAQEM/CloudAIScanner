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

    public List<AuthorisedRepresentativesEntity> GetRepresentatives()
    {
        try
        {
            List<AuthorisedRepresentativesEntity> representatives = _context.AuthorisedRepresentatives
                .Include(a => a.Provider)
                .ToList();

            return representatives;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public AuthorisedRepresentativesEntity GetRepresentativeById(Guid id)
    {
        try
        {
            AuthorisedRepresentativesEntity representative = _context.AuthorisedRepresentatives
                .Include(a => a.Provider)
                .Where(a => a.Id == id).First();

            return representative;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public AuthorisedRepresentativesEntity AddRepresentative(AuthorisedRepresentativesEntity representative)
    {
        _context.Add(representative);
        _context.SaveChanges();
        return representative;
    }

    public AuthorisedRepresentativesEntity UpdateRepresentative(AuthorisedRepresentativesEntity representative)
    {
        AuthorisedRepresentativesEntity authorisedRepresentativesEntityEntityToUpdate = _context.AuthorisedRepresentatives.First(p => p.Id == representative.Id);
        if (authorisedRepresentativesEntityEntityToUpdate != null)
        {
            authorisedRepresentativesEntityEntityToUpdate.Name = representative.Name ?? authorisedRepresentativesEntityEntityToUpdate.Name;
            authorisedRepresentativesEntityEntityToUpdate.PhoneNumber = representative.PhoneNumber ?? authorisedRepresentativesEntityEntityToUpdate.PhoneNumber;
            authorisedRepresentativesEntityEntityToUpdate.Email = representative.Email ?? authorisedRepresentativesEntityEntityToUpdate.Email;
        }

        _context.SaveChanges();
        return authorisedRepresentativesEntityEntityToUpdate;
    }

    public void DeleteRepresentative(Guid id)
    {
        AuthorisedRepresentativesEntity representativeToDelete = _context.AuthorisedRepresentatives.First(a => a.Id == id);
        _context.Remove(representativeToDelete);
        _context.SaveChanges();
    }
}