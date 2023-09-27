using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class AISystemDTO
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int Status { get; set; }
        public string URL { get; set; }
        public string TechnicalDocumentationLink { get; set; }
        public Guid ProviderId { get; set; }
        public Guid CertificateId { get; set; }

        public ProviderDTO providerDTO { get; set; }
        public CertificateDTO certificateDTO { get; set; }
        public ICollection<AISystemFileDTO> fileDTOs { get; set; }
    }
}
