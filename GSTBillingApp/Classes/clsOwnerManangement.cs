using DAL.BillingEntities;
using DAL.BillingServices;
using GSTBillingApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace GSTBillingApp.Classes
{
    public class clsOwnerManangement
    {
        public static List<OwnerListViewModel> GetOwnerList()
        {
            List<OwnerListViewModel> ownerList = new List<OwnerListViewModel>();

            var Data = OwnerService.GetOwnerList();
            if (Data != null)
            {

                foreach (var item in Data)
                {
                    ownerList.Add(new OwnerListViewModel()
                    {
                        ContactNo = item.ContactNo,
                        GSTNo = item.GSTNo,
                        Id = item.Id,
                        OwnerAddress = item.OwnerAddress,
                        OwnerName = item.OwnerName
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
            model.OwnerAddresses.StateDD = clsOwnerManangement.GetStateDropDown();
            var Data = OwnerService.GetOwnerById(OwnerId);
            if (Data != null)
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
                        StateDD = clsOwnerManangement.GetStateDropDown(),
                        StateValue = clsOwnerManangement.GetStateDropDown().Where(x => x.Value == item.StateId.ToString()).Select(x => x.Text).FirstOrDefault()
                    });

                }

                foreach (var item in Data.OwnerBankDetails.OwnerBankList)
                {
                    model.OwnerBank.OwnerBankList.Add(new OwnerBankDetail()
                    {
                        Id = item.Id,
                        BankName = item.BankName,
                        Branch = item.Branch,
                        AccountNumber = item.AccountNumber,
                        IFSC = item.IFSC
                    });
                }

            }


            return model;

        }

        public static OwnerAddress GetAddressById(int AddressId)
        {
            OwnerAddress ownerAddress = new OwnerAddress();

            var Data = OwnerService.GetOwnerAddressById(AddressId);

            if (Data != null)
            {
                ownerAddress.Id = Data.Id;
                ownerAddress.Street1 = Data.Street1;
                ownerAddress.Street2 = Data.Street2;
                ownerAddress.City = Data.City;
                ownerAddress.PostCode = Data.PostCode;
                ownerAddress.StateId = Data.StateId;
            }

            return ownerAddress;
        }

        public static bool DeleteOwnerAddres(int AddressId, int OwnerId)
        {
            return OwnerService.DeleteOwnerAddress(AddressId, OwnerId);
        }

        public static OwnerBankDetail GetOwnerBankDetailById(int BankId)
        {
            OwnerBankDetail bankDetail = new OwnerBankDetail();

            var Data = OwnerService.GetOwnerBankDetail(BankId);

            if (Data != null)
            {
                bankDetail.Id = Data.Id;
                bankDetail.BankName = Data.BankName;
                bankDetail.Branch = Data.Branch;
                bankDetail.AccountNumber = Data.AccountNumber;
                bankDetail.IFSC = Data.IFSC;
            }

            return bankDetail;

        }

        public static bool DeleteBankDetails(int BankId, int OwnerId)
        {
            return OwnerService.DeleteBankDetail(BankId, OwnerId);
        }

        public static bool CreateUpdateOwner(ManageOwnerViewModel model)
        {
            ManageOwnerEntity entity = new ManageOwnerEntity();
            entity.OwnerAddress = new OwnerAddressEntity();
            entity.OwnerBankDetails = new OwnerBankDetailEntity();

            entity.OwnerId = model.OwnerId;
            entity.OwnerName = model.OwnerName;
            entity.ContactNo = model.ContactNumber;
            entity.GSTNo = model.GSTNumber;
            entity.Juridication = model.Juridication;
            entity.BusinessType = model.BusiniessType;

            if (model.OwnerAddresses !=null)
            {
                foreach (var item in model.OwnerAddresses.AddressList)
                {
                    entity.OwnerAddress.AddressList.Add(new OwnerAddressEntity()
                    {
                        Street1 = item.Street1,
                        City = item.City,
                        Id = item.Id,
                        PostCode = item.PostCode,
                        StateId = item.StateId,
                        Street2 = item.Street2,
                        IsCreated = item.IsCreated,
                        IsUpdated = item.IsUpdated

                    });
                } 
            }

            if (model.OwnerBank !=null)
            {
                foreach (var item in model.OwnerBank.OwnerBankList)
                {
                    entity.OwnerBankDetails.OwnerBankList.Add(new OwnerBankDetailEntity()
                    {
                        AccountNumber = item.AccountNumber,
                        BankName = item.BankName,
                        Branch = item.Branch,
                        Id = item.Id,
                        IFSC = item.IFSC,
                        IsCreated = item.IsCreated,
                        IsUpdated = item.IsUpdated
                    });
                } 
            }

            return OwnerService.CreateUpdateOwner(entity);

        }

        public static bool DeleteOwner(int OwnerId)
        {
            return OwnerService.DeleteOwner(OwnerId);
        }

    }
}