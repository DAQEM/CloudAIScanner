using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Entities
{
    public class AISystemEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int Status { get; set; }
        public string URL { get; set; }
        public string TechnicalDocumentationLink { get; set; }
        public DateOnly DateAdded { get; set; }
        public int ApprovalStatus { get; set; }
        public string Description { get; set; }
        public Guid ProviderId { get; set; }
        public Guid CertificateId { get; set; }
        public int MemberState { get; set; }
        public ProviderEntity ProviderEntity { get; set; }
        public CertificateEntity CertificateEntity { get; set; }
        public ICollection<AISystemFileEntity> FileEntities { get; set; } = new List<AISystemFileEntity>();

    }
}
