using BusinessLogic.Classes;
using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class AISystemRepository: IAISystemRepository
    {
        private readonly AIRegisterDBContext _context;

        public AISystemRepository(AIRegisterDBContext context)
        {
            _context = context;
        }

        public async Task<AISystemEntity> GetAiSystemById(Guid id)
        {
            try
            {
                AISystemEntity aisystem = await _context.AISystems
                    .Include(a => a.ProviderEntity)
                    .Include(a => a.CertificateEntity)
                    .Include(a => a.CertificateEntity.ScanCertificate)
                    .Include(a => a.FileEntities)
                    .Where(a => a.Id == id).FirstAsync();

                return aisystem;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public async Task<Pagination<List<AISystemEntity>>> GetAiSystemsWithProvider(int page, int pageSize)
        {
            try
            {
                var AISystemList = await GetAiSystemEntities();
                var PaginationAiSystemList = AISystemList
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize).ToList();

                int totalAiSystems = await _context.AISystems.CountAsync();
                
                return new Pagination<List<AISystemEntity>> {
                    Data = PaginationAiSystemList, 
                    Page = page, 
                    PageSize = pageSize, 
                    TotalPages = (int) Math.Ceiling((double)totalAiSystems / pageSize)
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<AISystemEntity>> GetAiSystemEntities()
        {
            try
            {
                List<AISystemEntity> AISystemList = await _context.AISystems
                    .Include(a => a.ProviderEntity)
                    .Include(a => a.CertificateEntity)
                    .Include(a => a.CertificateEntity.ScanCertificate)
                    .ToListAsync();
                return AISystemList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<AISystemEntity> AddSystemAI(AISystemEntity aiSystemEntity)
        {
            _context.Add((aiSystemEntity.CertificateEntity));
            foreach (AISystemFileEntity aiSystemFileEntity in aiSystemEntity.FileEntities)
            {
                _context.Add(aiSystemFileEntity);
            }
            _context.Add(aiSystemEntity);
           await _context.SaveChangesAsync();
            return aiSystemEntity;
        }
        public async Task<AISystemEntity> UpdateAISystem(AISystemEntity aiSystemEntity)
        {
            AISystemEntity aiSystemToUpdate = await _context.AISystems.FirstAsync(a => a.Id == aiSystemEntity.Id);
            if (aiSystemToUpdate != null)
            {
                
                aiSystemToUpdate.Name = aiSystemEntity.Name ?? aiSystemToUpdate.Name;
                
                aiSystemToUpdate.URL = aiSystemEntity.URL ?? aiSystemToUpdate.URL;
                
                aiSystemToUpdate.TechnicalDocumentationLink = aiSystemEntity.TechnicalDocumentationLink ?? aiSystemToUpdate.TechnicalDocumentationLink;
                
                aiSystemToUpdate.Description = aiSystemEntity.Description ?? aiSystemToUpdate.Description;

                if (aiSystemEntity.MemberState != 0)
                {
                    aiSystemToUpdate.MemberState = aiSystemEntity.MemberState;
                    
                }
                if (aiSystemEntity.ApprovalStatus != 0)
                {
                    aiSystemToUpdate.ApprovalStatus = aiSystemEntity.ApprovalStatus;}
                if (aiSystemEntity.Status != 0)
                {
                    aiSystemToUpdate.Status = aiSystemEntity.Status;
                }
            }
            _context.SaveChanges();
            return aiSystemToUpdate;
        }

        public Task DeleteAiSystem(Guid aiSystemId)
        {
           AISystemEntity aisystem = _context.AISystems.First(a => a.Id == aiSystemId);
           _context.Remove(aisystem);
           _context.SaveChanges();
           return Task.CompletedTask;
        }
    }
}