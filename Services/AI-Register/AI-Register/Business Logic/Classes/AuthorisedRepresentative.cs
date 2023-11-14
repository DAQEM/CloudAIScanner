namespace BusinessLogic.Classes;

public class AuthorisedRepresentative
{
    public Guid guid { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public Provider Provider { get; set; }

    public AuthorisedRepresentative(Guid guid, string? name, string? email, string? phoneNumber, Provider provider)
    {
        this.guid = guid;
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
        Provider = provider;
    }
    public AuthorisedRepresentative(Guid guid, string? name, string? email, string? phoneNumber)
    {
        this.guid = guid;
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
    }

    public AuthorisedRepresentative()
    {
        
    }
}