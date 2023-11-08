using BusinessLogic.Entities;

namespace BusinessLogic.Interfaces;

public interface IAISystemRepository
{
    public AISystemEntity AddSystemAI(AISystemEntity aiSystemEntity);
    
    public List<AISystemEntity> GetAiSystemsWithProvider();

    public AISystemEntity GetAiSystemById(Guid id);
    
    public AISystemEntity UpdateAISystem(AISystemEntity aiSystemEntity);

    public void DeleteAiSystem(Guid aiSystemId);
}
