using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Entities;

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

        internal Certificate toCertificate(CertificateEntity certificateEntity)
        {
            guid = certificateEntity.Id;
            Type = certificateEntity.Type;
            Number = certificateEntity.Number;
            ExpiryDate = certificateEntity.ExpiryDate;
            NameNotifiedBody = certificateEntity.NameNotifiedBody;
            IdNotifiedBody = certificateEntity.IdNotifiedBody;
            ScanCertificate = new ScanCertificate().toScanCertificate(certificateEntity.ScanCertificate);

            return this;
        }
    }
}
