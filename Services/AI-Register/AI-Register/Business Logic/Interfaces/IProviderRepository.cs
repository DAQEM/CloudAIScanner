using BusinessLogic.Entities;

namespace BusinessLogic.Interfaces;

public interface IProviderRepository
{
    public Task<ProviderEntity> CreateProvider(ProviderEntity providerEntity);

    public Task<ProviderEntity> UpdateProvider(ProviderEntity providerEntity);

    public Task DeleteProvider(Guid id);
    
    public Task<List<ProviderEntity>> GetAllProviderEntities();

    public Task<ProviderEntity> GetProviderById(Guid id);
}