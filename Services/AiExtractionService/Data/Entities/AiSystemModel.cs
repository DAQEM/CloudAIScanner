namespace AiExtractionService.Models;

public class AiSystemModel
{
    public string TradeName { get; set; }
    public string? UnambiguousReference { get; set; }
    public string Description { get; set; }
    public AiSystemProvider Provider { get; set; }
    public AiSystemRepresentative Representative { get; set; }
    public string Type { get; set; }
    public enum StatusAi
    {
        OnTheMarket,
        InService,
        NoLongerInMarket,
        NoLongerInService,
        Recalled
    }
    
    public enum Status
    {
        Complete,
        Pending,
        Approved
    }
    
}