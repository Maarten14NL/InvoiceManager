using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

using InvoiceManager_Logic;
using InvoiceManager_Logic.Entities;

namespace InvoiceManager.Controllers
{
    [AllowCrossSiteJsonAttribute]
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

        public ActionResult Create(String data)
        {
            CompanyContractsEntity givenCompanies = JsonConvert.DeserializeObject<CompanyContractsEntity>(data);
            CompanyContracts cc = new CompanyContracts();

            return Json(new { success = cc.Create(givenCompanies) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(String data)
        {
            CompanyContractsEntity givenCompanies = JsonConvert.DeserializeObject<CompanyContractsEntity>(data);
            CompanyContracts cc = new CompanyContracts();

            return Json(new { success = cc.Update(givenCompanies) }, JsonRequestBehavior.AllowGet);
        }

    }
}