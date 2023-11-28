using BusinessLogic.Classes;

namespace AIRegister.DTOs;

public class AuthorisedRepresentativeProviderDTO
{
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public ProviderDTO Provider { get; set; }

    public AuthorisedRepresentativeProviderDTO(Guid guid, string name, string phoneNumber, string email, ProviderDTO provider)
    {
        Guid = guid;
        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;
        Provider = provider;
    }
}