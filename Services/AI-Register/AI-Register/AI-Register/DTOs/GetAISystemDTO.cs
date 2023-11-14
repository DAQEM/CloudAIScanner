using BusinessLogic.Classes;
using BusinessLogic.Enums;

namespace AIRegister.DTOs
{
    public class GetAISystemDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ProviderDTO Provider { get; set; }
        public string UnambiguousReference { get; set; }
        public DateOnly DateAdded { get; set; }
        public string Description { get; set; }
        public EnumDTO ApprovalStatus { get; set; }

        public GetAISystemDTO(Guid id , string name, string providerName, DateOnly dateAdded, ApprovalStatus approvalStatus, string description, string unambiguousReference)
        {
            Id = id;
            Name = name;
            Provider = new ProviderDTO(new Provider(Guid.Empty, providerName, string.Empty, string.Empty, string.Empty));
            DateAdded = dateAdded;
            ApprovalStatus = new EnumDTO
            {
                id = (int)approvalStatus,
                Name = approvalStatus.ToString()
            };
            Description = description;
            UnambiguousReference = unambiguousReference;
        }
    }
}
