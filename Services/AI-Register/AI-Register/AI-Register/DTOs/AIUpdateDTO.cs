using BusinessLogic.Classes;

namespace AIRegister.DTOs;

public class AIUpdateDTO
{
    public Guid Guid { get; set; }
    public string? Name { get; set; }
    public int Status { get; set; }
    public string? Url { get; set; }
    public string? TechnicalDocumentationLink { get; set; }
    public string? Description { get; set; }
    public AIRegisterEnum.ApprovalStatus ApprovalStatus { get; set; }

    public AIUpdateDTO(Guid guid, string name, int status, string url, string technicalDocumentationLink,
        string description, AIRegisterEnum.ApprovalStatus approvalStatus)
    {
        Guid = guid;
        Name = name;
        Status = status;
        Url = url;
        TechnicalDocumentationLink = technicalDocumentationLink;
        Description = description;
        ApprovalStatus = approvalStatus;
    }
}