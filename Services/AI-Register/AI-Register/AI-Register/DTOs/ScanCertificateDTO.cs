using BusinessLogic.Classes;

namespace AIRegister.DTOs
{
    public class ScanCertificateDTO
    {
        public Guid guid { get; set; }
        public string Filename { get; set; }
        public string Filepath { get; set; }

        public ScanCertificateDTO(ScanCertificate scanCertificate)
        {
            guid = scanCertificate.guid;
            Filename = scanCertificate.Filename;
            Filepath = scanCertificate.Filepath;
        }
    }
}
