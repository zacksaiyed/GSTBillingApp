using GSTBillingApp.Classes;
using GSTBillingApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace GSTBillingApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            OwnerListViewModel model = new OwnerListViewModel();
            model.ownersList = clsOwnerManangement.GetOwnerList();

            return View(model);
        }

        public ActionResult ManageOwner(int OwnerId = 0)
        {
            ManageOwnerViewModel model = new ManageOwnerViewModel();
            model.OwnerAddresses = new OwnerAddress();
            model.OwnerAddresses.StateDD = clsOwnerManangement.GetStateDropDown();
            model.OwnerBank = new OwnerBankDetail();

            return View(model);
        }

        [HttpPost]
        public ActionResult ManageOwner(ManageOwnerViewModel model)
        {
            if (clsOwnerManangement.CreateUpdateOwner(model))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                model = new ManageOwnerViewModel();
                
            }
            return View(model);
            
        }
        public ActionResult _Address(List<OwnerAddress> response, int OwnerId)
        {
            ManageOwnerViewModel model = new ManageOwnerViewModel();


            model = clsOwnerManangement.GetOwnerById(OwnerId);

            model.OwnerAddresses.StateDD = clsOwnerManangement.GetStateDropDown();

            if (response == null)
            {
                response = new List<OwnerAddress>();
            }

            foreach (var item in response)
            {

                if (item.Id > 0 && model.OwnerAddresses.AddressList.Where(x => x.Id == item.Id).Count() > 0)

                {
                    foreach (var listitem in model.OwnerAddresses.AddressList)
                    {
                        if (listitem.Id == item.Id)
                        {

                            listitem.Street1 = item.Street1;
                            listitem.Street2 = item.Street2;
                            listitem.City = item.City;
                            listitem.PostCode = item.PostCode;
                            listitem.StateId = item.StateId;
                            listitem.StateValue = clsOwnerManangement.GetStateDropDown().Find(x => x.Value == item.StateId.ToString()).Text;

                        }
                    }

                }

                else
                {
                    if (model.OwnerAddresses.AddressList.Where(x => x.AddressUIId == item.AddressUIId).Count() <= 0)
                    {

                        model.OwnerAddresses.AddressList.Add(new OwnerAddress()
                        {
                            AddressUIId = item.AddressUIId,
                            PostCode = item.PostCode,
                            StateId = item.StateId,
                            City = item.City,
                            Street1 = item.Street1,
                            Street2 = item.Street2,
                            StateValue = clsOwnerManangement.GetStateDropDown().Where(x => x.Value == item.StateId.ToString()).Select(x => x.Text).FirstOrDefault(),


                        });
                    }
                    else if (item.IsUpdated)
                    {


                        foreach (var listitem in model.OwnerAddresses.AddressList)
                        {
                            if (listitem.AddressUIId == item.AddressUIId)
                            {

                                listitem.Street1 = item.Street1;
                                listitem.Street2 = item.Street2;
                                listitem.City = item.City;
                                listitem.PostCode = item.PostCode;
                                listitem.StateId = item.StateId;
                                listitem.StateValue = clsOwnerManangement.GetStateDropDown().Where(x => x.Value == item.StateId.ToString()).Select(x => x.Text).FirstOrDefault();


                            }
                        }

                    }

                }




            }

            return PartialView("_Address", model);



        }

        public JsonResult GetAddressById(int AddressId, OwnerAddress[] uiAddresses, string AddressGUID)
        {
            if (AddressGUID != null)
            {
                var uiAddressList = uiAddresses.ToList();
                if (uiAddressList != null)
                {
                    var Uiresponse = uiAddressList.Where(x => x.AddressUIId == AddressGUID).LastOrDefault();

                    return Json(Uiresponse);
                }

            }
            else
            {
                var DBresponse = clsOwnerManangement.GetAddressById(AddressId);
                return Json(DBresponse);
            }
            return Json(null);

        }

        public bool DeleteOwnerAddress(int AddressId, int OwnerId)
        {

            return clsOwnerManangement.DeleteOwnerAddres(AddressId, OwnerId);
        }

        public ActionResult _BankDetail(List<OwnerBankDetail> response, int OwnerId)
        {
            ManageOwnerViewModel model = new ManageOwnerViewModel();


            model = clsOwnerManangement.GetOwnerById(OwnerId);

            if (response == null)
            {
                response = new List<OwnerBankDetail>();
            }

            foreach (var item in response)
            {

                if (item.Id > 0 && model.OwnerBank.OwnerBankList.Where(x => x.Id == item.Id).Count() > 0)

                {
                    foreach (var listitem in model.OwnerBank.OwnerBankList)
                    {
                        if (listitem.Id == item.Id)
                        {

                            listitem.BankName = item.BankName;
                            listitem.Branch = item.Branch;
                            listitem.AccountNumber = item.AccountNumber;
                            listitem.IFSC = item.IFSC;


                        }
                    }

                }

                else
                {
                    if (model.OwnerBank.OwnerBankList.Where(x => x.BankUID == item.BankUID).Count() <= 0)
                    {

                        model.OwnerBank.OwnerBankList.Add(new OwnerBankDetail()
                        {
                            AccountNumber = item.AccountNumber,
                            BankName = item.BankName,
                            BankUID = item.BankUID,
                            Branch = item.Branch,
                            Id = item.Id,
                            IFSC = item.IFSC


                        });
                    }
                    else if (item.IsUpdated)
                    {


                        foreach (var listitem in model.OwnerBank.OwnerBankList)
                        {
                            if (listitem.BankUID == item.BankUID)
                            {

                                listitem.AccountNumber = item.AccountNumber;
                                listitem.BankName = item.BankName;
                                listitem.Branch = item.Branch;
                                listitem.IFSC = item.IFSC;

                            }
                        }

                    }

                }
            }

            return PartialView("_BankDetail", model);


        }

        public JsonResult GetBankDetailById(int BankId, OwnerBankDetail[] uiBanks, string BankGUID)
        {
            if (BankGUID != null)
            {
                var uiBanksList = uiBanks.ToList();
                if (uiBanksList != null)
                {
                    var Uiresponse = uiBanksList.Where(x => x.BankUID == BankGUID).LastOrDefault();

                    return Json(Uiresponse);
                }

            }
            else
            {
                var DBresponse = clsOwnerManangement.GetOwnerBankDetailById(BankId);
                return Json(DBresponse);
            }
            return Json(null);

        }

        public bool DeleteBankDetail(int BankId, int OwnerId)
        {

            return clsOwnerManangement.DeleteBankDetails(BankId, OwnerId);
        }




    }
}