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

    public async Task<ProviderEntity> CreateProvider(ProviderEntity providerEntity)
    {
        await _context.AddAsync(providerEntity);
        await _context.SaveChangesAsync();
        return providerEntity;
    }

    public async Task<ProviderEntity> UpdateProvider(ProviderEntity providerEntity)
    {
        ProviderEntity providerEntityToUpdate = await _context.Providers.FirstAsync(p => p.Id == providerEntity.Id);
        if (providerEntityToUpdate != null)
        {
            providerEntityToUpdate.Name = providerEntity.Name ?? providerEntityToUpdate.Name;
            providerEntityToUpdate.PhoneNumber = providerEntity.PhoneNumber ?? providerEntityToUpdate.PhoneNumber;
            providerEntityToUpdate.Address = providerEntity.Address ?? providerEntityToUpdate.Address;
            providerEntityToUpdate.Email = providerEntity.Email ?? providerEntityToUpdate.Email;
        }

        await _context.SaveChangesAsync();
        return providerEntityToUpdate;
    }

    public async Task DeleteProvider(Guid id)
    {
        ProviderEntity provider = _context.Providers.First(a => a.Id == id);
        _context.Remove(provider);
        await _context.SaveChangesAsync();
    }
    
    public async Task<List<ProviderEntity>> GetAllProviderEntities()
    {
        try
        {
            List<ProviderEntity> providerEntities = await _context.Providers.ToListAsync();
            return providerEntities;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public async Task<ProviderEntity> GetProviderById(Guid id)
    {
        try
        {
            ProviderEntity providerEntity = await _context.Providers
                .Include(p => p.aISystemEntity)
                .FirstAsync(p => p.Id == id);
            return providerEntity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}