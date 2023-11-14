namespace BusinessLogic.Classes
{
    public class Provider
    {
        public Guid guid { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public List<AISystem> AISystems { get; set; }
        public List<AuthorisedRepresentative> AuthorizedRepresentitives { get; set; }

        public Provider(Guid guid, string name, string address, string email, string phoneNumber)
        {
            this.guid = guid;
            Name = name;
            Address = address;
            Email = email;
            PhoneNumber = phoneNumber;
        }
        public Provider()
        {
            AISystems = new List<AISystem>();
            AuthorizedRepresentitives = new List<AuthorisedRepresentative>();
        }

    }
}