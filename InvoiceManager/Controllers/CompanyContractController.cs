using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

using InvoiceManager_Logic;

namespace InvoiceManager.Controllers
{
    public class CompanyContractController : Controller
    {
        // GET: CompanyContract
        public ActionResult Index()
        {
            //CompanyContracts cc = new CompanyContracts();
            //var Companies = cc.Index();

            return Json(new { companies = "test" }, JsonRequestBehavior.AllowGet);
        }

    }
}