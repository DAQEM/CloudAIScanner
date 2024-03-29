﻿using BusinessLogic.Classes;
using BusinessLogic.Entities;

namespace BusinessLogic.Interfaces;

public interface IFileRepository
{
    public Task<AISystemFileEntity> AddAiSystemFile(AISystemFileEntity aiSystemFileEntity);
    public Task<AISystemFileEntity> GetAiSystemFile(Guid id);
    public Task<AISystemFileEntity> DeleteAiSystemFile(Guid aiSystemFileId);
}