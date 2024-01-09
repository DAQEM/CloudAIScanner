using Google.Cloud.ServiceUsage.V1;
using logic.Dtos;

namespace Logic.Interfaces
{
    public interface IServiceRepository
    {
        List<Service> GetGoogleCloud(string accessToken);
        Task<List<OpenAiModelDto>> GetOpenAI(string apiKey);
    }
}
