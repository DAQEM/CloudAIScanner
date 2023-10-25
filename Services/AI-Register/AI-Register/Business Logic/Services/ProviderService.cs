using BusinessLogic.Classes;
using BusinessLogic.Entities;
using BusinessLogic.Interfaces;

namespace BusinessLogic.Services;

public class ProviderService
{
    public IProviderRepository ProviderRepository;

    public ProviderService(IProviderRepository providerRepository)
    {
        ProviderRepository = providerRepository;
    }

    public void CreateProvider(Provider provider)
    {
        ProviderEntity providerEntity = new ProviderEntity();
        providerEntity.Name = provider.Name;
        providerEntity.Address = provider.Address;
        providerEntity.Email = provider.Email;
        providerEntity.PhoneNumber = provider.PhoneNumber;
        ProviderRepository.CreateProvider(providerEntity);
    }
}