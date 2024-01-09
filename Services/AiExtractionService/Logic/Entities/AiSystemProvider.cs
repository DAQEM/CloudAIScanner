namespace logic.Entities;

public class AiSystemProvider
{
    public Guid Guid { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public List<AuthorisedRepresentative> AuthorizedRepresentitives { get; set; }
}