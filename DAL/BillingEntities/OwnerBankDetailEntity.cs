using System.Collections.Generic;

namespace DAL.BillingEntities
{
    public class OwnerBankDetailEntity
    {
        public List<OwnerBankDetailEntity> OwnerBankList { get; set; } = new List<OwnerBankDetailEntity>();
        public int Id { get; set; }
        public string BankName { get; set; }
        public string Branch { get; set; }
        public int AccountNumber { get; set; }
        public string IFSC { get; set; }

    }
}
