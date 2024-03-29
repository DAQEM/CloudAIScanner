﻿using Google.Cloud.ServiceUsage.V1;
using logic.Dtos;
using logic.Entities;
using Logic.Interfaces;
using logic.Models;

namespace Logic.Services
{
    public class AiService : IAiService
    {
        private IServiceRepository _serviceRepository;

        public AiService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public List<AiSystem> GetGoogleCloud(string accessToken)
        {
            List<Service> services = _serviceRepository.GetGoogleCloud(accessToken);

            List<AiSystem> AiSystems = services.Select(service => new AiSystem
            {
                Name = service.Config.Title,
                UnambiguousReference = service.Name,
                Description = service.Config.Documentation.Summary,
                Provider = new AiSystemProvider
                {
                    Guid = Guid.Parse("6147de64-95ee-4040-86e5-a3c0a2b32573")
                },
                Status = AiStatus.InService,
                ApprovalStatus = ApprovalStatus.Pending,
                certificate = new AiSystemCertificate
                {
                    Type = "Example Certificate",
                    Number = 123456789,
                    ExpiryDate = DateTime.Now.AddYears(3),
                    ScanCertificate = new AiSystemScanCertificate
                    {
                        Filename = "example_certificate.pdf",
                        Filepath = "https://example.com/example_certificate.pdf"
                    },
                    IdNotifiedBody = 1,
                    NameNotifiedBody = "Example Notified Body"
                },
                Files = new List<AISystemFile>(),
                DateAdded = DateOnly.FromDateTime(DateTime.Now),
                MemberState = MemberStates.Latvia | MemberStates.Lithuania | MemberStates.Luxembourg | MemberStates.Malta | MemberStates.Netherlands | MemberStates.Poland | MemberStates.Portugal | MemberStates.Romania | MemberStates.Slovakia | MemberStates.Slovenia | MemberStates.Spain | MemberStates.Sweden,
                URL = "https://example.com",
                TechnicalDocumentationLink = "https://example.com/technical_documentation"
            }).ToList();

            return AiSystems;
        }

        public async Task<List<OpenAiModelDto>> GetOpenAI(string apiKey)
        {
            return await _serviceRepository.GetOpenAI(apiKey);
        }
    }
}
