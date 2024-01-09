using BusinessLogic.Classes;
using BusinessLogic.Enums;

namespace AIRegister.DTOs
{
    public class AIDetailDTO
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public EnumDTO Status { get; set; }
        public string UnambiguousReference { get; set; }
        public string Url { get; set; }
        public string TechnicalDocumentationLink { get; set; }
        public EnumDTO ApprovalStatus { get; set; }
        public DateOnly DateAdded { get; set; }
        public string Description { get; set; }
        public ProviderDTO Provider { get; set; }
        public CertificateDTO Certificate { get; set; }
        public List<AISystemFile> Files { get; set; }
        public EnumDTO MemberState { get; set; }

        public AIDetailDTO(Guid guid, string name, AISystemStatus status, string url, string technicalDocumentationLink, ApprovalStatus approvalStatus, DateOnly dateAdded, ProviderDTO provider, CertificateDTO certificate, List<AISystemFile> files, string description, MemberStates memberState, string unambiguousReference)
        {
            Guid = guid;
            Name = name;
            Status = new EnumDTO
            {
                id = (int)status,
                Name = status.ToString()
            };
            Url = url;
            TechnicalDocumentationLink = technicalDocumentationLink;
            ApprovalStatus = new EnumDTO
            {
                id = (int)approvalStatus,
                Name = approvalStatus.ToString()
            };
            DateAdded = dateAdded;
            Provider = provider;
            Certificate = certificate;
            Files = files;
            Description = description;
            MemberState = new EnumDTO
            {
                id = (int)memberState,
                Name = memberState.ToString()
            };
            UnambiguousReference = unambiguousReference;
        }

    }
}
