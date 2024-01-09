using BusinessLogic.Classes;
using BusinessLogic.Entities;
using BusinessLogic.Interfaces;

namespace BusinessLogic.Services;

public class RepresentativeService
{
    private IRepresentativeRepository _authorisedRepresentativeRepository;

    public RepresentativeService(IRepresentativeRepository representativeRepository)
    {
        _authorisedRepresentativeRepository = representativeRepository;
    }
    public async Task<AuthorisedRepresentative> CreateAuthorisedRepresentative(AuthorisedRepresentative authorisedRepresentative)
    {
        AuthorisedRepresentativesEntity authorisedRepresentativesEntity = new AuthorisedRepresentativesEntity()
        {
            Id = authorisedRepresentative.guid == Guid.Empty ? Guid.NewGuid() : authorisedRepresentative.guid,
            Email = authorisedRepresentative.Email,
            Name = authorisedRepresentative.Name,
            PhoneNumber = authorisedRepresentative.PhoneNumber,
            ProviderId = authorisedRepresentative.Provider.guid

        };
        AuthorisedRepresentativesEntity returnAuthorisedRepresentativesEntity = await _authorisedRepresentativeRepository.AddRepresentative(authorisedRepresentativesEntity);
        return new AuthorisedRepresentative(returnAuthorisedRepresentativesEntity.Id,
            returnAuthorisedRepresentativesEntity.Name, returnAuthorisedRepresentativesEntity.Email,
            returnAuthorisedRepresentativesEntity.PhoneNumber);
    }
    public async Task<List<AuthorisedRepresentative>> GetAuthorisedRepresentatives()
    {
        List<AuthorisedRepresentative> authorisedRepresentatives = new List<AuthorisedRepresentative>();
        List<AuthorisedRepresentativesEntity> authorisedRepresentativesEntities = await _authorisedRepresentativeRepository.GetRepresentatives();
        foreach (AuthorisedRepresentativesEntity authorisedRepresentativesEntity in authorisedRepresentativesEntities)
        {
            authorisedRepresentatives.Add(new AuthorisedRepresentative(authorisedRepresentativesEntity.Id,
                authorisedRepresentativesEntity.Name, authorisedRepresentativesEntity.Email,
                authorisedRepresentativesEntity.PhoneNumber));
        }

        return authorisedRepresentatives;
    }
    public async Task<AuthorisedRepresentative> GetAuthorisedRepresentativeById(Guid id)
    {
        AuthorisedRepresentativesEntity authorisedRepresentativesEntity = await _authorisedRepresentativeRepository.GetRepresentativeById(id);
        AuthorisedRepresentative returnAuthorisedRepresentative = new AuthorisedRepresentative(authorisedRepresentativesEntity.Id,
            authorisedRepresentativesEntity.Name, authorisedRepresentativesEntity.Email,
            authorisedRepresentativesEntity.PhoneNumber, new Provider(authorisedRepresentativesEntity.Provider.Id,
                authorisedRepresentativesEntity.Provider.Name, authorisedRepresentativesEntity.Provider.Address,
                authorisedRepresentativesEntity.Provider.Email, authorisedRepresentativesEntity.Provider.PhoneNumber));
        return returnAuthorisedRepresentative;
    }
    public async Task<AuthorisedRepresentative>UpdateAuthorisedRepresentative(AuthorisedRepresentative authorisedRepresentative)
    {
        AuthorisedRepresentativesEntity authorisedRepresentativesEntity = new AuthorisedRepresentativesEntity()
        {
            Id = authorisedRepresentative.guid,
            Email = authorisedRepresentative.Email,
            Name = authorisedRepresentative.Name,
            PhoneNumber = authorisedRepresentative.PhoneNumber
        };
        AuthorisedRepresentativesEntity returnAuthorisedRepresentativesEntity = await _authorisedRepresentativeRepository.UpdateRepresentative(authorisedRepresentativesEntity);
        return new AuthorisedRepresentative(returnAuthorisedRepresentativesEntity.Id,
            returnAuthorisedRepresentativesEntity.Name, returnAuthorisedRepresentativesEntity.Email,
            returnAuthorisedRepresentativesEntity.PhoneNumber);
    }
    public async Task DeleteAuthorisedRepresentative(Guid id)
    {
        await _authorisedRepresentativeRepository.DeleteRepresentative(id);
    }
}