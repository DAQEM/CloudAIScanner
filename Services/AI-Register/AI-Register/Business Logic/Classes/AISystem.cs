using BusinessLogic.Entities;
using BusinessLogic.Enums;

namespace BusinessLogic.Classes
{
    public class AISystem
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public AISystemStatus Status { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }
        public string TechnicalDocumentationLink { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public DateOnly DateAdded { get; set; }
        public Provider provider { get; set; }
        public Certificate certificate { get; set; }
        public MemberStates MemberState { get; set; }
        public ICollection<AISystemFile> Files { get; set; }


        public AISystem(){ }
        
        public AISystem(Guid guid, string name, AISystemStatus status, string url, string technicalDocumentationLink, ApprovalStatus approvalStatus, DateOnly dateAdded, Provider provider, Certificate certificate, string description, MemberStates memberstate)
        {
            Guid = guid;
            Name = name;
            Status = status;
            URL = url;
            MemberState = memberstate;
            Description = description;
            TechnicalDocumentationLink = technicalDocumentationLink;
            ApprovalStatus = approvalStatus;
            DateAdded = dateAdded;
            this.provider = provider;
            this.certificate = certificate;
        }

        public AISystem(Guid guid, string name, AISystemStatus status, string url, string description, string technicalDocumentationLink, ApprovalStatus approvalStatus, MemberStates memberState)
        {
            Guid = guid;
            Name = name;
            Status = status;
            URL = url;
            Description = description;
            TechnicalDocumentationLink = technicalDocumentationLink;
            ApprovalStatus = approvalStatus;
            MemberState = memberState;
        }

        internal void setFiles(AISystemEntity aiSystemEntity)
        {
            Files = new List<AISystemFile>();
            foreach (AISystemFileEntity fileEntity in aiSystemEntity.FileEntities)
            {
                AISystemFile aiSystemFile = new AISystemFile(fileEntity.Id, fileEntity.Filename, fileEntity.Filepath,
                    fileEntity.Filetype);
                Files.Add(aiSystemFile);
            }
        }
    }
}
