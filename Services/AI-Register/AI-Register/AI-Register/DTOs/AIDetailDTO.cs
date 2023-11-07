using BusinessLogic.Classes;

namespace AIRegister.DTOs
{
    public class AIDetailDTO
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public string Url { get; set; }
        public string TechnicalDocumentationLink { get; set; }
        public int ApprovalStatus { get; set; }
        public DateOnly DateAdded { get; set; }
        public ProviderDTO Provider { get; set; }
        public CertificateDTO Certificate { get; set; }
        public List<AISystemFile> Files { get; set; }

        public AIDetailDTO(Guid guid, string name, int status, string url, string technicalDocumentationLink, int approvalStatus, DateOnly dateAdded, ProviderDTO provider, CertificateDTO certificate, List<AISystemFile> files)
        {
            Guid = guid;
            Name = name;
            Status = status;
            Url = url;
            TechnicalDocumentationLink = technicalDocumentationLink;
            ApprovalStatus = approvalStatus;
            DateAdded = dateAdded;
            Provider = provider;
            Certificate = certificate;
            Files = files;
        }

    }
}
