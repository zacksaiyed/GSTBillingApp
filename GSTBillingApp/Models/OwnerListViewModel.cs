using System.Collections.Generic;

namespace GSTBillingApp.Models
{
    public class OwnerListViewModel
    {
        public List<OwnerListViewModel> ownersList = new List<OwnerListViewModel>();
        public int Id { get; set; }
        public string OwnerName { get; set; }
        public string GSTNo { get; set; }
        public int ContactNo { get; set; }
        public string OwnerAddress { get; set; }
    }
}