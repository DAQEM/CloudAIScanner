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
    public async Task<AISystemFileEntity> GetAiSystemFile(Guid id)
    {
        try
        {
            return await _context.AISystemFiles.FindAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}