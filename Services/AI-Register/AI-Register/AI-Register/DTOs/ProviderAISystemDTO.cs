using BusinessLogic.Classes;

namespace AIRegister.DTOs;

public class ProviderAISystemDTO
{
    public Guid guid { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public List<GetAISystemDTO> AiSystemDtos { get; set; }

    public ProviderAISystemDTO(Provider provider)
    {
        guid = provider.guid;
        Name = provider.Name;
        Address = provider.Address;
        Email = provider.Email;
        PhoneNumber = provider.PhoneNumber;
        AiSystemDtos = new List<GetAISystemDTO>();
    }
}