using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Entities;

namespace BusinessLogic.Classes
{
    public class ScanCertificate
    {
        public Guid guid { get; set; }
        public string Filename { get; set; }
        public string Filepath { get; set; }

        internal ScanCertificate toScanCertificate(ScanCertificateEntity scanCertificate)
        {
            guid = scanCertificate.Id;
            Filename = scanCertificate.Filename;
            Filepath = scanCertificate.Filepath;
            return this;
        }
    }
}
