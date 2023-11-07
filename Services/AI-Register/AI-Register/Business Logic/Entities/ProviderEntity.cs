using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Entities
{
    public class ProviderEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<AISystemEntity> aISystemEntity{ get; set;}
        
    }
}