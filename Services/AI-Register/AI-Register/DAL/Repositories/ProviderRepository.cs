using BusinessLogic.Entities;
using BusinessLogic.Interfaces;

namespace DAL.Repositories;

public class ProviderRepository : IProviderRepository
{
    public AIRegisterDBContext Context;

    public ProviderRepository(AIRegisterDBContext aiRegisterDbContext)
    {
        Context = aiRegisterDbContext;
    }

    public ProviderEntity CreateProvider(ProviderEntity providerEntity)
    {
        Context.Add(providerEntity);
        Context.SaveChanges();
        return providerEntity;
    }
}