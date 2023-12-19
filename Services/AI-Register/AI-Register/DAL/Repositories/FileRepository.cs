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
        AISystemFileEntity? duplicateFileEntity = await _context.AISystemFiles
            .FirstOrDefaultAsync(f => f.Filepath == aiSystemFileEntity.Filepath);
        if (duplicateFileEntity is not null)
        {
            _context.AISystemFiles.Remove(duplicateFileEntity);
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