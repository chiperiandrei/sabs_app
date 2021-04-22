using System;

namespace sabs_app_api.Models
{
    public class PendingAdresses
    {
        public Guid ID { get; set; }
        public string Email { get; set; }
        public string IpValue { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }


        public static PendingAdresses Create(string email, string ipadress)
        {
            return new PendingAdresses
            {
                ID = Guid.NewGuid(),
                Email = email,
                IpValue = ipadress,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow
            };
        }
    }
}