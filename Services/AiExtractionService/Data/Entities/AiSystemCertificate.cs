namespace Data.Entities;

public class AiSystemCertificate
{
    public string Type { get; set; } = null!;
    public int Number { get; set; }
    public DateTime ExpiryDate { get; set; }
    public string? NotifiedBody { get; set; }
    
    //If we use a file system
    //public string ScannedCopyId { get; set; }
}