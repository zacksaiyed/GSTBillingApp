using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GSTBillingApp.Models
{
    public class OwnerBankDetail
    {

        public List<OwnerBankDetail> OwnerBankList { get; set; } = new List<OwnerBankDetail>();
        public int Id { get; set; }

        public string BankUID { get; set; }

        [Required(ErrorMessage ="Please Enter Bank Name")]
        public string BankName { get; set; }

        [Required(ErrorMessage = "Please Enter Branch Name")]
        public string Branch { get; set; }

        [Required(ErrorMessage = "Please Enter Account Number")]
        public int AccountNumber { get; set; }

        [Required(ErrorMessage = "Please Enter IFSC Code")]
        public string IFSC { get; set; }

        public bool IsCreated { get; set; }
        public bool IsUpdated { get; set; }



    }
}