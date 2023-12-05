using System.Diagnostics.CodeAnalysis;
using BusinessLogic.Classes;
using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;

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
    public async Task<AISystemFile> GetAiSystemFile(Guid id)
    {
        AISystemFileEntity aiSystemFileEntity = await _fileRepository.GetAiSystemFile(id);
        return new AISystemFile(aiSystemFileEntity.Id, aiSystemFileEntity.Filepath, aiSystemFileEntity.Filetype);
    }
    public async Task<AISystemFile> DeleteAiSystemFile(Guid aiSystemFileId)
    {
        AISystemFileEntity aiSystemFileEntity = await _fileRepository.DeleteAiSystemFile(aiSystemFileId);
        return new AISystemFile(aiSystemFileEntity.Id, aiSystemFileEntity.Filepath, aiSystemFileEntity.Filetype);
    }
}