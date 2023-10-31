using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Entities;

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
        public Provider provider { get; set; }
        public Certificate certificate { get; set; }
        
    }
}
