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
    public class AISystemService
    {
        private readonly IAISystemRepository _IaiSystemRepository;
        public AISystemService(IAISystemRepository iaiSystemRepository)
        {
            _IaiSystemRepository = iaiSystemRepository;
        }

        public List<AISystem> GetAiSystems()
        {

            List<AISystemEntity> aiSystemEntities = _IaiSystemRepository.GetAiSystemsWithProvider();
            List<AISystem> aiSystems = new List<AISystem>();
            foreach (AISystemEntity aiSystem in aiSystemEntities)
            {
                Provider newProvider = new Provider(aiSystem.ProviderEntity.Id, aiSystem.ProviderEntity.Name, aiSystem.ProviderEntity.Address, aiSystem.ProviderEntity.Email, aiSystem.ProviderEntity.PhoneNumber);
                AISystem newAISystem = new AISystem(aiSystem.Id, aiSystem.Name, aiSystem.Status, aiSystem.URL, aiSystem.TechnicalDocumentationLink, (AIRegisterEnum.ApprovalStatus)aiSystem.ApprovalStatus, aiSystem.DateAdded, newProvider, new Certificate(aiSystem.CertificateEntity.Id, aiSystem.CertificateEntity.Type, aiSystem.CertificateEntity.Number, aiSystem.CertificateEntity.ExpiryDate, aiSystem.CertificateEntity.NameNotifiedBody, aiSystem.CertificateEntity.IdNotifiedBody, new ScanCertificate(aiSystem.CertificateEntity.ScanCertificate.Id, aiSystem.CertificateEntity.ScanCertificate.Filename, aiSystem.CertificateEntity.ScanCertificate.Filepath)), aiSystem.Description);
                aiSystems.Add(newAISystem);
            }
            return aiSystems;
        }

        public AISystem getAISystemById(Guid id)
        {
            AISystemEntity aiSystem = _IaiSystemRepository.GetAiSystemById(id);
            Provider provider = new Provider(aiSystem.ProviderEntity.Id, aiSystem.ProviderEntity.Name, aiSystem.ProviderEntity.Address, aiSystem.ProviderEntity.Email, aiSystem.ProviderEntity.PhoneNumber);
            AISystem detailedAiSystem = new AISystem(aiSystem.Id, aiSystem.Name, aiSystem.Status, aiSystem.URL, aiSystem.TechnicalDocumentationLink, (AIRegisterEnum.ApprovalStatus)aiSystem.ApprovalStatus, aiSystem.DateAdded, provider, new Certificate(aiSystem.CertificateEntity.Id, aiSystem.CertificateEntity.Type, aiSystem.CertificateEntity.Number, aiSystem.CertificateEntity.ExpiryDate, aiSystem.CertificateEntity.NameNotifiedBody, aiSystem.CertificateEntity.IdNotifiedBody, new ScanCertificate(aiSystem.CertificateEntity.ScanCertificate.Id, aiSystem.CertificateEntity.ScanCertificate.Filename, aiSystem.CertificateEntity.ScanCertificate.Filepath)), aiSystem.Description);
            detailedAiSystem.setFiles(aiSystem);

            return detailedAiSystem;
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
            aiSystemEntity.Description = aiSystem.Description;
            aiSystemEntity.CertificateEntity = certificateEntity;
            aiSystemEntity.ProviderId = aiSystem.provider.guid;
            
        
            AISystemEntity returnAISystem = _IaiSystemRepository.AddSystemAI(aiSystemEntity);
            aiSystem.Guid = returnAISystem.Id;
            aiSystem.ApprovalStatus = (AIRegisterEnum.ApprovalStatus)returnAISystem.ApprovalStatus;
            aiSystem.DateAdded = returnAISystem.DateAdded;
            return aiSystem;
        }
        public void UpdateAISystem(AISystem aiSystem)
        {
        
            AISystemEntity aiSystemEntity = new AISystemEntity();
            aiSystemEntity.Name = aiSystem.Name;
            aiSystemEntity.Status = aiSystem.Status;
            aiSystemEntity.URL = aiSystem.URL;
            aiSystemEntity.TechnicalDocumentationLink = aiSystem.TechnicalDocumentationLink;
            aiSystemEntity.Description = aiSystem.Description;
            aiSystemEntity.ApprovalStatus = (int)aiSystem.ApprovalStatus;
            aiSystemEntity.Id = aiSystem.Guid;
            _IaiSystemRepository.UpdateAISystem(aiSystemEntity);
        }
    }
}
