using BusinessLogic.Classes;

namespace AIRegister.DTOs
{
    public class CertificateDTO
    {
        public Guid guid { get; set; }
        public string Type { get; set; }
        public int Number { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string NameNotifiedBody { get; set; }
        public int IdNotifiedBody { get; set; }
        public ScanCertificateDTO ScanCertificate { get; set; }

        public CertificateDTO(Certificate certificate)
        {
            guid = certificate.guid;
            Type = certificate.Type;
            Number = certificate.Number;
            ExpiryDate = certificate.ExpiryDate;
            NameNotifiedBody = certificate.NameNotifiedBody;
            IdNotifiedBody = certificate.IdNotifiedBody;
            ScanCertificate = new ScanCertificateDTO(certificate.ScanCertificate);
        }
       
    }
    
}
