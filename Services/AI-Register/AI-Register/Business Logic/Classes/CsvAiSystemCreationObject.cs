using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Entities;

namespace BusinessLogic.Classes
{
    public class CsvAiSystemCreationObject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ProviderName { get; set; }
        public string UnambiguousReference { get; set; }
        public DateOnly DateAdded { get; set; }
        public string Description { get; set; }
        public string ApprovalStatusName { get; set; }

        public CsvAiSystemCreationObject(AISystemEntity aiSystem, Provider provider)
        {
            Id = aiSystem.Id;
            Name = aiSystem.Name;
            ProviderName = provider.Name;
            UnambiguousReference = aiSystem.UnambiguousReference;
            DateAdded = aiSystem.DateAdded;
            Description = aiSystem.Description;
            ApprovalStatusName = aiSystem.ApprovalStatus.ToString();
        }

        public CsvAiSystemCreationObject() {}
    }
}
