using BusinessLogic.Entities;
using BusinessLogic.Interfaces;

namespace DAL.Repositories;

public class FileRepository : IFileRepository
{
    private readonly AIRegisterDBContext _context;

    public FileRepository(AIRegisterDBContext context)
    {
        _context = context;
    }

    public async Task<AISystemFileEntity> AddAiSystemFile(AISystemFileEntity aiSystemFileEntity)
    {
        await _context.AddAsync(aiSystemFileEntity);
        await _context.SaveChangesAsync();
        return aiSystemFileEntity;
    }
}