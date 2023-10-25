using Google.Cloud.ServiceUsage.V1;
using logic.Entities;
using Logic.Interfaces;

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
                TradeName = service.Name
            }).ToList();

            return AiSystems;
        }
    }
}
