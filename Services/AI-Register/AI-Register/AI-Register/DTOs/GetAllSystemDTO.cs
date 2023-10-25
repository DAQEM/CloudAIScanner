namespace AIRegister.DTOs
{
    public class GetAllSystemDTO
    {
        public List<GetAISystemDTO> AISystems { get; set; }

        public GetAllSystemDTO()
        {
            AISystems = new List<GetAISystemDTO>();
        }
    }
}
