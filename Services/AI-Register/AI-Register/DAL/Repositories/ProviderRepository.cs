using BusinessLogic.Entities;
using BusinessLogic.Interfaces;

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

    public ProviderEntity UpdateProvider(ProviderEntity providerEntity)
    {
        ProviderEntity providerEntityToUpdate = _context.Providers.First(p => p.Id == providerEntity.Id);
        if (providerEntityToUpdate != null)
        {
            providerEntityToUpdate.Name = providerEntity.Name ?? providerEntityToUpdate.Name;
            providerEntityToUpdate.PhoneNumber = providerEntity.PhoneNumber ?? providerEntityToUpdate.PhoneNumber;
            providerEntityToUpdate.Address = providerEntity.Address ?? providerEntityToUpdate.Address;
            providerEntityToUpdate.Email = providerEntity.Email ?? providerEntityToUpdate.Email;
        }

        _context.SaveChanges();
        return providerEntityToUpdate;
    }

    public void DeleteProvider(Guid id)
    {
        ProviderEntity provider = _context.Providers.First(a => a.Id == id);
        _context.Remove(provider);
        _context.SaveChanges();
    }
}