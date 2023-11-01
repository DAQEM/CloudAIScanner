using BusinessLogic.Entities;

namespace BusinessLogic.Classes
{
    public class Provider
    {
        public Guid guid { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<AISystem> AISystems { get; set; }

        internal Provider toSimpleProvider(ProviderEntity providerEntity)
        {
            guid = providerEntity.Id;
            Name = providerEntity.Name;
            Address = providerEntity.Address;
            Email = providerEntity.Email;
            PhoneNumber = providerEntity.PhoneNumber;

            return this;
        }

        public Provider()
        {
            AISystems = new List<AISystem>();
        }

    }
}