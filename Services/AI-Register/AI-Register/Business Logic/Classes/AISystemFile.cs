using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Classes
{
    public class AISystemFile
    {
        public Guid guid { get; set; }
        public string Filename { get; set; }
        public string Filepath { get; set; }
        public string Filetype { get; set; }
    }
}
