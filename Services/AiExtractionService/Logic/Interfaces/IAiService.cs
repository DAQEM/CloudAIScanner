using logic.Entities;

namespace Logic.Interfaces
{
    public interface IAiService
    {
        List<AiSystemModel> Get(string accessToken);
    }
}
