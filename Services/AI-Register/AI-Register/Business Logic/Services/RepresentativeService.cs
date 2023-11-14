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
    public AuthorisedRepresentative CreateAuthorisedRepresentative(AuthorisedRepresentative authorisedRepresentative)
    {
        AuthorisedRepresentativesEntity authorisedRepresentativesEntity = new AuthorisedRepresentativesEntity()
        {
            Id = authorisedRepresentative.guid == Guid.Empty ? Guid.NewGuid() : authorisedRepresentative.guid,
            Email = authorisedRepresentative.Email,
            Name = authorisedRepresentative.Name,
            PhoneNumber = authorisedRepresentative.PhoneNumber,
            ProviderId = authorisedRepresentative.Provider.guid

        };
        AuthorisedRepresentativesEntity returnAuthorisedRepresentativesEntity = _authorisedRepresentativeRepository.AddRepresentative(authorisedRepresentativesEntity);
        return new AuthorisedRepresentative(returnAuthorisedRepresentativesEntity.Id,
            returnAuthorisedRepresentativesEntity.Name, returnAuthorisedRepresentativesEntity.Email,
            returnAuthorisedRepresentativesEntity.PhoneNumber);
    }
    public List<AuthorisedRepresentative> GetAuthorisedRepresentatives()
    {
        List<AuthorisedRepresentative> authorisedRepresentatives = new List<AuthorisedRepresentative>();
        List<AuthorisedRepresentativesEntity> authorisedRepresentativesEntities = _authorisedRepresentativeRepository.GetRepresentatives();
        foreach (AuthorisedRepresentativesEntity authorisedRepresentativesEntity in authorisedRepresentativesEntities)
        {
            authorisedRepresentatives.Add(new AuthorisedRepresentative(authorisedRepresentativesEntity.Id,
                authorisedRepresentativesEntity.Name, authorisedRepresentativesEntity.Email,
                authorisedRepresentativesEntity.PhoneNumber));
        }

        return authorisedRepresentatives;
    }
    public AuthorisedRepresentative GetAuthorisedRepresentativeById(Guid id)
    {
        AuthorisedRepresentativesEntity authorisedRepresentativesEntity = _authorisedRepresentativeRepository.GetRepresentativeById(id);
        AuthorisedRepresentative returnAuthorisedRepresentative = new AuthorisedRepresentative(authorisedRepresentativesEntity.Id,
            authorisedRepresentativesEntity.Name, authorisedRepresentativesEntity.Email,
            authorisedRepresentativesEntity.PhoneNumber, new Provider(authorisedRepresentativesEntity.Provider.Id,
                authorisedRepresentativesEntity.Provider.Name, authorisedRepresentativesEntity.Provider.Address,
                authorisedRepresentativesEntity.Provider.Email, authorisedRepresentativesEntity.Provider.PhoneNumber));
        return returnAuthorisedRepresentative;
    }
    public AuthorisedRepresentative UpdateAuthorisedRepresentative(AuthorisedRepresentative authorisedRepresentative)
    {
        AuthorisedRepresentativesEntity authorisedRepresentativesEntity = new AuthorisedRepresentativesEntity()
        {
            Id = authorisedRepresentative.guid,
            Email = authorisedRepresentative.Email,
            Name = authorisedRepresentative.Name,
            PhoneNumber = authorisedRepresentative.PhoneNumber
        };
        AuthorisedRepresentativesEntity returnAuthorisedRepresentativesEntity = _authorisedRepresentativeRepository.UpdateRepresentative(authorisedRepresentativesEntity);
        return new AuthorisedRepresentative(returnAuthorisedRepresentativesEntity.Id,
            returnAuthorisedRepresentativesEntity.Name, returnAuthorisedRepresentativesEntity.Email,
            returnAuthorisedRepresentativesEntity.PhoneNumber);
    }
    public void DeleteAuthorisedRepresentative(Guid id)
    {
        _authorisedRepresentativeRepository.DeleteRepresentative(id);
    }
}