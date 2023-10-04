using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Entities
{
    public class AISystemFileEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Filename { get; set; }
        public string Filepath { get; set; }
        public string Filetype { get; set; }
        public Guid AISystemId { get; set; }
        public AISystemEntity AISystemEntity { get; set; }    
    }
}
