using Google.Cloud.ServiceUsage.V1;

namespace Logic.Interfaces
{
    public interface IServiceRepository
    {
        List<Service> GetGoogleCloud(string accessToken);
        Task<string> GetOpenAI(string accessToken);
    }
}
