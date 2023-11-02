using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Classes
{
    public class Certificate
    {
        public Guid guid { get; set; }
        public string Type { get; set; }
        public int Number { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string NameNotifiedBody { get; set; }
        public int IdNotifiedBody { get; set; }
        public ScanCertificate ScanCertificate { get; set; }
    }
}
