using BusinessLogic.Entities;

namespace BusinessLogic.Interfaces;

public interface IProviderRepository
{
    public ProviderEntity CreateProvider(ProviderEntity providerEntity);

    public ProviderEntity UpdateProvider(ProviderEntity providerEntity);

    public void DeleteProvider(Guid id);
    
    public List<ProviderEntity> GetAllProviderEntities();

    public ProviderEntity GetProviderById(Guid id);
}