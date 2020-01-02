using System.Collections.Generic;

namespace DAL.BillingEntities
{
    public class OwnerAddressEntity
    {
        public List<OwnerAddressEntity> AddressList { get; set; } = new List<OwnerAddressEntity>();
        public int Id { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public int PostCode { get; set; }
        public int StateId { get; set; }
        public bool IsCreated { get; set; }
        public bool IsUpdated { get; set; }


    }
}
