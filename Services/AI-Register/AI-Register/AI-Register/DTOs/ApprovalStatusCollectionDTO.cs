namespace AIRegister.DTOs
{
    public class ApprovalStatusCollectionDTO
    {
        public List<ApprovalDTO> ApprovalStatuses { get; set; }

        public ApprovalStatusCollectionDTO()
        {
            ApprovalStatuses = new List<ApprovalDTO>();
        }
    }
}
