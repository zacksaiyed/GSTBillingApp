using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.BillingEntities
{
    public class OwnerEntitiy
    {
        public int Id { get; set; }
        public string OwnerName { get; set; }
        public string GSTNo { get; set; }
        public int ContactNo { get; set; }
        public string OwnerAddress { get; set; }
    }
}
