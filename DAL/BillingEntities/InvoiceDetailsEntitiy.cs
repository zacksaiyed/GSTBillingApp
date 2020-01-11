using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.BillingEntities
{
    public class InvoiceDetailsEntitiy
    {
        public List<InvoiceDetailsEntitiy> invoiceDetailsList { get; set; } = new List<InvoiceDetailsEntitiy>();

        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public string ItemDescription { get; set; }
        public int HSNCode { get; set; }
        public int Bags { get; set; }
        public int KG { get; set; }
        public int PerKGRate { get; set; }
        public int GSTRateId { get; set; }
        public int Amount { get; set; }

    }
}
