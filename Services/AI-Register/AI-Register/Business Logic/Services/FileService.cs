using BusinessLogic.Classes;
using BusinessLogic.Entities;
using BusinessLogic.Interfaces;

namespace BusinessLogic.Services;

public class FileService
{
    private IFileRepository _fileRepository;

    public FileService(IFileRepository fileRepository)
    {
        _fileRepository = fileRepository;
    }

    public async Task<AISystemFile> AddAiSystemFile(AISystemFile aiSystemFile, Guid aiSystemId)
    {
        AISystemFileEntity aiSystemFileEntity = new AISystemFileEntity()
        {
            Id = aiSystemFile.guid == Guid.Empty ? Guid.NewGuid() : aiSystemFile.guid,
            Filetype = aiSystemFile.Filetype,
            Filepath = aiSystemFile.Filepath,
            AISystemId = aiSystemId
        };
        AISystemFileEntity returnAiSystemFileEntity = await _fileRepository.AddAiSystemFile(aiSystemFileEntity);
        return new AISystemFile(returnAiSystemFileEntity.Id, returnAiSystemFileEntity.Filepath,
            returnAiSystemFileEntity.Filetype);
    }
}