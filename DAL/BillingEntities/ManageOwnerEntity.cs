using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.BillingEntities
{
    public class ManageOwnerEntity
    {
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public int ContactNo { get; set; }
        public string GSTNo { get; set; }
        public string Juridication { get; set; }
        public string BusinessType { get; set; }
        public OwnerAddressEntity OwnerAddress { get; set; }
        public OwnerBankDetailEntity OwnerBankDetails { get; set; }
    }
}
