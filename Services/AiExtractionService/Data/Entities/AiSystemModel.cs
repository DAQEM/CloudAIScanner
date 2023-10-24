using Data.Models;

namespace Data.Entities;

public class AiSystemModel
{
    public string TradeName { get; set; } = "";
    public string UnambiguousReference { get; set; } = "";
    public string Description { get; set; } = "";
    public AiSystemProvider Provider { get; set; } = new();
    public AiSystemRepresentative? Representative { get; set; } = new();
    public AiStatus AiStatus { get; set; } = AiStatus.OnTheMarket | AiStatus.InService;
    public RegistrationStatus RegistrationStatus { get; set; } = RegistrationStatus.Pending;
}