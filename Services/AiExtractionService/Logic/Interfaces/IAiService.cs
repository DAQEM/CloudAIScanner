using logic.Entities;

namespace Logic.Interfaces
{
    public interface IAiService
    {
        List<AiSystem> Get(string accessToken);
    }
}
