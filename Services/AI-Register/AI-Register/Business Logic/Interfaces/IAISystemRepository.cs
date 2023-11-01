using BusinessLogic.Entities;

namespace BusinessLogic.Interfaces;

public interface IAISystemRepository
{
    public void AddSystemAI(AISystemEntity aiSystemEntity);
    
    public List<AISystemEntity> GetAiSystemsWithProvider();

    public AISystemEntity GetAiSystemById(Guid id);
}
