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

    public Provider CreateProvider(Provider provider)
    {
        ProviderEntity providerEntity = new()
        {
            Id = provider.guid == Guid.Empty ? Guid.NewGuid() : provider.guid,
            Name = provider.Name,
            Address = provider.Address,
            Email = provider.Email,
            PhoneNumber = provider.PhoneNumber,
        };

        if (provider.AuthorizedRepresentitives.Any())
        {
            provider.AuthorizedRepresentitives.ForEach(authorizedRepresentative =>
            {
                providerEntity.authorisedReperesentitiveEntity.Add(new AuthorisedRepresentativesEntity()
                {
                    Name = authorizedRepresentative.Name,
                    Email = authorizedRepresentative.Email,
                    PhoneNumber = authorizedRepresentative.PhoneNumber,
                    ProviderId = providerEntity.Id
                });
            });
        }
        
        ProviderEntity returnProviderEntity = _providerRepository.CreateProvider(providerEntity);
        provider.guid = returnProviderEntity.Id;
        return provider;
    }

    public void DeleteProvider(Guid id)
    {
        _providerRepository.DeleteProvider(id);
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
        _providerRepository.UpdateProvider(providerEntity);
        Provider _provider = new Provider(providerEntity.Id, providerEntity.Name, providerEntity.Address, providerEntity.Email, providerEntity.PhoneNumber);
        return _provider;
    }

    public List<Provider> GetProviders()
    {
        List<Provider> providers = new List<Provider>();
        List<ProviderEntity> providerEntities = _providerRepository.GetAllProviderEntities();
        foreach (ProviderEntity providerEntity in providerEntities)
        {
            Provider provider = new Provider(providerEntity.Id, providerEntity.Name, providerEntity.Address, providerEntity.Email,
                providerEntity.PhoneNumber);
            providers.Add(provider);
        }

        return providers;
    }

    public Provider GetProviderById(Guid id)
    {
        ProviderEntity providerEntity = _providerRepository.GetProviderById(id);
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