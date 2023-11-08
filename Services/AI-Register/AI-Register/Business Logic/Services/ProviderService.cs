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

    public Provider CreateProvider(Provider provider)
    {
        ProviderEntity providerEntity = new()
        {
            Id = provider.guid == Guid.Empty ? Guid.NewGuid() : provider.guid,
            Name = provider.Name,
            Address = provider.Address,
            Email = provider.Email,
            PhoneNumber = provider.PhoneNumber
        };
        
        ProviderEntity returnProviderEntity = ProviderRepository.CreateProvider(providerEntity);
        provider.guid = returnProviderEntity.Id;
        return provider;
    }

    public void DeleteProvider(Guid id)
    {
        ProviderRepository.DeleteProvider(id);
    }

    public Provider UpdateProvider(Provider provider)
    {
        ProviderEntity providerEntity = new ProviderEntity()
        {
            Name = provider.Name,
            Id = provider.guid,
            Address = provider.Address,
            PhoneNumber = provider.PhoneNumber,
            Email = provider.Email
        };
        ProviderRepository.UpdateProvider(providerEntity);
        Provider _provider = new Provider(providerEntity.Id, providerEntity.Name, providerEntity.Address, providerEntity.Email, providerEntity.PhoneNumber);
        return _provider;
    }
}