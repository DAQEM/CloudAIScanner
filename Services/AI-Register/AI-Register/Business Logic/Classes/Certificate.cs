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
        

        public Certificate(Guid guid, string type, int number, DateTime expiryDate, string nameNotifiedBody, int idNotifiedBody, ScanCertificate scanCertificate)
        {
            this.guid = guid;
            Type = type;
            Number = number;
            ExpiryDate = expiryDate;
            NameNotifiedBody = nameNotifiedBody;
            IdNotifiedBody = idNotifiedBody;
            ScanCertificate = scanCertificate;
        }
    }
}
