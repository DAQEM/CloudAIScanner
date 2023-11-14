using BusinessLogic.Enums;

namespace AIRegister.DTOs;

public class AIUpdateDTO
{
    public Guid Guid { get; set; }
    public string? Name { get; set; }
    public AISystemStatus Status { get; set; }
    public string? Url { get; set; }
    public string? TechnicalDocumentationLink { get; set; }
    public string? Description { get; set; }
    public ApprovalStatus ApprovalStatus { get; set; }
    public MemberStates MemberState { get; set; }

    public AIUpdateDTO(Guid guid, string name, AISystemStatus status, string url, string technicalDocumentationLink,
        string description, ApprovalStatus approvalStatus, MemberStates memberState)
    {
        Guid = guid;
        Name = name;
        Status = status;
        Url = url;
        TechnicalDocumentationLink = technicalDocumentationLink;
        Description = description;
        ApprovalStatus = approvalStatus;
        MemberState = memberState;
    }
    
}