namespace AIRegister.DTOs;

public class AuthorisedRepresentativeDTO
{
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    public AuthorisedRepresentativeDTO(Guid guid, string name, string phoneNumber, string email)
    {
        Guid = guid;
        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;
    }
}