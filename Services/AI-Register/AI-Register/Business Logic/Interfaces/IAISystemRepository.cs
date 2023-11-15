using BusinessLogic.Classes;
using BusinessLogic.Entities;

namespace BusinessLogic.Interfaces;

public interface IAISystemRepository
{
    public AISystemEntity AddSystemAI(AISystemEntity aiSystemEntity);
    
    public Pagination<List<AISystemEntity>> GetAiSystemsWithProvider(int page, int pageSize);

    public AISystemEntity GetAiSystemById(Guid id);
    
    public AISystemEntity UpdateAISystem(AISystemEntity aiSystemEntity);

    public void DeleteAiSystem(Guid aiSystemId);
}
