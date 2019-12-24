using DAL.BillingServices;
using GSTBillingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GSTBillingApp.Classes
{
    public class clsOwnerManangement
    {
        public static List<OwnerListViewModel> GetOwnerList()
        {
            List<OwnerListViewModel> ownerList = new List<OwnerListViewModel>();

            var Data = OwnerService.GetOwnerList();
            if (Data !=null)
            {

                foreach (var item in Data)
                {
                    ownerList.Add(new OwnerListViewModel()
                    {
                        ContactNo=item.ContactNo,
                        GSTNo=item.GSTNo,
                        Id=item.Id,
                        OwnerAddress=item.OwnerAddress,
                        OwnerName=item.OwnerName
                    }); 
                }
            }

            return ownerList;
        }
    }
}