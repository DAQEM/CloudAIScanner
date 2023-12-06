using BusinessLogic.Classes;
using BusinessLogic.Entities;

namespace BusinessLogic.Interfaces;

public interface IAISystemRepository
{
    public Task<AISystemEntity> AddSystemAI(AISystemEntity aiSystemEntity);
    
    public Task<Pagination<List<AISystemEntity>>> GetAiSystemsWithProvider(int page, int pageSize);

    public Task<List<AISystemEntity>> GetAiSystemEntities();

    public Task<AISystemEntity> GetAiSystemById(Guid id);
    
    public Task<AISystemEntity> UpdateAISystem(AISystemEntity aiSystemEntity);

    public Task DeleteAiSystem(Guid aiSystemId);
}
