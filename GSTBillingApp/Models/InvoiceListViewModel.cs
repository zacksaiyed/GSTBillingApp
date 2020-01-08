using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GSTBillingApp.Models
{
    public class InvoiceListViewModel
    {
        public List<InvoiceListViewModel> invoiceList = new List<InvoiceListViewModel>();
        public string InvoiceNo { get; set; }
        public string DeilveryChallanNo { get; set; }
        public string SellerName { get; set; }
        public string GSTNo { get; set; }
        public float Amount { get; set; }

    }
}