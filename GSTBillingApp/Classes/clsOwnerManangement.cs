using DAL.BillingServices;
using GSTBillingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public static List<SelectListItem> GetStateDropDown()
        {
            var Data = OwnerService.GetStateDD().Select(m => new SelectListItem()
            {
                Text = m.StateName,
                Value = m.Id.ToString()
            }).ToList();

            Data.Insert(0, new SelectListItem { Value = "", Text = "Please Select State" });

            return Data;
        }

        public static ManageOwnerViewModel GetOwnerById(int OwnerId)
        {
            ManageOwnerViewModel model = new ManageOwnerViewModel();
            model.OwnerAddresses = new OwnerAddress();
            model.OwnerBank = new OwnerBankDetail();

            var Data = OwnerService.GetOwnerById(OwnerId);
            if (Data !=null)
            {
                model.OwnerId = Data.OwnerId;
                model.OwnerName = Data.OwnerName;
                model.ContactNumber = Data.ContactNo;
                model.GSTNumber = Data.GSTNo;
                model.Juridication = Data.Juridication;
                model.BusiniessType = Data.BusinessType;

                foreach (var item in Data.OwnerAddress.AddressList)
                {
                    model.OwnerAddresses.AddressList.Add(new OwnerAddress()
                    {
                        Id = item.Id,
                        Street1 = item.Street1,
                        Street2 = item.Street2,
                        City = item.City,
                        PostCode = item.PostCode,
                        StateId = item.StateId,
                        StateValue = clsOwnerManangement.GetStateDropDown().Where(x=>x.Value==item.StateId.ToString()).Select(x=>x.Text).FirstOrDefault()
                    });
                    
                }

                foreach (var item in Data.OwnerBankDetails.OwnerBankList)
                {
                    model.OwnerBank.OwnerBankList.Add(new OwnerBankDetail()
                    {
                        Id=item.Id,
                        BankName=item.BankName,
                        Branch=item.Branch,
                        AccountNumber=item.AccountNumber,
                        IFSC=item.IFSC
                    });
                }

            }


            return model;

        }
    }
}