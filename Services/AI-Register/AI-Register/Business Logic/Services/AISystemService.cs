using BusinessLogic.Classes;
using BusinessLogic.Entities;
using BusinessLogic.Enums;
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

        public Pagination<List<AISystem>> GetAiSystems(int page, int pageSize)
        {

            Pagination<List<AISystemEntity>> aiSystemEntities = _IaiSystemRepository.GetAiSystemsWithProvider(page, pageSize);
            List<AISystem> aiSystems = new List<AISystem>();
            
            foreach (AISystemEntity aiSystem in aiSystemEntities.Data)
            {
                Provider newProvider = new Provider(aiSystem.ProviderEntity.Id, aiSystem.ProviderEntity.Name, aiSystem.ProviderEntity.Address, aiSystem.ProviderEntity.Email, aiSystem.ProviderEntity.PhoneNumber);
                AISystem newAISystem = new AISystem(aiSystem.Id, aiSystem.Name, (AISystemStatus)aiSystem.Status, aiSystem.URL, aiSystem.TechnicalDocumentationLink, (ApprovalStatus)aiSystem.ApprovalStatus, aiSystem.DateAdded, newProvider, new Certificate(aiSystem.CertificateEntity.Id, aiSystem.CertificateEntity.Type, aiSystem.CertificateEntity.Number, aiSystem.CertificateEntity.ExpiryDate, aiSystem.CertificateEntity.NameNotifiedBody, aiSystem.CertificateEntity.IdNotifiedBody, new ScanCertificate(aiSystem.CertificateEntity.ScanCertificate.Id, aiSystem.CertificateEntity.ScanCertificate.Filename, aiSystem.CertificateEntity.ScanCertificate.Filepath)),aiSystem.Description, (MemberStates)aiSystem.MemberState, aiSystem.UnambiguousReference);
                aiSystems.Add(newAISystem);
            }

            return new Pagination<List<AISystem>>
            {
                Data = aiSystems,
                Page = aiSystemEntities.Page,
                PageSize = aiSystemEntities.PageSize,
                TotalPages = aiSystemEntities.TotalPages
            };
        }

        public async Task<AISystem> getAISystemById(Guid id)
        {
            AISystemEntity aiSystem = await _IaiSystemRepository.GetAiSystemById(id);
            Provider provider = new Provider(aiSystem.ProviderEntity.Id, aiSystem.ProviderEntity.Name, aiSystem.ProviderEntity.Address, aiSystem.ProviderEntity.Email, aiSystem.ProviderEntity.PhoneNumber);
            AISystem detailedAiSystem = new AISystem(aiSystem.Id, aiSystem.Name, (AISystemStatus)aiSystem.Status, aiSystem.URL, aiSystem.TechnicalDocumentationLink, (ApprovalStatus)aiSystem.ApprovalStatus, aiSystem.DateAdded, provider, new Certificate(aiSystem.CertificateEntity.Id, aiSystem.CertificateEntity.Type, aiSystem.CertificateEntity.Number, aiSystem.CertificateEntity.ExpiryDate, aiSystem.CertificateEntity.NameNotifiedBody, aiSystem.CertificateEntity.IdNotifiedBody, new ScanCertificate(aiSystem.CertificateEntity.ScanCertificate.Id, aiSystem.CertificateEntity.ScanCertificate.Filename, aiSystem.CertificateEntity.ScanCertificate.Filepath)), aiSystem.Description, (MemberStates)aiSystem.MemberState, aiSystem.UnambiguousReference);
            detailedAiSystem.setFiles(aiSystem);

            return detailedAiSystem;
        }
        public async Task<AISystem> AddAiSystem(AISystem aiSystem)
        {
            AISystemEntity aiSystemEntity = new AISystemEntity()
            {
                Name = aiSystem.Name,
                Status = (int)aiSystem.Status,
                URL = aiSystem.URL,
                TechnicalDocumentationLink = aiSystem.TechnicalDocumentationLink,
                DateAdded = DateOnly.FromDateTime(DateTime.Now),
                ApprovalStatus = 2,
                Description = aiSystem.Description,
                ProviderId = aiSystem.provider.guid,
                MemberState = (int)aiSystem.MemberState,
                UnambiguousReference = aiSystem.UnambiguousReference,
                CertificateEntity = new CertificateEntity()
                {
                    Number = aiSystem.certificate.Number,
                    Type = aiSystem.certificate.Type,
                    ExpiryDate = aiSystem.certificate.ExpiryDate,
                    NameNotifiedBody = aiSystem.certificate.NameNotifiedBody,
                    IdNotifiedBody = aiSystem.certificate.IdNotifiedBody,
                    ScanCertificate = new ScanCertificateEntity()
                    {
                        Filename = aiSystem.certificate.ScanCertificate.Filename,
                        Filepath = string.Empty 
                    }
                    
                }
            };
            foreach (AISystemFile aiSystemFile in aiSystem.Files)
            {
                AISystemFileEntity aiSystemFileEntity = new AISystemFileEntity()
                {
                    Filename = aiSystemFile.Filename,
                    Filetype = aiSystemFile.Filetype,
                    Filepath = string.Empty
                };
                aiSystemEntity.FileEntities.Add(aiSystemFileEntity);

            }
            AISystemEntity returnAISystem = await _IaiSystemRepository.AddSystemAI(aiSystemEntity);
            aiSystem.Guid = returnAISystem.Id;
            aiSystem.ApprovalStatus = (ApprovalStatus)returnAISystem.ApprovalStatus;
            aiSystem.DateAdded = returnAISystem.DateAdded;
            return aiSystem;
        }
        public async Task<AISystem> UpdateAISystem(AISystem aiSystem)
        {

            AISystemEntity aiSystemEntity = new AISystemEntity()
            {
                Name = aiSystem.Name,
                Status = (int)aiSystem.Status,
                URL = aiSystem.URL,
                TechnicalDocumentationLink = aiSystem.TechnicalDocumentationLink,
                Description = aiSystem.Description,
                ApprovalStatus = (int)aiSystem.ApprovalStatus,
                Id = aiSystem.Guid,
                MemberState = (int)aiSystem.MemberState
            };
          
            AISystemEntity returnAiSystemEntity = await _IaiSystemRepository.UpdateAISystem(aiSystemEntity);

            return  new AISystem(returnAiSystemEntity.Id, returnAiSystemEntity.Name, (AISystemStatus)returnAiSystemEntity.Status,
                returnAiSystemEntity.URL, returnAiSystemEntity.Description, returnAiSystemEntity.TechnicalDocumentationLink,
                (ApprovalStatus)returnAiSystemEntity.ApprovalStatus, (MemberStates)returnAiSystemEntity.MemberState);
        }

        public async Task DeleteAiSystem(Guid id)
        {
           await _IaiSystemRepository.DeleteAiSystem(id);
        }
    }
}
