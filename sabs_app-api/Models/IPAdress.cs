using System;

namespace sabs_app_api.Models
{
    public class IPAdress
    {
        public Guid ID { get; set; }
        public string IPValue { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Guid UserID { get; set; }
        public User User { get; set; }

        public IPAdress()
        {
            ID = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
            ModifiedDate = DateTime.UtcNow;
        }

        public static IPAdress Create(User user, string ipadress)
        {
            return new IPAdress
            {
                ID = Guid.NewGuid(),
                User = user,
                IPValue = ipadress,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow
            };
        }
    }
}
