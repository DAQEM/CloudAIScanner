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
        public string TechnicalDocumentationLink { get; set; }
        public AIRegisterEnum.ApprovalStatus ApprovalStatus { get; set; }
        public DateOnly DateAdded { get; set; }
        public Provider provider { get; set; }
        public Certificate certificate { get; set; }
        public ICollection<AISystemFile> Files { get; set; }


        public AISystem(){ }

        internal AISystem toAISystem(AISystemEntity aiSystemEntity)
        {
           Guid = aiSystemEntity.Id;
           Name = aiSystemEntity.Name;
           Status = aiSystemEntity.Status;
           URL = aiSystemEntity.URL;
           DateAdded = aiSystemEntity.DateAdded;
           ApprovalStatus = (AIRegisterEnum.ApprovalStatus)aiSystemEntity.ApprovalStatus;

            TechnicalDocumentationLink = aiSystemEntity.TechnicalDocumentationLink;
            provider = new Provider();
            provider.toSimpleProvider(aiSystemEntity.ProviderEntity);
            certificate = new Certificate();
            certificate.toCertificate(aiSystemEntity.CertificateEntity);

            return this;
        }

        internal void setFiles(AISystemEntity aiSystemEntity)
        {
            Files = new List<AISystemFile>();
            foreach (AISystemFileEntity fileEntity in aiSystemEntity.FileEntities)
            {
                AISystemFile file = new AISystemFile();
                file.toAISystemFile(fileEntity);
                Files.Add(file);
            }
        }
    }

}
