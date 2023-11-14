using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Entities;

public class AuthorisedRepresentativesEntity
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public ProviderEntity Provider { get; set; }
    public Guid ProviderId { get; set; }
}