using Data.Models;

namespace Data.Entities;

public class AiSystemModel
{
    public string TradeName { get; set; }
    public string? UnambiguousReference { get; set; }
    public string Description { get; set; }
    public AiSystemProvider Provider { get; set; }
    public AiSystemRepresentative Representative { get; set; }
    public string Type { get; set; }
    public int Number { get; set; }
    public DateTime ExpiryDate { get; set; }
    public AiStatus AiStatus { get; set; }
    public RegistrationStatus RegistrationStatus { get; set; }
}