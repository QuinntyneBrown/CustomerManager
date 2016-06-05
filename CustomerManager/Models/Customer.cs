using System.Collections.Generic;

namespace CustomerManager.Models
{
    public class Customer
    {
        public Customer()
        {
            AddressInfos = new HashSet<AddressInfo>();
            ContactInfos = new HashSet<ContactInfo>();
        }

        public int Id { get; set; }
        public int? TenantId { get; set; }
        public string Name { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public ICollection<ContactInfo> ContactInfos { get; set; } 
        public ICollection<AddressInfo> AddressInfos { get; set; }
        public bool IsDeleted { get; set; }
    }
}
