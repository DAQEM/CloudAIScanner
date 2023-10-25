using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using Microsoft.EntityFrameworkCore.Query;

namespace DAL.Repositories;

public class AISystemRepository: IAISystemRepository
{
    public AIRegisterDBContext context;

    public AISystemRepository(AIRegisterDBContext aiRegisterDbContext)
    {
        context = aiRegisterDbContext;
    }

    public void AddSystemAI(AISystemEntity aiSystemEntity)
    {
        context.Add((aiSystemEntity.CertificateEntity));
        context.Add(aiSystemEntity);
        context.SaveChanges();
        
    }
}