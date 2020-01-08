using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GSTBillingApp.Models
{
    public class OwnerAddress
    {

        public List<OwnerAddress> AddressList { get; set; } = new List<OwnerAddress>();
        public int Id { get; set; }
        public string AddressUIId { get; set; }

        [Required(ErrorMessage ="Please Enter Street 1")]
        public string Street1 { get; set; }

        [Required(ErrorMessage = "Please Enter Street 2")]
        public string Street2 { get; set; }

        [Required(ErrorMessage = "Please Enter City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please Enter Post Code")]
        public int PostCode { get; set; }

        [Required(ErrorMessage ="Please Select State")]
        public int StateId { get; set; }
        public List<SelectListItem> StateDD { get; set; }

        public string StateValue { get; set; }

        public bool IsCreated { get; set; }
        public bool IsUpdated { get; set; }
    }


}