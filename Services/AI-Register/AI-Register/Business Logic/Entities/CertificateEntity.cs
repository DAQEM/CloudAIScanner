using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Entities
{
    public class CertificateEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Type { get; set; }
        public int Number { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string NameNotifiedBody { get; set; }
        public int IdNotifiedBody { get; set; }

        public Guid ScannedCertificateId { get; set; }  

        public ScanCertificateEntity ScanCertificate { get; set; }
        public AISystemEntity AISystemEntity { get; set; }
        
    }
}
