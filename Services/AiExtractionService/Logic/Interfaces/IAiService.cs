using logic.Entities;

namespace Logic.Interfaces
{
    public interface IAiService
    {
        List<AiSystem> GetGoogleCloud(string accessToken);
        Task<List<AiSystem>> GetOpenAI(string accessToken);
    }
}
