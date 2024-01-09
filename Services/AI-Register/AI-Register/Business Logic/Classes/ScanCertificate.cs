namespace BusinessLogic.Classes
{
    public class ScanCertificate
    {
        public Guid guid { get; set; }
        public string Filename { get; set; }
        public string Filepath { get; set; }
        public ScanCertificate(Guid guid, string filename, string filepath)
        {
            this.guid = guid;
            Filename = filename;
            Filepath = filepath;
        }
    }
}
