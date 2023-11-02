using Google.Cloud.ServiceUsage.V1;
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

        public List<AiSystemModel> Get(string accessToken)
        {
            List<Service> services = _serviceRepository.Get(accessToken);

            List<AiSystemModel> AiSystems = services.Select(service => new AiSystemModel
            {
                UnambiguousReference = service.Name,
                TradeName = service.Config.Title,
                Description = service.Config.Documentation.Summary,
                Provider = new AiSystemProvider
                {
                    Id = 0,
                    Name = "Google",
                    Address = "1600 Amphitheatre Parkway in Mountain View, California",
                    ContactDetails = "https://cloud.google.com/contact"
                },
                AiStatus = AiStatus.InService,
                RegistrationStatus = RegistrationStatus.Pending,
                Representative = new AiSystemRepresentative
                {
                    NameRepresentative = "Google Cloud Employee",
                    AddressRepresentative = "Unknown",
                    ContactDetailsRepresentative = "Unknown"
                }
            }).ToList();

            return AiSystems;
        }
    }
}
