using logic.Dtos;
using logic.Entities;

namespace Logic.Interfaces
{
    public interface IAiService
    {
        List<AiSystem> GetGoogleCloud(string accessToken);
        Task<List<OpenAiModelDto>> GetOpenAI(string apiKey);
    }
}
