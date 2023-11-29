namespace BusinessLogic.Classes
{
    public class AISystemFile
    {
        public Guid guid { get; set; }
        public string Filepath { get; set; }
        public string Filetype { get; set; }
        
        public AISystemFile(Guid guid, string filepath, string filetype)
        {
            this.guid = guid;
            Filepath = filepath;
            Filetype = filetype;
        }
        public AISystemFile(string filepath, string filetype)
        {
            Filepath = filepath;
            Filetype = filetype;
        }
    }
}
