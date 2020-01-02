using System.ComponentModel.DataAnnotations;

namespace GSTBillingApp.Models
{
    public class ManageOwnerViewModel
    {
        public int OwnerId { get; set; }

        [Required(ErrorMessage ="Please Enter Owner Name")]
        public string OwnerName { get; set; }

        [Required(ErrorMessage ="Please Enter GST")]
        //[RegularExpression(@"\d{2}[A-Z]{5}\d{4}[A-Z]{1}[A-Z\d]{1}[Z]{1}[A-Z\d]{1}",ErrorMessage ="Please Enter valid GST")]
        public string GSTNumber { get; set; }

        [Required(ErrorMessage ="Please Enter Contact Number")]
        public long ContactNumber { get; set; }

        [Required(ErrorMessage ="Please Enter Your Juridication")]
        public string Juridication { get; set; }

        [Required(ErrorMessage ="Please Enter Your Business Type")]
        public string BusiniessType { get; set; }

        public OwnerAddress OwnerAddresses { get; set; }

        public OwnerBankDetail OwnerBank { get; set; }


    }
}