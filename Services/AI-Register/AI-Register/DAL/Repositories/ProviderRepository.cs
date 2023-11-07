using BusinessLogic.Classes;
using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class ProviderRepository : IProviderRepository
{
    private AIRegisterDBContext _context;

    public ProviderRepository(AIRegisterDBContext aiRegisterDbContext)
    {
        _context = aiRegisterDbContext;
    }

    public ProviderEntity CreateProvider(ProviderEntity providerEntity)
    {
        _context.Add(providerEntity);
        _context.SaveChanges();
        return providerEntity;
    }

    public void DeleteProvider(Guid id)
    {
        ProviderEntity provider = _context.Providers.First(a => a.Id == id);
        _context.Remove(provider);
        _context.SaveChanges();
    }
}