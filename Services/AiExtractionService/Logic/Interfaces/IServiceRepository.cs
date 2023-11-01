using Google.Cloud.ServiceUsage.V1;

namespace Logic.Interfaces
{
    public interface IServiceRepository
    {
        List<Service> Get(string accessToken);
    }
}
