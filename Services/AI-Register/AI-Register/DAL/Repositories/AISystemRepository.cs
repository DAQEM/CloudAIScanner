using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Classes;
using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DAL.Repositories
{
    public class AISystemRepository: IAISystemRepository
    {
        private readonly AIRegisterDBContext _context;

        public AISystemRepository(AIRegisterDBContext context)
        {
            _context = context;
        }

        public AISystemEntity GetAiSystemById(Guid id)
        {
            try
            {
                AISystemEntity aisystem = _context.AISystems
                    .Include(a => a.ProviderEntity)
                    .Include(a => a.CertificateEntity)
                    .Include(a => a.CertificateEntity.ScanCertificate)
                    .Include(a => a.FileEntities)
                    .Where(a => a.Id == id).First();

                return aisystem;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
          
   
        }

        public List<AISystemEntity> GetAiSystemsWithProvider()
        {
            try
            {
                List<AISystemEntity> AISystemList = _context.AISystems
                    .Include(a => a.ProviderEntity)
                    .Include(a => a.CertificateEntity)
                    .Include(a => a.CertificateEntity.ScanCertificate)
                    .ToList();

                return AISystemList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
        public AISystemEntity AddSystemAI(AISystemEntity aiSystemEntity)
        {
            _context.Add((aiSystemEntity.CertificateEntity));
            foreach (AISystemFileEntity aiSystemFileEntity in aiSystemEntity.FileEntities)
            {
                _context.Add(aiSystemFileEntity);
            }
            _context.Add(aiSystemEntity);
            _context.SaveChanges();
            return aiSystemEntity;
        }
        public void UpdateAISystem(AISystemEntity aiSystemEntity)
        {
            AISystemEntity aiSystemToUpdate = _context.AISystems.First(a => a.Id == aiSystemEntity.Id);
            if (aiSystemToUpdate != null)
            {
                if (aiSystemEntity.Name != null)
                {
                    aiSystemToUpdate.Name = aiSystemEntity.Name;
                }
                if (aiSystemEntity.Status != null)
                {
                    aiSystemToUpdate.Status = aiSystemEntity.Status;
                }

                if (aiSystemEntity.URL != null)
                {
                    aiSystemToUpdate.URL = aiSystemEntity.URL;
                }
                if(aiSystemEntity.TechnicalDocumentationLink != null)
                {
                    aiSystemToUpdate.TechnicalDocumentationLink = aiSystemEntity.TechnicalDocumentationLink;
                }
                if (aiSystemEntity.ApprovalStatus != null)
                {
                    aiSystemToUpdate.ApprovalStatus = aiSystemEntity.ApprovalStatus;
                }
                if (aiSystemEntity.Description != null)
                {
                    aiSystemToUpdate.Description = aiSystemEntity.Description;
                }
            }
            _context.SaveChanges();
        }
    }
}
