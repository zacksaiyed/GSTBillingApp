using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.BillingEntities
{
    public class InvoiceEntitiy
    {
        public List<InvoiceEntitiy> invoiceEntitiys { get; set; } = new List<InvoiceEntitiy>();

        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string InvoiceNo { get; set; }
        public string DeliveryChallanNo { get; set; }
        public string SellerName  { get; set; }
        public string GSTNo { get; set; }
        public string StateId { get; set; }
        public string StateCode { get; set; }
        public string CityName { get; set; }
        public string ViehicalNo { get; set; }
        public string DriverName { get; set; }
        public string PlaceofSupply { get; set; }
        public string DateofSupply { get; set; }
    }
}
