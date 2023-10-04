using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Entities
{
    public class ScanCertificateEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Filename { get; set; }
        public string Filepath { get; set; }
        public CertificateEntity Certificate { get; set; } 
    }
}
