using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class ScanCertificateDTO
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Filename { get; set; }
        public string Filepath { get; set; }
        public CertificateDTO Certificate { get; set; } 
    }
}
