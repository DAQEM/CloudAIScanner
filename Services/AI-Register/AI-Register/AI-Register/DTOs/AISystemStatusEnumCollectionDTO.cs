namespace AIRegister.DTOs
{
    public class AISystemStatusEnumCollectionDTO
    {
        public List<AISystemStatusEnumDTO> SystemStatuses { get; set; }

        public AISystemStatusEnumCollectionDTO()
        {
            SystemStatuses = new List<AISystemStatusEnumDTO>();
        }
    }
}
