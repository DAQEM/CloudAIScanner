namespace AIRegister.DTOs
{
    public class CreateCsvDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ProviderName { get; set; }
        public string UnambiguousReference { get; set; }
        public DateOnly DateAdded { get; set; }
        public string Description { get; set; }
        public string ApprovalStatusName { get; set; }
    }
}
