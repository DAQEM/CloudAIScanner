using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class CertificateDTO
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Type { get; set; }
        public int Number { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string NameNotifiedBody { get; set; }
        public int IdNotifiedBody { get; set; }

        public Guid ScannedCertificateId { get; set; }  

        public ScanCertificateDTO ScanCertificate { get; set; }
        public AISystemDTO AISystemDTO { get; set; }
    }
}
