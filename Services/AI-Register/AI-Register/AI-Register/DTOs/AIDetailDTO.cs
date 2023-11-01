using BusinessLogic.Classes;

namespace AIRegister.DTOs
{
    public class AIDetailDTO
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public AIRegisterEnum.AISystemStatus Status { get; set; }
        public string Url { get; set; }
        public string TechnicalDocumentationLink { get; set; }
        public AIRegisterEnum.ApprovalStatus ApprovalStatus { get; set; }
        public DateOnly DateAdded { get; set; }
        public string Description { get; set; }
        public ProviderDTO Provider { get; set; }
        public CertificateDTO Certificate { get; set; }
        public List<AISystemFile> Files { get; set; }
        public AIRegisterEnum.MemberStates MemberState { get; set; }

        public AIDetailDTO(Guid guid, string name, AIRegisterEnum.AISystemStatus status, string url, string technicalDocumentationLink, AIRegisterEnum.ApprovalStatus approvalStatus, DateOnly dateAdded, ProviderDTO provider, CertificateDTO certificate, List<AISystemFile> files, string description, AIRegisterEnum.MemberStates memberState)
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
            Description = description;
            MemberState = memberState;
        }

    }
}
