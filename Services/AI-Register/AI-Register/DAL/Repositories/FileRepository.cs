using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using Microsoft.EntityFrameworkCore;

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
        AISystemEntity aisystem = await _context.AISystems.Include(a => a.FileEntities).Where(a => a.Id == aiSystemFileEntity.AISystemId).FirstAsync();
        foreach (AISystemFileEntity fileEntity in aisystem.FileEntities)
        {
            if (fileEntity.Filepath == aiSystemFileEntity.Filepath)
            {
                _context.AISystemFiles.Remove(fileEntity);
            }
        }
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
    public async Task<AISystemFileEntity> DeleteAiSystemFile(Guid aiSystemFileId)
    {
        AISystemFileEntity aiSystemFileEntity = await _context.AISystemFiles.FindAsync(aiSystemFileId);
        _context.AISystemFiles.Remove(aiSystemFileEntity);
        await _context.SaveChangesAsync();
        return aiSystemFileEntity;
    }
}