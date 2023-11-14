using BusinessLogic.Classes;
using BusinessLogic.Enums;

namespace AIRegister.DTOs
{
    public class GetAISystemDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UnambiguousReference { get; set; }
        public string ProviderName { get; set; }
        public DateOnly DateAdded { get; set; }
        public string Description { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }

        public GetAISystemDTO(Guid id , string name, string providerName, DateOnly dateAdded, ApprovalStatus approvalStatus, string description, string unambiguousReference)
        {
            Id = id;
            Name = name;
            ProviderName = providerName;
            DateAdded = dateAdded;
            ApprovalStatus = approvalStatus;
            Description = description;
            UnambiguousReference = unambiguousReference;
        }
    }
}
