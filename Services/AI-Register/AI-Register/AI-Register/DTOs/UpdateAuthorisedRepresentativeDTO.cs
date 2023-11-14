namespace AIRegister.DTOs;

public class UpdateAuthorisedRepresentativeDTO
{
    public Guid? Guid { get; set; }
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }

    public UpdateAuthorisedRepresentativeDTO(Guid guid, string name, string phoneNumber, string email)
    {
        Guid = guid;
        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;
    }
    public UpdateAuthorisedRepresentativeDTO()
    {
    }
}