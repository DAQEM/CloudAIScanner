using BusinessLogic.Classes;
using BusinessLogic.Entities;
using BusinessLogic.Enums;
using BusinessLogic.Interfaces;

namespace BusinessLogic.Services;

public class ProviderService
{
    private IProviderRepository _providerRepository;

    public ProviderService(IProviderRepository providerRepository)
    {
        _providerRepository = providerRepository;
    }

    public async Task<Provider> CreateProvider(Provider provider)
    {
        ProviderEntity providerEntity = new()
        {
            Id = provider.guid == Guid.Empty ? Guid.NewGuid() : provider.guid,
            Name = provider.Name,
            Address = provider.Address,
            Email = provider.Email,
            PhoneNumber = provider.PhoneNumber
        };
        
        ProviderEntity returnProviderEntity = await _providerRepository.CreateProvider(providerEntity);
        provider.guid = returnProviderEntity.Id;
        return provider;
    }

    public async Task DeleteProvider(Guid id)
    {
       await _providerRepository.DeleteProvider(id);
    }

    public async Task<Provider> UpdateProvider(Provider provider)
    {
        ProviderEntity providerEntity = new ProviderEntity()
        {
            Name = provider.Name,
            Id = provider.guid,
            Address = provider.Address,
            PhoneNumber = provider.PhoneNumber,
            Email = provider.Email
        };
        await _providerRepository.UpdateProvider(providerEntity);
        Provider _provider = new Provider(providerEntity.Id, providerEntity.Name, providerEntity.Address, providerEntity.Email, providerEntity.PhoneNumber);
        return _provider;
    }

    public async Task<List<Provider>> GetProviders()
    {
        List<Provider> providers = new List<Provider>();
        List<ProviderEntity> providerEntities = await _providerRepository.GetAllProviderEntities();
        foreach (ProviderEntity providerEntity in providerEntities)
        {
            Provider provider = new Provider(providerEntity.Id, providerEntity.Name, providerEntity.Address, providerEntity.Email,
                providerEntity.PhoneNumber);
            providers.Add(provider);
        }

        return providers;
    }

    public async Task<Provider> GetProviderById(Guid id)
    {
        ProviderEntity providerEntity = await _providerRepository.GetProviderById(id);
        Provider provider = new Provider()
        {
            guid = providerEntity.Id,
            Name = providerEntity.Name,
            PhoneNumber = providerEntity.PhoneNumber,
            Address = providerEntity.Address,
            Email = providerEntity.Email
        };
        foreach (AISystemEntity aiSystemEntity in providerEntity.aISystemEntity)
        {
            AISystem aiSystem = new AISystem(aiSystemEntity.Id, aiSystemEntity.Name,
                (AISystemStatus)aiSystemEntity.Status, aiSystemEntity.URL, aiSystemEntity.Description,
                aiSystemEntity.TechnicalDocumentationLink, (ApprovalStatus)aiSystemEntity.ApprovalStatus, aiSystemEntity.DateAdded, (MemberStates)aiSystemEntity.MemberState, aiSystemEntity.UnambiguousReference);
            provider.AISystems.Add(aiSystem);
        }
        return provider;
    }
}