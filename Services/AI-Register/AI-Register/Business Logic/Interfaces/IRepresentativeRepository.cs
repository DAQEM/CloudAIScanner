using BusinessLogic.Entities;

namespace BusinessLogic.Interfaces;

public interface IRepresentativeRepository
{
    public Task<List<AuthorisedRepresentativesEntity>> GetRepresentatives();
    public Task<AuthorisedRepresentativesEntity> GetRepresentativeById(Guid id);
    public Task<AuthorisedRepresentativesEntity> UpdateRepresentative(AuthorisedRepresentativesEntity authorisedRepresentativesEntity);
    public Task<AuthorisedRepresentativesEntity> AddRepresentative(AuthorisedRepresentativesEntity authorisedRepresentativesEntity);
    public Task DeleteRepresentative(Guid id);
    
}