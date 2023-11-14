using BusinessLogic.Entities;

namespace BusinessLogic.Interfaces;

public interface IRepresentativeRepository
{
    public List<AuthorisedRepresentativesEntity> GetRepresentatives();
    public AuthorisedRepresentativesEntity GetRepresentativeById(Guid id);
    public AuthorisedRepresentativesEntity UpdateRepresentative(AuthorisedRepresentativesEntity authorisedRepresentativesEntity);
    public AuthorisedRepresentativesEntity AddRepresentative(AuthorisedRepresentativesEntity authorisedRepresentativesEntity);
    public void DeleteRepresentative(Guid id);
    
}