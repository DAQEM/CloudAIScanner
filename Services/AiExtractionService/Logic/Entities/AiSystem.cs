using logic.Models;

namespace logic.Entities;

public class AiSystem
{
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public string UnambiguousReference {get; set;}
    public AiStatus Status { get; set; }
    public string URL { get; set; }
    public string Description { get; set; }
    public string TechnicalDocumentationLink { get; set; }
    public ApprovalStatus ApprovalStatus { get; set; }
    public DateOnly DateAdded { get; set; }
    public AiSystemProvider Provider { get; set; }
    public AiSystemCertificate certificate { get; set; }
    public MemberStates MemberState { get; set; }
    public ICollection<AISystemFile> Files { get; set; }
}