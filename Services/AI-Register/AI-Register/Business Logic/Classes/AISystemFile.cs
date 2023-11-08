namespace BusinessLogic.Classes
{
    public class AISystemFile
    {
        public Guid guid { get; set; }
        public string Filename { get; set; }
        public string Filepath { get; set; }
        public string Filetype { get; set; }
        
        public AISystemFile(Guid guid, string filename, string filepath, string filetype)
        {
            this.guid = guid;
            Filename = filename;
            Filepath = filepath;
            Filetype = filetype;
        }
    }
}
