using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Classes;
using BusinessLogic.Entities;
using BusinessLogic.Interfaces;

namespace BusinessLogic.Services
{
    public class AIsystemService
    {
        private readonly IAISystemRepository _IaiSystemRepository;
        public AIsystemService(IAISystemRepository iaiSystemRepository)
        {
            _IaiSystemRepository = iaiSystemRepository;
        }

        public List<AISystem> GetAiSystems()
        {

            List<AISystemEntity> aiSystemEntities = _IaiSystemRepository.GetAiSystemsWithProvider();
            List<AISystem> aiSystems = new List<AISystem>();
            foreach (AISystemEntity aiSystem in aiSystemEntities)
            {
                AISystem newAISystem = new AISystem();
                newAISystem.toAISystem(aiSystem);
                aiSystems.Add(newAISystem);
            }
            return aiSystems;
        }

        public AISystem getAISystemById(Guid id)
        {
            AISystemEntity aisystemEntity = _IaiSystemRepository.GetAiSystemById(id);
            AISystem aisystem = new AISystem();
            aisystem.toAISystem(aisystemEntity);
            aisystem.setFiles(aisystemEntity);

            return aisystem;
        }
        public AISystem AddAiSystem(AISystem aiSystem)
        {
            AISystemEntity aiSystemEntity = new AISystemEntity();
            CertificateEntity certificateEntity = new CertificateEntity();
            certificateEntity.Number = aiSystem.certificate.Number;
            certificateEntity.Type = aiSystem.certificate.Type;
        
            ScanCertificateEntity scanCertificateEntity = new ScanCertificateEntity();
            scanCertificateEntity.Filename = aiSystem.certificate.ScanCertificate.Filename;
            scanCertificateEntity.Filepath = string.Empty;
            certificateEntity.ScanCertificate = scanCertificateEntity;
            certificateEntity.ExpiryDate = aiSystem.certificate.ExpiryDate;
            certificateEntity.NameNotifiedBody = aiSystem.certificate.NameNotifiedBody;
            certificateEntity.IdNotifiedBody = aiSystem.certificate.IdNotifiedBody;

            foreach (AISystemFile aiSystemFile in aiSystem.Files)
            {
                AISystemFileEntity aiSystemFileEntity = new AISystemFileEntity();
                aiSystemFileEntity.Filename = aiSystemFile.Filename;
                aiSystemFileEntity.Filetype = aiSystemFile.Filetype;
                aiSystemFileEntity.Filepath = string.Empty;
                aiSystemEntity.FileEntities.Add(aiSystemFileEntity);

            }
            
            aiSystemEntity.Name = aiSystem.Name;
            aiSystemEntity.Status = aiSystem.Status;
            aiSystemEntity.URL = aiSystem.URL;
            aiSystemEntity.TechnicalDocumentationLink = aiSystem.TechnicalDocumentationLink;
            aiSystemEntity.DateAdded = DateOnly.FromDateTime(DateTime.Now);
            aiSystemEntity.ApprovalStatus = 2;
            aiSystemEntity.CertificateEntity = certificateEntity;
            aiSystemEntity.ProviderId = aiSystem.provider.guid;
            
        
            AISystemEntity returnAISystem = _IaiSystemRepository.AddSystemAI(aiSystemEntity);
            aiSystem.Guid = returnAISystem.Id;
            aiSystem.ApprovalStatus = (AIRegisterEnum.ApprovalStatus)returnAISystem.ApprovalStatus;
            aiSystem.DateAdded = returnAISystem.DateAdded;
            return aiSystem;
        }
    }
}
