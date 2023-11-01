using BusinessLogic.Classes;

namespace AIRegister.DTOs
{
    public class GetAISystemDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ProviderName { get; set; }
        public DateOnly DateAdded { get; set; }
        public string Description { get; set; }
        public AIRegisterEnum.ApprovalStatus ApprovalStatus { get; set; }

        public GetAISystemDTO(Guid id , string name, string providerName, DateOnly dateAdded, AIRegisterEnum.ApprovalStatus approvalStatus, string description)
        {
            Id = id;
            Name = name;
            ProviderName = providerName;
            DateAdded = dateAdded;
            ApprovalStatus = approvalStatus;
            Description = description;
        }
    }
}
