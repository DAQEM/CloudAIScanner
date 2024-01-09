namespace logic.Entities;

public class AiSystemCertificate
{
    public Guid guid { get; set; }
    public string Type { get; set; }
    public int Number { get; set; }
    public DateTime ExpiryDate { get; set; }
    public string NameNotifiedBody { get; set; }
    public int IdNotifiedBody { get; set; }
    public AiSystemScanCertificate ScanCertificate { get; set; }
}