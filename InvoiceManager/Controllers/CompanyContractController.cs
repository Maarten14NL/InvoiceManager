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
            CompanyContracts cc = new CompanyContracts();
            var CompanyContracts = cc.Read();

            return Json(new { companyContracts = CompanyContracts }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ByCompany(int id)
        {
            CompanyContracts cc = new CompanyContracts();
            var CompanyContracts = cc.GetByCompany(id);

            return Json(new { companyContracts = CompanyContracts }, JsonRequestBehavior.AllowGet);
        }

    }
}