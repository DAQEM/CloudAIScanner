namespace AIRegister.DTOs;

public class ProviderUpdateDTO
{
    public Guid Guid { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public ProviderUpdateDTO(string name, string address, string email, string phoneNumber)
    {
        Name = name;
        Address = address;
        Email = email;
        PhoneNumber = phoneNumber;
    }
}