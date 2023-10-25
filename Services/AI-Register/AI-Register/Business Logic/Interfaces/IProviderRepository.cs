using BusinessLogic.Entities;

namespace BusinessLogic.Interfaces;

public interface IProviderRepository
{
    public void CreateProvider(ProviderEntity providerEntity);
}