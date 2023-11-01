using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Entities;
using BusinessLogic.Interfaces;

namespace BusinessLogic.Classes
{
    public class AISystem
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }
        public string TechnicalDocumentationLink { get; set; }
        public AIRegisterEnum.ApprovalStatus ApprovalStatus { get; set; }
        public DateOnly DateAdded { get; set; }
        public Provider provider { get; set; }
        public Certificate certificate { get; set; }
        public ICollection<AISystemFile> Files { get; set; }


        public AISystem()
        {
            
        }
        public AISystem(Guid guid, string name, int status, string url, string technicalDocumentationLink, AIRegisterEnum.ApprovalStatus approvalStatus, DateOnly dateAdded, Provider provider, Certificate certificate)
        {
            Guid = guid;
            Name = name;
            Status = status;
            URL = url;
            TechnicalDocumentationLink = technicalDocumentationLink;
            ApprovalStatus = approvalStatus;
            DateAdded = dateAdded;
            this.provider = provider;
            this.certificate = certificate;
            
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
