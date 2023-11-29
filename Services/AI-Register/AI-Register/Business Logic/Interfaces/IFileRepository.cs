using BusinessLogic.Classes;
using BusinessLogic.Entities;

namespace BusinessLogic.Interfaces;

public interface IFileRepository
{
    public Task<AISystemFileEntity> AddAiSystemFile(AISystemFileEntity aiSystemFileEntity);
}