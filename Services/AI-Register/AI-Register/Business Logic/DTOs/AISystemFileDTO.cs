using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class AISystemFileDTO
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Filename { get; set; }
        public string Filepath { get; set; }
        public string Filetype { get; set; }
        public Guid AISystemId { get; set; }
        public AISystemDTO AISystemDTO { get; set; }    
    }
}
