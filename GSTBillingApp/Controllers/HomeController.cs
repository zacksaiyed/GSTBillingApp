using GSTBillingApp.Classes;
using GSTBillingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

       
    }
}