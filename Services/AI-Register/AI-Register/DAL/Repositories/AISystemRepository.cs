using BusinessLogic.Entities;
using BusinessLogic.Interfaces;

namespace DAL.Repositories;

public class AISystemRepository: IAISystemRepository
{
    public AIRegisterDBContext context;

    public AISystemRepository(AIRegisterDBContext aiRegisterDbContext)
    {
        context = aiRegisterDbContext;
    }
    public void UpdateAISystem(AISystemEntity aiSystemEntity)
    {
        AISystemEntity aiSystemToUpdate = context.AISystems.Find(aiSystemEntity.Id);
        if (aiSystemToUpdate != null)
        {
            aiSystemToUpdate = aiSystemEntity;
        }
        context.SaveChanges();
    }
}