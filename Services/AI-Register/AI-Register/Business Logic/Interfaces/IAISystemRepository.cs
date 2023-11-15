using BusinessLogic.Entities;

namespace BusinessLogic.Interfaces;

public interface IAISystemRepository
{
    public Task<AISystemEntity> AddSystemAI(AISystemEntity aiSystemEntity);
    
    public Task<List<AISystemEntity>> GetAiSystemsWithProvider();

    public Task<AISystemEntity> GetAiSystemById(Guid id);
    
    public Task<AISystemEntity> UpdateAISystem(AISystemEntity aiSystemEntity);

    public Task DeleteAiSystem(Guid aiSystemId);
}
