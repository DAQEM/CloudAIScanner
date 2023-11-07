using BusinessLogic.Entities;

namespace BusinessLogic.Interfaces;

public interface IProviderRepository
{
    public ProviderEntity CreateProvider(ProviderEntity providerEntity);

    public void DeleteProvider(Guid id);
}